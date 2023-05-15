﻿/*
 * 2023-05-12
 */
using System.Globalization;

namespace ControlEx {
    public partial class DateTimePickerJpEx : DateTimePicker {
        // 言語カルチャーを設定
        private readonly CultureInfo Japanese = new("Ja-JP", true);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DateTimePickerJpEx() {
            /*
             * Controlを初期化
             */
            InitializeComponent();
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " ";

            ToolTip toolTip = new();
            toolTip.InitialDelay = 500; // ToolTipが表示されるまでの時間
            toolTip.ReshowDelay = 1000; // ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            toolTip.AutoPopDelay = 10000; // ToolTipを表示する時間
            toolTip.SetToolTip(this, "Press 'ESC-key' brank");
            /*
             * イベントを登録
             */
            this.ValueChanged += new EventHandler(this.DateTimePickerJpEx_ValueChanged);
            this.KeyPress += new KeyPressEventHandler(this.DateTimePickerJpEx_KeyPress);
        }

        /// <summary>
        /// DateTimePickerJpEx_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx_ValueChanged(object? sender, EventArgs e) {
            this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy", Japanese) + "年MM月dd日(dddd)");
        }

        /// <summary>
        /// DateTimePickerJpEx_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerJpEx_KeyPress(object? sender, KeyPressEventArgs e) {
            if((e.KeyChar & (char)Keys.Escape) == (char)Keys.Escape) {
                this.Value = new DateTime(1900, 01, 01, 0, 00, 00);
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            } else {
                this.CustomFormat = string.Concat(" ", this.Value.ToString("ggyy", Japanese) + "年MM月dd日(dddd)");
                this.Value = DateTime.Now;
                this.Refresh();
                return;
            }
        }

        /// <summary>
        /// PutValue
        /// Value値を設定する
        /// 1900-01-01の場合はブランクを表示する
        /// </summary>
        /// <param name="dateTime"></param>
        public void PutValue(DateTime dateTime) {
            if(dateTime.Date != new DateTime(1900, 01, 01) || this.CustomFormat != " ") {
                this.Value = dateTime;
                this.CustomFormat = string.Concat(" ", dateTime.ToString("ggyy", Japanese) + "年MM月dd日(dddd)");
                this.Refresh();
            } else {
                this.Value = new DateTime(1900, 01, 01, 0, 00, 00);
                this.CustomFormat = string.Concat(" ");
                this.Refresh();
            }

        }
    }
}
