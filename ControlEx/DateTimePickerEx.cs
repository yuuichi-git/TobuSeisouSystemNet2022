namespace ControlEx {
    public partial class DateTimePickerEx : DateTimePicker {
        public DateTimePickerEx() {
            InitializeComponent();
        }



        /// <summary>
        /// SetBrank
        /// 表示をブランクにする
        /// </summary>
        public void SetBrank() {
            //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " ";
        }

    }
}
