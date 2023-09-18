/*
 * 2023-09-14
 * Listから重複を取り除くメソッド
 * https://qiita.com/gcs-bright/items/bb8009b4cdb758fc7ceb#:~:text=var%20collection%20%3D%20new%20List%3Cstring%3E%20%7B%20%22%E4%BD%90%E8%97%A4%22%2C%20%22%E4%BD%90%E3%80%85%E6%9C%A8%22%2C,a%20new%20user%20and%20use%20Qiita%20more%20conveniently
 */
namespace Common {
    public static class EnumerableExtension {
        /// <summary>
        /// 重複をチェックする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static bool HasDuplicate<T, Tkey>(this IEnumerable<T> source, Func<T, Tkey> keySelector)
            => source.GroupBy(keySelector).Any(s => s.Skip(1).Any());

        /// <summary>
        /// 重複を除去する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctByKey<T, Tkey>(this IEnumerable<T> source, Func<T, Tkey> keySelector)
            => source.GroupBy(keySelector).Select(s => s.First());
    }
}
