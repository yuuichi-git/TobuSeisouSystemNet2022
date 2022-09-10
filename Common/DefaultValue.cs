namespace Common {
    public class DefaultValue {
        public DefaultValue() {
        }
        public T? GetDefaultValue<T>(object? obj) {
            if (obj != null) {
                switch (obj.GetType().Name) {
                    case "DateTime":
                        obj = new DateTime(1900, 01, 01, 00, 00, 00, 000);
                        break;
                    case "String":
                        obj = "";
                        break;
                    default:
                        obj = default;
                        break;
                }
            } else {
                obj = default;
            }
            return (T?)obj;
        }
    }
}
