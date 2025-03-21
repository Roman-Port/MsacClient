using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Console
{
    enum ConnectionStatus
    {
        DISCONNECTED,
        CONNECTING,
        CONNECTED,
        PROCESSING_COMMAND
    }
}
