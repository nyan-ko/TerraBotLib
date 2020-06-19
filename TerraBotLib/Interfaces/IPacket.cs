using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraBotLib {
    public interface IPacket {
        IClient Sender { get; set; }

        short TotalLength { get; }

        byte Type { get; }

        byte[] Data { get; }

        void Send();
    }
}
