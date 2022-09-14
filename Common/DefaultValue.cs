namespace Common {
    public class DefaultValue {

        /// <summary>
        /// DBからのobjectを変換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T GetDefaultValue<T>(object obj) {
            object objectValue = new();
            if (obj != DBNull.Value && obj != null) {
                return (T)obj;
            } else { // objがNullだった場合
                switch (typeof(T).Name) {
                    case "DateTime":
                        objectValue = new DateTime(1900, 01, 01, 00, 00, 00, 000);
                        break;
                    case "Int32":
                        objectValue = 0;
                        break;
                    case "String":
                        objectValue = "";
                        break;
                }
            }
            return (T)objectValue;
        }
    }
}
