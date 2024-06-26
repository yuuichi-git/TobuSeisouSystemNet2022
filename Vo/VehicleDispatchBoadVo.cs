﻿namespace Vo {
    public class VehicleDispatchBoadVo {
        private int _column;
        private int _row;
        private bool _setFlag;
        private bool _operationFlag;
        private bool _garageFlag;
        private int _productionNumberOfPeople;
        private SetMasterVo _setMasterVo = new();
        private CarMasterVo _carMasterVo = new();
        private StaffMasterVo[] _arrayStaffMasterVo = new StaffMasterVo[4];

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VehicleDispatchBoadVo() {
            _column = default;
            _row = default;
            _setFlag = default;
            _operationFlag = default;
            _garageFlag = default;
            _productionNumberOfPeople = default;
        }

        /// <summary>
        /// Column(表示位置)
        /// </summary>
        public int Column {
            get => _column;
            set => _column = value;
        }
        /// <summary>
        /// Row(表示位置)
        /// </summary>
        public int Row {
            get => _row;
            set => _row = value;
        }
        /// <summary>
        /// 表示フラグ
        /// true:表示 false:非表示
        /// </summary>
        public bool SetFlag {
            get => _setFlag;
            set => _setFlag = value;
        }
        /// <summary>
        /// 稼働フラグ
        /// true:稼働 false:休車
        /// </summary>
        public bool OperationFlag {
            get => _operationFlag;
            set => _operationFlag = value;
        }
        /// <summary>
        /// 車庫地
        /// true:足立 false:三郷
        /// </summary>
        public bool GarageFlag {
            get => _garageFlag;
            set => _garageFlag = value;
        }
        /// <summary>
        /// 本番人数
        /// </summary>
        public int ProductionNumberOfPeople {
            get => _productionNumberOfPeople;
            set => _productionNumberOfPeople = value;
        }
        /// <summary>
        /// SetLedgerVo
        /// </summary>
        public SetMasterVo SetMasterVo {
            get => _setMasterVo;
            set => _setMasterVo = value;
        }
        /// <summary>
        /// CarLedgerVo
        /// </summary>
        public CarMasterVo CarMasterVo {
            get => _carMasterVo;
            set => _carMasterVo = value;
        }
        /// <summary>
        /// StaffLedgerVo
        /// </summary>
        public StaffMasterVo[] ArrayStaffMasterVo {
            get => _arrayStaffMasterVo;
            set => _arrayStaffMasterVo = value;
        }
    }
}
