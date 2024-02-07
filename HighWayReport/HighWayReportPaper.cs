using ControlEx;

using FarPoint.Win.Spread;

using H_Vo;

namespace HighWayReport {
    public partial class HighWayReportPaper : Form {
        private readonly SetMasterVo _setMasterVo;
        private readonly CarMasterVo? _carMasterVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public HighWayReportPaper(SetControlEx setControlEx) {
            /*
             * SetMasterVo���擾
             * ContextMenu����̏�񂾂���K��SetMasterVo�͑��݂���
             */
            _setMasterVo = (SetMasterVo)((SetLabelEx)setControlEx.GetControlFromPosition(0, 0)).Tag;
            _carMasterVo = (CarMasterVo)((CarLabelEx)setControlEx.GetControlFromPosition(0, 1)).Tag;

            InitializeComponent();

            SheetViewReport.Cells[1, 15].Value = DateTime.Now;
            SheetViewReport.Cells[11, 1].Text = string.Concat(_setMasterVo.Set_name_1, "\r\n", _setMasterVo.Set_name_2);
            SheetViewReport.Cells[11, 2].Text = string.Concat(_carMasterVo.Registration_number);

            // �V�[�g
            SpreadReport.TabStripPolicy = TabStripPolicy.Never;
            // �X�e�[�^�X�o�[
            ToolStripStatusLabelStatus.Text = "";
        }

        /// <summary>
        /// �G���g���[�|�C���g
        /// </summary>
        public static void Main() {
        }

        private void ButtonUpdate_Click(object sender, EventArgs e) {
            // �V�[�g��������܂��B
            SpreadReport.PrintSheet(SheetViewReport);
        }
    }
}