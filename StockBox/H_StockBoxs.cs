/*
 * 2023-12-07
 */
using H_ControlEx;

using H_Vo;

namespace StockBox {
    public partial class H_StockBoxs : Form {
        /*
         * �ϐ���`
         */
        private readonly H_FlowLayoutPanelEx _hFlowLayoutPanelExBase;
        /*
         * Vo
         */
        private List<H_SetMasterVo> _listDeepCopyHSetMasterVo;
        private List<H_CarMasterVo> _listDeepCopyHCarMasterVo;
        private List<H_StaffMasterVo> _listDeepCopyHStaffMasterVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public H_StockBoxs(H_ControlVo hControlVo) {
            /*
             * Vo
             */
            _listDeepCopyHSetMasterVo = hControlVo.ListDeepCopyHSetMasterVo;
            _listDeepCopyHCarMasterVo = hControlVo.ListDeepCopyHCarMasterVo;
            _listDeepCopyHStaffMasterVo = hControlVo.ListDeepCopyHStaffMasterVo;
            /*
             * �R���g���[��������
             */
            InitializeComponent();
            this.AllowDrop = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Location = new Point(26, 84);
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            /*
             * FlowLayoutPanelEx���쐬
             */
            _hFlowLayoutPanelExBase = new H_FlowLayoutPanelEx();
            _hFlowLayoutPanelExBase.AllowDrop = true;
            _hFlowLayoutPanelExBase.AutoScroll = true;
            _hFlowLayoutPanelExBase.Dock = DockStyle.Fill;
            _hFlowLayoutPanelExBase.Name = "HFlowLayoutPanelExBase";
            _hFlowLayoutPanelExBase.DragEnter += HFlowLayoutPanelExBase_DragEnter;
            _hFlowLayoutPanelExBase.DragDrop += HFlowLayoutPanelExBase_DragDrop;
            h_TableLayoutPanelExBase.Controls.Add(_hFlowLayoutPanelExBase, 0, 1);
        }

        /// <summary>
        /// HFlowLayoutPanelExBase_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExBase_DragEnter(object sender, DragEventArgs e) {
            if(e.Data.GetDataPresent(typeof(H_SetLabel)) || e.Data.GetDataPresent(typeof(H_CarLabel)) || e.Data.GetDataPresent(typeof(H_StaffLabel)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// HFlowLayoutPanelExBase_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExBase_DragDrop(object sender, DragEventArgs e) {
            if(e.Data.GetDataPresent(typeof(H_SetLabel))) {
                H_SetLabel dragItem = (H_SetLabel)e.Data.GetData(typeof(H_SetLabel));
                ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
            }
            if(e.Data.GetDataPresent(typeof(H_CarLabel))) {
                H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
            }
            if(e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
            }
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch(((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemExit": // �A�v���P�[�V�������I������
                    this.Close();
                    break;
                case "ToolStripMenuItemFree": // �t���[
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemSet": // �z�Ԑ�
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    this.CreateHSetLabel(_listDeepCopyHSetMasterVo);
                    break;
                case "ToolStripMenuItemCar": // �ԗ�
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemEmployee": // �Ј�
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemPartTime": // �A���o�C�g
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemLongTerm": // ����
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemShortTerm": // �Z��
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemDispatch": // �h��
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemSortAsc": // ����
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemSortDesk": // �~��
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    break;
                case "ToolStripMenuItemHelp": // �w���v
                    break;
            }
        }

        /// <summary>
        /// ToolStripMenuItemCheckedChange
        /// ToolStripSeparator�����݂��Ă���̂Œ��ӂ���
        /// </summary>
        /// <param name="sender"></param>
        private void ToolStripMenuItemCheckedChange(object sender) {
            foreach(object item in ToolStripMenuItemChange.DropDownItems) {
                if(item.GetType() == typeof(ToolStripMenuItem)) {
                    if(item.Equals(sender)) {
                        ((ToolStripMenuItem)item).Checked = true;
                    } else {
                        ((ToolStripMenuItem)item).Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// FlowLayoutPanelExControlRemove
        /// </summary>
        private void FlowLayoutPanelExControlRemove() {
            /*
             * ���\�b�h�� Clear �Ăяo���Ă��A�R���g���[�� �n���h���̓���������폜����܂���B ������ ���[�N���������ɂ́A ���\�b�h�� Dispose �����I�ɌĂяo���K�v������܂��B
             * ����납�������Ă���_���d�v�炵���B
             */
            for(int i = _hFlowLayoutPanelExBase.Controls.Count - 1; 0 <= i; i--)
                _hFlowLayoutPanelExBase.Controls[i].Dispose();
        }

        /// <summary>
        /// CreateHSetLabel
        /// </summary>
        /// <param name="listDeepCopyHSetMasterVo"></param>
        private void CreateHSetLabel(List<H_SetMasterVo> listDeepCopyHSetMasterVo) {

        }

        /// <summary>
        /// CreateHCarLabel
        /// </summary>
        /// <param name="listDeepCopyHCarMasterVo"></param>
        private void CreateHCarLabel(List<H_CarMasterVo> listDeepCopyHCarMasterVo) {

        }

        /// <summary>
        /// CreateHStaffLabel
        /// </summary>
        /// <param name="listDeepCopyHStaffMasterVo"></param>
        private void CreateHStaffLabel(List<H_StaffMasterVo> listDeepCopyHStaffMasterVo) {

        }

        /// <summary>
        /// SetStockBox_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetStockBox_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
