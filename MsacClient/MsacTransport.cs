using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MsacClient
{
    /// <summary>
    /// Handles communication with the MSAC
    /// </summary>
    public class MsacTransport
    {
        public MsacTransport(IPEndPoint ep)
        {
            this.ep = ep;
        }

        private readonly IPEndPoint ep;

        /// <summary>
        /// Asyncronously connects to the server and starts a transaction.
        /// </summary>
        /// <returns></returns>
        public Task<IMsacTransportTransaction> StartTransaction()
        {
            //Create socket
            Socket sock = new Socket(SocketType.Stream, ProtocolType.Tcp);

            //Create context
            AsyncConnectContext ctx = new AsyncConnectContext
            {
                sock = sock,
                task = new TaskCompletionSource<IMsacTransportTransaction>()
            };

            //Initiate the connection
            sock.BeginConnect(ep, OnConnectFinished, ctx);

            //Return task
            return ctx.task.Task;
        }

        private void OnConnectFinished(IAsyncResult ar)
        {
            //Get context
            AsyncConnectContext ctx = (AsyncConnectContext)ar.AsyncState;

            //Finish
            try
            {
                ctx.sock.EndConnect(ar);
            }
            catch (Exception ex)
            {
                ctx.task.SetException(ex);
                return;
            }

            //Set result
            ctx.task.SetResult(new TcpTransaction(ctx.sock));
        }

        struct AsyncConnectContext
        {
            public Socket sock;
            public TaskCompletionSource<IMsacTransportTransaction> task;
        }

        class TcpTransaction : IMsacTransportTransaction
        {
            public TcpTransaction(Socket sock)
            {
                this.sock = sock;
            }

            private readonly Socket sock;

            public Task SendAsync(byte[] data, int index, int length)
            {
                //Create the task completion source
                TaskCompletionSource<int> task = new TaskCompletionSource<int>();

                //Begin send in the background
                sock.BeginSend(data, index, length, SocketFlags.None, OnSendFinished, task);

                //Return the task
                return task.Task;
            }

            private void OnSendFinished(IAsyncResult ar)
            {
                //Get context
                TaskCompletionSource<int> task = (TaskCompletionSource<int>)ar.AsyncState;

                //Finish send
                int count;
                try
                {
                    count = sock.EndSend(ar);
                }
                catch (Exception ex)
                {
                    task.SetException(ex);
                    return;
                }

                //Set OK
                task.SetResult(count);
            }

            public Task<int> ReadToEndAsync(byte[] buffer, int index, int length)
            {
                //Create the initial context
                RxContext ctx = new RxContext
                {
                    task = new TaskCompletionSource<int>(),
                    buffer = buffer,
                    bufferIndex = index,
                    bufferRemain = length,
                    read = 0
                };

                //Begin read
                BeginRead(ctx);

                //Return task
                return ctx.task.Task;
            }

            private void BeginRead(RxContext ctx)
            {
                sock.BeginReceive(ctx.buffer, ctx.bufferIndex, ctx.bufferRemain, SocketFlags.None, OnReadEnd, ctx);
            }

            private void OnReadEnd(IAsyncResult ar)
            {
                //Get context
                RxContext ctx = (RxContext)ar.AsyncState;

                //Finish read
                int count;
                try
                {
                    count = sock.EndReceive(ar);
                }
                catch (Exception ex)
                {
                    ctx.task.SetException(ex);
                    return;
                }

                //Update buffer positions
                ctx.bufferIndex += count;
                ctx.bufferRemain -= count;
                ctx.read += count;

                //If count was zero or the buffer was full, finish
                if (count == 0 || ctx.bufferRemain == 0)
                {
                    ctx.task.SetResult(ctx.read);
                    return;
                }

                //Begin next read
                BeginRead(ctx);
            }

            struct RxContext
            {
                public TaskCompletionSource<int> task;
                public byte[] buffer;
                public int bufferIndex;
                public int bufferRemain;
                public int read;
            }

            public void Dispose()
            {
                sock.Close();
                sock.Dispose();
            }
        }
    }
}
