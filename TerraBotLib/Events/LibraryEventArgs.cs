using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using TShockAPI;

namespace TerraBotLib.Events {
    public class Hooks {
        public Handler<CreateBotEventArgs> BotCreate { get; private set; } = new Handler<CreateBotEventArgs>();
        public Handler<DeleteBotEventArgs> BotDelete { get; private set; } = new Handler<DeleteBotEventArgs>();
        public Handler<StartEventArgs> ClientStart { get; private set; } = new Handler<StartEventArgs>();
        public Handler<StopEventArgs> ClientStop { get; private set; } = new Handler<StopEventArgs>();
        public Handler<PacketSentEventArgs> ClientSendPacket { get; private set; } = new Handler<PacketSentEventArgs>();
        public Handler<EventArgs> Update { get; private set; } = new Handler<EventArgs>();

        #region Field Changes
        public Handler<PortChangedEventArgs> PortChange { get; private set; } = new Handler<PortChangedEventArgs>();
        public Handler<NameChangedEventArgs> NameChange { get; private set; } = new Handler<NameChangedEventArgs>();
        public Handler<OwnerChangedEventArgs> OwnerChange { get; private set; } = new Handler<OwnerChangedEventArgs>();
        public Handler<PositionChangedEventArgs> PositionChange { get; private set; } = new Handler<PositionChangedEventArgs>();
        public Handler<OwnerIndexChangedEventArgs> OwnedIndexChange { get; private set; } = new Handler<OwnerIndexChangedEventArgs>();
        public Handler<InventoryChangedEventArgs> InventoryChange { get; private set; } = new Handler<InventoryChangedEventArgs>();
        #endregion

    }
    /// <summary>
    /// Used when a bot is created.
    /// </summary>
    public class CreateBotEventArgs : HandledEventArgs {
        /// <summary>
        /// The player, if applicable, that created the bot.
        /// </summary>
        public int WhoAsked { get; set; }

        /// <summary>
        /// A reference to the bot being created.
        /// </summary>
        public IBot Bot { get; set; }
    }

    /// <summary>
    /// Used when a bot is deleted.
    /// </summary>
    public class DeleteBotEventArgs : HandledEventArgs {
        /// <summary>
        /// The player, if applicable, that deleted the bot.
        /// </summary>
        public int WhoAsked { get; set; }

        /// <summary>
        /// A reference to the bot being deleted.
        /// </summary>
        public IBot Bot { get; set; }
    }

    /// <summary>
    /// Used when a bot is requested to be started.
    /// </summary>
    public class StartEventArgs : HandledEventArgs {
        /// <summary>
        /// The port of the server the bot is joining.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The player, if applicable, that started the bot.
        /// </summary>
        public int WhoAsked { get; set; }

        /// <summary>
        /// A reference to the bot being deleted.
        /// </summary>
        public IBot Bot { get; set; }
    }

    /// <summary>
    /// Used when a bot is requested to be stopped.
    /// </summary>
    public class StopEventArgs : HandledEventArgs {
        /// <summary>
        /// The port of the server the bot is leaving.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The player, if applicable, that stopped the bot.
        /// </summary>
        public int WhoAsked { get; set; }

        /// <summary>
        /// A reference to the bot being deleted.
        /// </summary>
        public IBot Bot { get; set; }
    }

    /// <summary>
    /// Used when a bot sends a packet through its client.
    /// </summary>
    public class PacketSentEventArgs : HandledEventArgs {
        /// <summary>
        /// The port of the server the packets are being sent from.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The sent packet in the form of a byte array.
        /// </summary>
        public byte[] PacketData { get; set; }

        /// <summary>
        /// A reference to the sent packet.
        /// </summary>
        public IPacket Packet { get; set; }
    }

    /// <summary>
    /// Used when a bot's client's port is changed.
    /// </summary>
    public class PortChangedEventArgs : HandledEventArgs {
        /// <summary>
        /// The old port used.
        /// </summary>
        public int OldPort { get; set; }

        /// <summary>
        /// The new port given.
        /// </summary>
        public int NewPort { get; set; }
    }

    /// <summary>
    /// Used when a bot's name is changed.
    /// </summary>
    public class NameChangedEventArgs : HandledEventArgs {
        /// <summary>
        /// The old name used.
        /// </summary>
        public string OldName { get; set; }

        /// <summary>
        /// The new name given.
        /// </summary>
        public string NewName { get; set; }
    }

    /// <summary>
    /// Used when a bot's owner changes.
    /// </summary>
    public class OwnerChangedEventArgs : HandledEventArgs {
        /// <summary>
        /// The old owner used.
        /// </summary>
        public int OldOwner { get; set; }

        /// <summary>
        /// The new owner given.
        /// </summary>
        public int NewOwner { get; set; }
    }

    /// <summary>
    /// Used when a bot's position changes.
    /// </summary>
    public class PositionChangedEventArgs : HandledEventArgs {
        public Vector2 OldPosition { get; set; }

        public Vector2 NewPosition { get; set; }
    }

    /// <summary>
    /// Used when a bot's index in its owner's owned bots changes.
    /// </summary>
    public class OwnerIndexChangedEventArgs : HandledEventArgs {
        public int OldIndex { get; set; }

        public int NewIndex { get; set; }
    }

    /// <summary>
    /// Used when a bot's inventory is changed.
    /// </summary>
    public class InventoryChangedEventArgs : HandledEventArgs {
        public int Slot { get; set; }

        public NetItem OldItem { get; set; }

        public NetItem NewItem { get; set; }
    }
}

