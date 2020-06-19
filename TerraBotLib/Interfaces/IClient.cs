using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TerraBotLib.Events;

namespace TerraBotLib {
    public interface IClient {
        void QueuePackets(params IPacket[] packet);

        bool CanSendPackets { get; }

        bool Running { get; }

        void Start();

        void Stop();
    }
}
