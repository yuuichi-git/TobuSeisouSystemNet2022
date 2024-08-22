/*
 * 2023-12-07
 */
using H_ControlEx;

using H_Utility;

using H_Vo;

namespace H_StockBox {
    public partial class H_StockBoxs : Form {
        /*
         * 変数定義
         */
        private readonly H_FlowLayoutPanelEx _hFlowLayoutPanelExStockBoxs;
        private readonly H_ArrayUtility _hArrayUtility = new();
        /*
         * Vo
         */
        private readonly H_ControlVo _hControlVo;
        private List<H_SetMasterVo> _temporaryRemoveListHSetMasterVo;
        private List<H_CarMasterVo> _temporaryRemoveListHCarMasterVo;
        private List<H_StaffMasterVo> _temporaryRemoveListHStaffMasterVo;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public H_StockBoxs(H_ControlVo hControlVo) {
            /*
             * Vo
             */
            _hControlVo = hControlVo;
            /*
             * コントロール初期化
             */
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Name = "H_StockBoxs";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            /*
             * FlowLayoutPanelExを作成
             */
            _hFlowLayoutPanelExStockBoxs = new H_FlowLayoutPanelEx();
            _hFlowLayoutPanelExStockBoxs.AllowDrop = false; // ドラッグドロップを受け付けない
            _hFlowLayoutPanelExStockBoxs.AutoScroll = true;
            _hFlowLayoutPanelExStockBoxs.Dock = DockStyle.Fill;
            _hFlowLayoutPanelExStockBoxs.Name = "H_FlowLayoutPanelExBase";
            _hFlowLayoutPanelExStockBoxs.DragEnter += HFlowLayoutPanelExBase_DragEnter;
            _hFlowLayoutPanelExStockBoxs.DragDrop += HFlowLayoutPanelExBase_DragDrop;
            h_TableLayoutPanelExBase.Controls.Add(_hFlowLayoutPanelExStockBoxs, 0, 1);
        }

        /// <summary>
        /// ToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e) {
            switch (((ToolStripMenuItem)sender).Name) {
                case "ToolStripMenuItemExit": // アプリケーションを終了する
                    this.Close();
                    break;
                case "ToolStripMenuItemSet": // 配車先
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHSetMasterVo = _hControlVo.ListHSetMasterVo;
                    _hControlVo.RemoveListHSetMasterVo = _temporaryRemoveListHSetMasterVo.FindAll(x => x.ClassificationCode != 10 // 雇上
                                                                                                    && x.ClassificationCode != 11 // 区約
                                                                                                    && x.ClassificationCode != 90 // 事務・整備                                                                                                   
                                                                                                    && x.DeleteFlag == false);
                    this.CreateHSetLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemCar": // 車両
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHCarMasterVo = _hArrayUtility.RemoveHCarMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHCarMasterVo);
                    _hControlVo.RemoveListHCarMasterVo = _temporaryRemoveListHCarMasterVo.FindAll(x => x.DeleteFlag == false);
                    this.CreateHCarLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemEmployee": // 社員
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHStaffMasterVo = _hArrayUtility.RemoveHStaffMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHStaffMasterVo);
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 10 || x.Belongs == 11 || (x.Belongs == 12 && x.Occupation == 20)) && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemPartTime": // アルバイト
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHStaffMasterVo = _hArrayUtility.RemoveHStaffMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHStaffMasterVo);
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => x.Belongs == 12 && x.Occupation != 20 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemLongTerm": // 長期
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHStaffMasterVo = _hArrayUtility.RemoveHStaffMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHStaffMasterVo);
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.JobForm == 10 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemShortTerm": // 短期
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHStaffMasterVo = _hArrayUtility.RemoveHStaffMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHStaffMasterVo);
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => (x.Belongs == 20 || x.Belongs == 21) && x.JobForm == 11 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemDispatch": // 派遣
                    this.ToolStripMenuItemCheckedChange(sender);
                    this.FlowLayoutPanelExControlRemove();
                    _temporaryRemoveListHStaffMasterVo = _hArrayUtility.RemoveHStaffMasterVo((TableLayoutPanel)_hControlVo.HBoard, (FlowLayoutPanel)_hControlVo.HFlowLayoutPanelExStockBoxs, _hControlVo.ListHStaffMasterVo);
                    _hControlVo.RemoveListHStaffMasterVo = _temporaryRemoveListHStaffMasterVo.FindAll(x => x.Belongs == 13 && x.JobForm == 99 && x.RetirementFlag == false);
                    this.CreateHStaffLabel(_hControlVo);
                    break;
                case "ToolStripMenuItemSortAsc": // 昇順
                    this.ToolStripMenuItemCheckedChange(sender);

                    break;
                case "ToolStripMenuItemSortDesk": // 降順
                    this.ToolStripMenuItemCheckedChange(sender);

                    break;
                case "ToolStripMenuItemHelp": // ヘルプ

                    break;
            }
        }

        /// <summary>
        /// CreateHSetLabel 
        /// </summary>
        /// <param name="hControlVo"></param>
        private void CreateHSetLabel(H_ControlVo hControlVo) {
            foreach (H_SetMasterVo hSetMasterVo in hControlVo.RemoveListHSetMasterVo.OrderBy(x => x.ClassificationCode).ThenBy(x => x.SetName)) {
                //if (hSetMasterVo is not null && hSetMasterVo.SetCode != 0) {
                hControlVo.HSetMasterVo = hSetMasterVo;
                H_SetLabel hSetLabel = new(hControlVo);
                hSetLabel.MouseClick += HSetLabel_MouseClick;
                hSetLabel.MouseDoubleClick += HSetLabel_MouseDoubleClick;
                hSetLabel.MouseMove += HSetLabel_MouseMove;
                _hFlowLayoutPanelExStockBoxs.Controls.Add(hSetLabel); // SetLabelを追加
                //}
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
                    _hFlowLayoutPanelExStockBoxs.Controls.Add(hCarLabel); // CarLabelを追加
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
                    _hFlowLayoutPanelExStockBoxs.Controls.Add(hStaffLabel); // StaffLabelを追加
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
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                MessageBox.Show("HStaffLabel_MouseClick");
            }
        }
        private void HStaffLabel_MouseDoubleClick(object sender, MouseEventArgs e) {
            MessageBox.Show("HStaffLabel_MouseDoubleClick");
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
        /// ToolStripSeparatorが混在しているので注意して
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
             * メソッドを Clear 呼び出しても、コントロール ハンドルはメモリから削除されません。 メモリ リークを回避するには、 メソッドを Dispose 明示的に呼び出す必要があります。
             * ※後ろから解放している点が重要らしい。
             */
            for (int i = _hFlowLayoutPanelExStockBoxs.Controls.Count - 1; 0 <= i; i--)
                _hFlowLayoutPanelExStockBoxs.Controls[i].Dispose();
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
