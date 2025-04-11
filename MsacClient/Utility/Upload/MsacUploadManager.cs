using MsacClient.Utility.Scheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Utility.Upload
{
    /// <summary>
    /// Handles uploading images to the MSAC. You should have one of these for the entire project.
    /// </summary>
    public class MsacUploadManager
    {
        public MsacUploadManager(IMsacConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Connection used to talk to the MSAC.
        /// </summary>
        private readonly IMsacConnection connection;

        /// <summary>
        /// The text to prepend to the filename when uploaded.
        /// </summary>
        public string FilenamePrefix { get; set; } = "";

        /// <summary>
        /// Gets or sets the amount of time that images will last on the MSAC before needing to be uploaded again.
        /// </summary>
        public TimeSpan CacheLifespan { get; set; } = TimeSpan.FromDays(7);

        /// <summary>
        /// The amount of time to wait to try again if an image upload fails.
        /// </summary>
        public TimeSpan ErrorDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Holds images mapped to their filename.
        /// </summary>
        private readonly Dictionary<string, CachedImage> cache = new Dictionary<string, CachedImage>();

        /// <summary>
        /// Starts uploading images to the MSAC. Thread-safe.
        /// </summary>
        /// <returns></returns>
        public Task UploadImageAsync(IMsacScheduledImage image, DateTime now)
        {
            //Lock mutex
            lock (cache)
            {
                //Attempt to find an image already stored
                if (cache.TryGetValue(image.Filename, out CachedImage cached))
                {
                    //Check if it is still valid AND if it failed a reasonable delay to wait has passed
                    if (cached.IsValid(now, cached.Task.IsFaulted ? ErrorDelay : CacheLifespan))
                        return cached.Task; // Return the original task

                    //Remove this from the cache and continue loading a fresh one
                    cache.Remove(image.Filename);
                }

                //Begin image upload...guarentee that there is a task, even if it fails immediately
                Task uploadTask;
                try
                {
                    uploadTask = UploadTask(image);
                } catch (Exception ex)
                {
                    uploadTask = Task.FromException(ex);
                }

                //Create the cache item and insert
                cache.Add(image.Filename, new CachedImage(image.Filename, now, uploadTask));

                return uploadTask;
            }
        }

        /// <summary>
        /// Helper task that performs the upload.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task UploadTask(IMsacScheduledImage image)
        {
            //Open the image and read into memory
            byte[] payload;
            using (Stream s = image.Open())
            {
                //Make buffer
                payload = new byte[s.Length];

                //Read
                int read = await s.ReadAsync(payload, 0, payload.Length);

                //Check
                if (read != payload.Length)
                    throw new Exception($"Failed to read entire image; Expected {payload.Length} bytes, got {read}!");
            }

            //Start upload
            await connection.FileCopyDirectAsync(FilenamePrefix + image.Filename, payload, 0, payload.Length);
        }

        class CachedImage
        {
            public CachedImage(string filename, DateTime uploadedAt, Task task)
            {
                this.filename = filename;
                this.uploadedAt = uploadedAt;
                this.task = task;
            }

            private readonly string filename;
            private readonly DateTime uploadedAt;
            private readonly Task task;

            public string Filename => filename;
            public DateTime UploadedAt => uploadedAt;
            public Task Task => task;

            public bool IsValid(DateTime now, TimeSpan cacheLifespan)
            {
                return (UploadedAt + cacheLifespan) >= now;
            }
        }
    }
}
