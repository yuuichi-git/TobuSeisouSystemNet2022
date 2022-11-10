using Common;

using Vo;

namespace Dao {
    public class VehicleDispatchDetailCarDao {
        private ConnectionVo _connectionVo;
        private readonly DefaultValue _defaultValue = new();

        public VehicleDispatchDetailCarDao() {
            _connectionVo = new ConnectionVo();
        }

        public int InsertCar(DateTime operationDate, int dropCellNumber) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();

            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        public int UpdateCar(DateTime operationDate) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();

            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }

        public int DeleteCar(DateTime operationDate, int dragCellNumber, int dragCarCode) {
            var sqlCommand = _connectionVo.Connection.CreateCommand();

            try {
                return sqlCommand.ExecuteNonQuery();
            } catch {
                throw;
            }
        }
    }
}
