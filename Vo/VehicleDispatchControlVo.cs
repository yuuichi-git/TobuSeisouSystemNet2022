namespace Vo {
    public class VehicleDispatchControlVo {
        private int _column;
        private int _row;
        private bool _setFlag;
        private bool _stopCarFlag;
        private bool _garageFlag;
        private int _productionNumberOfPeople;
        private SetLedgerVo? _setLedgerVo;
        private CarLedgerVo? _carLedgerVo;
        private StaffLedgerVo?[] _arrayStaffLedgerVo = new StaffLedgerVo[4];

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VehicleDispatchControlVo() {
            _column = default;
            _row = default;
            _setFlag = default;
            _stopCarFlag = default;
            _garageFlag = default;
            _productionNumberOfPeople = default;
            _setLedgerVo = default;
            _carLedgerVo = default;
            _arrayStaffLedgerVo[0] = default;
            _arrayStaffLedgerVo[1] = default;
            _arrayStaffLedgerVo[2] = default;
            _arrayStaffLedgerVo[3] = default;
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
        /// 休車フラグ
        /// true:休車 false:配車
        /// </summary>
        public bool StopCarFlag {
            get => _stopCarFlag;
            set => _stopCarFlag = value;
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
        public SetLedgerVo? SetLedgerVo {
            get => _setLedgerVo;
            set => _setLedgerVo = value;
        }
        /// <summary>
        /// CarLedgerVo
        /// </summary>
        public CarLedgerVo? CarLedgerVo {
            get => _carLedgerVo;
            set => _carLedgerVo = value;
        }
        /// <summary>
        /// StaffLedgerVo
        /// </summary>
        public StaffLedgerVo?[] ArrayStaffLedgerVo {
            get => _arrayStaffLedgerVo;
            set => _arrayStaffLedgerVo = value;
        }
    }
}
