using System.Text.Json;

namespace Common {
    public class CopyUtility {

        /// <summary>
        /// DeepCopy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public T? DeepCopy<T>(T source) {
            string serialize = JsonSerializer.Serialize<T>(source);
            var deserialize = JsonSerializer.Deserialize<T>(serialize);
            return deserialize;
        }
    }
}
