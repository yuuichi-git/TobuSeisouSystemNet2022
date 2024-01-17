/*
 * 2023-12-07
 */
using H_Common;

using H_ControlEx;

using H_Vo;

namespace StockBox {
    public partial class H_StockBoxs : Form {
        /*
         * �ϐ���`
         */
        private H_FlowLayoutPanelEx _hFlowLayoutPanelExBase;
        /*
         * Vo
         */
        private readonly H_ControlVo _hControlVo;
        private readonly List<H_SetMasterVo> _temporaryRemoveListHSetMasterVo;
        private readonly List<H_CarMasterVo> _temporaryRemoveListHCarMasterVo;
        private readonly List<H_StaffMasterVo> _temporaryRemoveListHStaffMasterVo;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public H_StockBoxs(H_ControlVo hControlVo) {
            /*
             * Vo
             */
            _hControlVo = hControlVo;
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
            _hFlowLayoutPanelExBase.Name = "H_FlowLayoutPanelExBase";
            _hFlowLayoutPanelExBase.DragEnter += HFlowLayoutPanelExBase_DragEnter;
            _hFlowLayoutPanelExBase.DragDrop += HFlowLayoutPanelExBase_DragDrop;
            h_TableLayoutPanelExBase.Controls.Add(_hFlowLayoutPanelExBase, 0, 1);
            /*
             * DeepCopy���ꎞ�ۊ�
             */
            _temporaryRemoveListHSetMasterVo = new CopyUtility().DeepCopy(hControlVo.RemoveListHSetMasterVo);
            _temporaryRemoveListHCarMasterVo = new CopyUtility().DeepCopy(hControlVo.RemoveListHCarMasterVo);
            _temporaryRemoveListHStaffMasterVo = new CopyUtility().DeepCopy(hControlVo.RemoveListHStaffMasterVo);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
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
                    _hControlVo.RemoveListHSetMasterVo = _temporaryRemoveListHSetMasterVo.FindAll(x => x.ClassificationCode != 10 && x.ClassificationCode != 11 && x.DeleteFlag == false);
                    this.CreateHSetLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemCar": // �ԗ�
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHCarMasterVo = _temporaryRemoveListHCarMasterVo.FindAll(x => x.DeleteFlag == false);
                    this.CreateHCarLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemEmployee": // �Ј�
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 10 || x.Belongs == 11 || (x.Belongs == 12 && x.Occupation == 20)) && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemPartTime": // �A���o�C�g
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => x.Belongs == 12 && x.Occupation != 20 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemLongTerm": // ����
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.JobForm == 10 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemShortTerm": // �Z��
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.JobForm == 11 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemDispatch": // �h��
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => x.Belongs == 13 && x.JobForm == 99 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
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
        /// CreateHSetLabel 
        /// </summary>
        /// <param name="hControlVo"></param>
        private void CreateHSetLabel(H_ControlVo hControlVo) {
            foreach (H_SetMasterVo hSetMasterVo in hControlVo.RemoveListHSetMasterVo.OrderBy(x => x.ClassificationCode).ThenBy(x => x.SetName)) {
                if (hSetMasterVo is not null && hSetMasterVo.SetCode != 0) {
                    hControlVo.HSetMasterVo = hSetMasterVo;
                    H_SetLabel hSetLabel = new(hControlVo);
                    hSetLabel.MouseClick += HSetLabel_MouseClick;
                    hSetLabel.MouseDoubleClick += HSetLabel_MouseDoubleClick;
                    hSetLabel.MouseMove += HSetLabel_MouseMove;
                    _hFlowLayoutPanelExBase.Controls.Add(hSetLabel); // SetLabel��ǉ�
                }
            }
        }

        /// <summary>
        /// CreateHCarLabel
        /// </summary>
        /// <param name="listHCarMasterVo"></param>
        private void CreateHCarLabel(H_ControlVo hControlVo) {
            foreach (H_CarMasterVo hCarMasterVo in hControlVo.RemoveListHCarMasterVo.OrderBy(x => x.ClassificationCode).ThenBy(x => x.DoorNumber)) {
                if (hCarMasterVo is not null && hCarMasterVo.CarCode != 0) {
                    hControlVo.HCarMasterVo = hCarMasterVo;
                    H_CarLabel hCarLabel = new(hControlVo);
                    hCarLabel.MouseClick += HCarLabel_MouseClick;
                    hCarLabel.MouseDoubleClick += HCarLabel_MouseDoubleClick;
                    hCarLabel.MouseMove += HCarLabel_MouseMove;
                    _hFlowLayoutPanelExBase.Controls.Add(hCarLabel); // CarLabel��ǉ�
                }
            }
        }

        /// <summary>
        /// CreateHStaffLabel
        /// </summary>
        /// <param name="listHStaffMasterVo"></param>
        private void CreateHStaffLabel(H_ControlVo hControlVo) {
            foreach (H_StaffMasterVo hStaffMasterVo in hControlVo.RemoveListHStaffMasterVo.OrderBy(x => x.NameKana)) {
                if (hStaffMasterVo is not null && hStaffMasterVo.StaffCode != 0) {
                    hControlVo.HStaffMasterVo = hStaffMasterVo;
                    H_StaffLabel hStaffLabel = new(hControlVo);
                    hStaffLabel.MouseClick += HStaffLabel_MouseClick;
                    hStaffLabel.MouseDoubleClick += HStaffLabel_MouseDoubleClick;
                    hStaffLabel.MouseMove += HStaffLabel_MouseMove;
                    _hFlowLayoutPanelExBase.Controls.Add(hStaffLabel); // StaffLabel��ǉ�
                }
            }
        }

        /*
         * H_SetLabelEx
         */
        private void HSetLabel_MouseClick(object sender, MouseEventArgs e) {
        }
        private void HSetLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
        }
        private void HSetLabel_MouseMove(object sender, MouseEventArgs e) {
            H_SetLabel hSetLabel = (H_SetLabel)sender;
            if (e.Button == MouseButtons.Left) {
                if (((H_SetMasterVo)hSetLabel.Tag).MoveFlag)
                    hSetLabel.DoDragDrop(sender, DragDropEffects.All);
            }
        }

        /*
         * H_CarLabelEx
         */
        private void HCarLabel_MouseClick(object sender, MouseEventArgs e) {
        }
        private void HCarLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
        }
        private void HCarLabel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ((H_CarLabel)sender).DoDragDrop(sender, DragDropEffects.All);
            }
        }

        /*
         * H_StaffLabelEx
         */
        private void HStaffLabel_MouseClick(object sender, MouseEventArgs e) {
        }
        private void HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
        }
        private void HStaffLabel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ((H_StaffLabel)sender).DoDragDrop(sender, DragDropEffects.All);
            }
        }

        /// <summary>
        /// HFlowLayoutPanelExBase_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExBase_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
                //e.Effect = DragDropEffects.Move;
            } else if (e.Data.GetDataPresent(typeof(H_CarLabel)) || e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// HFlowLayoutPanelExBase_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HFlowLayoutPanelExBase_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(H_SetLabel))) {
            }
            if (e.Data.GetDataPresent(typeof(H_CarLabel))) {
                H_CarLabel dragItem = (H_CarLabel)e.Data.GetData(typeof(H_CarLabel));
                ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
            }
            if (e.Data.GetDataPresent(typeof(H_StaffLabel))) {
                H_StaffLabel dragItem = (H_StaffLabel)e.Data.GetData(typeof(H_StaffLabel));
                ((H_FlowLayoutPanelEx)sender).Controls.Add(dragItem);
            }
        }

        /// <summary>
        /// ToolStripMenuItemCheckedChange
        /// ToolStripSeparator�����݂��Ă���̂Œ��ӂ���
        /// </summary>
        /// <param name="sender"></param>
        private void ToolStripMenuItemCheckedChange(object sender) {
            foreach (object item in ToolStripMenuItemChange.DropDownItems) {
                if (item.GetType() == typeof(ToolStripMenuItem)) {
                    if (item.Equals(sender)) {
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
            for (int i = _hFlowLayoutPanelExBase.Controls.Count - 1; 0 <= i; i--)
                _hFlowLayoutPanelExBase.Controls[i].Dispose();
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
