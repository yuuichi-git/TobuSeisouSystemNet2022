/*
 * 2023-11-10
 */
using H_Common;

using Vo;

namespace H_Dao {
    public class H_CarMasterDao {
        private readonly DefaultValue _defaultValue = new();
        /*
         * Vo
         */
        private readonly ConnectionVo _connectionVo;

        public H_CarMasterDao(ConnectionVo connectionVo) {
            /*
             * Vo
             */
            _connectionVo = connectionVo;

        }


    }
}
