﻿using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerEx : DateTimePicker {
        private string _customFormat;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DateTimePickerEx() {
            _customFormat = "yyyy年MM月dd日(dddd)";
            InitializeComponent();
            /*
             * カスタムに設定
             */
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = _customFormat;
            /*
             * イベントを登録
             */
            this.KeyPress += new KeyPressEventHandler(this.DateTimePickerEx_KeyPress);
        }

        /// <summary>
        /// DateTimePickerEx_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerEx_KeyPress(object? sender, KeyPressEventArgs e) {
            if((e.KeyChar & (char)Keys.Escape) == (char)Keys.Escape) {
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            } else {
                this.CustomFormat = string.Concat(" ", _customFormat);
                this.Refresh();
                return;
            }
        }

        /// <summary>
        /// GetValue
        /// ブランクの場合、_DefaultDateTimeで返す
        /// </summary>
        /// <returns></returns>
        public DateTime GetValue() {
            if(this.CustomFormat != " ") {
                return this.Value;
            } else {
                return new DateTime(1900,01,01,00,00,00);
            }
        }

        /// <summary>
        /// GetJpValue
        /// 和暦表記をstringで返す
        /// </summary>
        /// <returns></returns>
        public string GetJpValue() {
            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            string jpDate = this.Value.ToString("gg y年", Japanese);
            return jpDate;
        }
    }
}
