using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraBotLib.Events;
using System.Threading.Tasks;

namespace TerraBotLib {
    public interface IBot {
        Hooks EventHooks { get; }

        IClient Client { get; }

        AdditionalBotData AdditionalData { get; }

        
    }
}
