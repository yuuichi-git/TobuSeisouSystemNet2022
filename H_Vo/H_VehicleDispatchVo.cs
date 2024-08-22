/*
 * 2023-11-11
 * HeadとBodyを結合した配車データ
 */
namespace H_Vo {
    public class H_VehicleDispatchVo {
        private int _cellNumber; // Head
        private int _setCode; // Head
        private int _carCode; // Body
        private int _staffCode1; // Body
        private int _staffCode2; // Body
        private int _staffCode3; // Body
        private int _staffCode4; // Body

        public H_VehicleDispatchVo() {
            _cellNumber = 0; // Head
            _setCode = 0; // Head
            _carCode = 0; // Body
            _staffCode1 = 0; // Body
            _staffCode2 = 0; // Body
            _staffCode3 = 0; // Body
            _staffCode4 = 0; // Body
        }

        public int CellNumber {
            get => _cellNumber;
            set => _cellNumber = value;
        }
        public int SetCode {
            get => _setCode;
            set => _setCode = value;
        }
        public int CarCode {
            get => _carCode;
            set => _carCode = value;
        }
        public int StaffCode1 {
            get => _staffCode1;
            set => _staffCode1 = value;
        }
        public int StaffCode2 {
            get => _staffCode2;
            set => _staffCode2 = value;
        }
        public int StaffCode3 {
            get => _staffCode3;
            set => _staffCode3 = value;
        }
        public int StaffCode4 {
            get => _staffCode4;
            set => _staffCode4 = value;
        }
    }
}
