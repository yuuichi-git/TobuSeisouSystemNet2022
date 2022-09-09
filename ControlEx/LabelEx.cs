﻿/*
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
        /// <param name="setLedgerVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(SetLedgerVo setLedgerVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _setLabelHeight;
            Margin = new Padding(2);
            Tag = setLedgerVo;
            Text = string.Concat(setLedgerVo.Set_name_1, "\r\n", setLedgerVo.Set_name_2);
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _setLabelWidth;
            return this;
        }

        /// <summary>
        /// CarLabel作成
        /// </summary>
        /// <param name="carLedgerVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(CarLedgerVo carLedgerVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _carLabelHeight;
            Margin = new Padding(2);
            Tag = carLedgerVo;
            Text = string.Concat(carLedgerVo.Registration_number_1, carLedgerVo.Registration_number_2, "\r\n"
                                    , carLedgerVo.Registration_number_3, carLedgerVo.Registration_number_4, "\r\n"
                                    , carLedgerVo.Disguise_kind_1, carLedgerVo.Door_number);
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _carLabelWidth;
            return this;
        }

        /// <summary>
        /// StaffLabel作成
        /// </summary>
        /// <param name="staffLedgerVo"></param>
        /// <returns></returns>
        public LabelEx CreateLabel(StaffLedgerVo staffLedgerVo) {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Meiryo UI", 11, FontStyle.Regular, GraphicsUnit.Pixel);
            Height = _staffLabelHeight;
            Margin = new Padding(2);
            Tag = staffLedgerVo;
            Text = staffLedgerVo.Display_name;
            TextAlign = ContentAlignment.MiddleCenter;
            Width = _staffLabelWidth;
            return this;
        }
    }
}
