using System.Text.Json;

namespace Common {
    public class CopyUtility {

        public T? DeepCopy<T>(T source) {
            string serialize = JsonSerializer.Serialize<T>(source);
            var deserialize = JsonSerializer.Deserialize<T>(serialize);
            return deserialize;
        }
    }
}
