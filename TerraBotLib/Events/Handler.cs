using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TerraBotLib {
    /// <summary>
    /// Wrappers for events in the program.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Handler<T> where T : EventArgs {
        /// <summary>
        /// The actual event-delegate and its priority.
        /// </summary>
        public class InternalEvent {
            public EventHandler<T> Handler { get; set; }
            public HandlerPriority Priority { get; set; }
        }

        /// <summary>
        /// Synchronizes thread access to this handler or whatever.
        /// </summary>
        private readonly object HandlerLock = new object();

        /// <summary>
        /// List of InternalEvents for this event.
        /// </summary>
        private List<InternalEvent> internalEvents = new List<InternalEvent>();

        /// <summary>
        /// Registers a new listener for the event.
        /// </summary>
        /// <param name="delegato">le doge has arrived</param>
        /// <param name="priority"></param>
        public void Register(EventHandler<T> delegato, HandlerPriority priority = HandlerPriority.Normal) {
            AddInternalEvent(Create(delegato, priority));
        }

        /// <summary>
        /// Adds the actual InternalEvent item to the list of listeners.
        /// </summary>
        /// <param name="internalEvent"></param>
        public void AddInternalEvent(InternalEvent intEve) {
            lock (HandlerLock) {
                internalEvents.Add(intEve);
                internalEvents = internalEvents.OrderBy(i => (int)i.Priority).ToList();
            }
        }

        /// <summary>
        /// Creates an InternalEvent item.
        /// </summary>
        /// <param name="delegato"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public static InternalEvent Create(EventHandler<T> delegato, HandlerPriority priority) {
            return new InternalEvent { Handler = delegato, Priority = priority };
        }

        /// <summary>
        /// Invokes all listeners attached to this event according to their priority.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public bool Invoke(object source, T args) {
            List<InternalEvent> internalEventsCopy;
            lock (HandlerLock) {
                internalEventsCopy = new List<InternalEvent>(internalEvents);
            }

            var hargs = args as HandledEventArgs;
            foreach (var listener in internalEventsCopy) {
                if (!hargs.Handled) {
                    listener.Handler.Invoke(source, args);
                }
            }
            return hargs.Handled;
        }
    }

    public enum HandlerPriority {
        High = 1,
        AboveNormal = 2,
        Normal = 3,
        BelowNormal = 4,
        Low = 5
    }
}
