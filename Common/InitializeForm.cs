/*
 * 2022/08/21
 */
namespace Common {
    public  class InitializeForm {
        private const float TopWidthMaxSize = 82F;
        private const float TopWidthMinSize = 0F;
        private const float LeftWidthMaxSize = 34F;
        private const float LeftWidthMinSize = 0F;
        private const float RightWidthMaxSize = 34F;
        private const float RightWidthMinSize = 0F;

        /// <summary>
        /// StartProject
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form StartProject(Form form) {
            form.StartPosition = FormStartPosition.CenterScreen;
            return form;
        }

        /// <summary>
        /// VehicleDispatchBoad
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form VehicleDispatchBoad(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// VehicleDispatchSheet
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form VehicleDispatchSheet(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// ProductionList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form ProductionList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// StaffList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form StaffList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// StaffDetail
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form StaffDetail(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// StaffPaper
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form StaffPaper(Form form) {
            form.Height = Screen.GetWorkingArea(form).Height;
            form.KeyPreview = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Width = 1650;

            form.Text = string.Concat(form.Text, "　(", form.Width, "×", form.Height, ")");
            return form;
        }

        /// <summary>
        /// LicenseList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form LicenseList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// CarAccidentList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form CarAccidentList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// CarAccidentDetail
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form CarAccidentDetail(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// CarList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form CarList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// CarPaper
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form CarPaper(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// CommuterInsuranceList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form CommuterInsuranceList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        // StaffExcel
        public Form StaffExcel(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(1920, 1080);
            form.MinimumSize = new Size(1920, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// SubstitutePaper
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form SubstitutePaper(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(833, 1080);
            form.MinimumSize = new Size(833, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// AccountingParttimeList
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Form AccountingParttimeList(Form form) {
            form.KeyPreview = true;
            form.MaximumSize = new Size(865, 1080);
            form.MinimumSize = new Size(865, 1048);
            GetWorkingArea(form);
            return form;
        }

        /// <summary>
        /// アプリケーションが開かれる画面のワークエリアを返す
        /// FHDでの最小サイズ(1920*1048)
        /// </summary>
        /// <param name="form"></param>
        public void GetWorkingArea(Form form) {
            form.Height = Screen.GetWorkingArea(form).Height;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = string.Concat(form.Text, "　(", form.Width, "×", form.Height, ")");
            form.Width = Screen.GetWorkingArea(form).Width;
        }

        /// <summary>
        /// SetTableLayoutPanelAll
        /// </summary>
        /// <param name="tableLayoutPanel"></param>
        /// <param name="flag"></param>
        public void SetTableLayoutPanelAll(TableLayoutPanel tableLayoutPanel, bool flag) {
            //レイアウトロジックを停止する
            tableLayoutPanel.SuspendLayout();
            SetTableLayoutPanelTop(tableLayoutPanel, flag);
            SetTableLayoutPanelLeft(tableLayoutPanel, flag);
            SetTableLayoutPanelRight(tableLayoutPanel, flag);
            //レイアウトロジックを再開する
            tableLayoutPanel.ResumeLayout();
        }

        /// <summary>
        /// SetTableLayoutPanelTop
        /// </summary>
        /// <param name="tableLayoutPanel"></param>
        /// <param name="flag"></param>
        public void SetTableLayoutPanelTop(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, flag ? TopWidthMaxSize : TopWidthMinSize);
        }

        /// <summary>
        /// SetTableLayoutPanelLeft
        /// </summary>
        /// <param name="tableLayoutPanel"></param>
        /// <param name="flag"></param>
        public void SetTableLayoutPanelLeft(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, flag ? LeftWidthMaxSize : LeftWidthMinSize);
        }

        /// <summary>
        /// SetTableLayoutPanelRight
        /// </summary>
        /// <param name="tableLayoutPanel"></param>
        /// <param name="flag"></param>
        public void SetTableLayoutPanelRight(TableLayoutPanel tableLayoutPanel, bool flag) {
            tableLayoutPanel.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, flag ? RightWidthMaxSize : RightWidthMinSize);
        }
    }
}
