using System.Text.Json;

namespace Common {
    public class CopyUtility {
        public CopyUtility() {
        }

        public T DeepCopy<T>(T src) {
            string serialize = JsonSerializer.Serialize<T>(src);
            var deserialize = JsonSerializer.Deserialize<T>(serialize);
            return deserialize;
        }
    }
}
