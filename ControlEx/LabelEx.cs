/*
 * 
 */
using Vo;

namespace ControlEx {
    public partial class LabelEx : Label {
        private const int _setLabelHeight = 68;
        private const int _setLabelWidth = 70;
        private const int _carLabelHeight = 68;
        private const int _carLabelWidth = 70;
        private const int _staffLabelHeight = 38;
        private const int _staffLabelWidth = 70;

        public LabelEx() {
            InitializeComponent();
        }

        /// <summary>
        /// SetLabel作成
        /// </summary>
        /// <param name="setMasterVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(SetMasterVo setMasterVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _setLabelHeight;
            Margin = new Padding(2);
            Tag = setMasterVo;
            Text = string.Concat(setMasterVo.Set_name_1, "\r\n", setMasterVo.Set_name_2);
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _setLabelWidth;
            return this;
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carMasterVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(CarMasterVo carMasterVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _carLabelHeight;
            Margin = new Padding(2);
            Tag = carMasterVo;
            Text = string.Concat(carMasterVo.Registration_number_1, carMasterVo.Registration_number_2, "\r\n"
                                    , carMasterVo.Registration_number_3, carMasterVo.Registration_number_4, "\r\n"
                                    , carMasterVo.Disguise_kind_1, carMasterVo.Door_number);
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _carLabelWidth;
            return this;
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="staffMasterVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(StaffMasterVo staffMasterVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _staffLabelHeight;
            Margin = new Padding(2);
            Tag = staffMasterVo;
            Text = staffMasterVo.Display_name;
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _staffLabelWidth;
            return this;
        }
    }
}
