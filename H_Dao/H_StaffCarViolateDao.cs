/*
 * 2024-02-03
 */
using H_Common;

using Vo;
/*
 * 2024-02-03
 */
namespace H_Dao {
    public class H_StaffCarViolateDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_StaffCarViolateDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;
        }
    }
}
