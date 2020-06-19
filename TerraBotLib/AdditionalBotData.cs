using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraBotLib {
    public class AdditionalBotData {
        private ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public void SetData<T>(string key, T value) {
            if (!data.TryAdd(key, value)) {
                data.TryUpdate(key, value, data[key]);
            }
        }

        public bool GetData<T>(string key, out T value) {
            bool containsData = data.TryGetValue(key, out object val);
            value = (T)val;
            return containsData;
        }

        public bool CheckData(string key) {
            return data.ContainsKey(key);
        }

        public bool PopData<T>(string key, out T value) {
            bool containsData = data.TryRemove(key, out object val);
            value = (T)val;
            return containsData;
        }

        public bool DeleteData(string key) {
            return data.TryRemove(key, out object disposed);
        }
    }
}
