using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Entities
{
    public enum SyncSendTriggerType
    {
        Passive, // Default; The startTime attribute sets start time
        Active // A SYNC EVENT message is required to send this, within 15 minutes
    }
}
