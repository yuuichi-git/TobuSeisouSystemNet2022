/*
 * 2024-03-22
 */
using H_ControlEx;

using H_Dao;

using H_Vo;

using Vo;

namespace H_Toukanpo {
    public partial class H_ToukanpoTrainingCardDetail : Form {
        private readonly DateTime _defaultDateTime = new(1900, 01, 01);
        /*
         * Dao
         */
        private readonly H_StaffMasterDao _hStaffMasterDao;
        private readonly H_ToukanpoTrainingCardDao _hToukanpoTrainingCardDao;

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <param name="connectionVo"></param>
        public H_ToukanpoTrainingCardDetail(ConnectionVo connectionVo) {
            /*
             * Dao
             */
            _hStaffMasterDao = new(connectionVo);
            _hToukanpoTrainingCardDao = new(connectionVo);
            /*
             * InitializeControl
             */
            InitializeComponent();
            this.InitializeComboBoxSelectName();
            this.InitializeControl();
        }

        /// <summary>
        /// HButtonExUpdate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExUpdate_Click(object sender, EventArgs e) {
            if (_selectedHToukanpoTrainingCardVo == null) {
                MessageBox.Show("���̖��O�͏]�ƈ��䒠�ɓo�^����Ă��܂���B���X�g����I�����ĉ������B", "���b�Z�[�W", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("�X�V���܂����H", "���b�Z�[�W", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    if (_hToukanpoTrainingCardDao.ExistenceHToukanpoTrainingCardMaster(_selectedHToukanpoTrainingCardVo.StaffCode)) {
                        try {
                            _hToukanpoTrainingCardDao.UpdateOneHToukanpoTrainingCardMaster(this.SetToukanpoTrainingCardVo());
                            MessageBox.Show("�C���o�^���������܂����B", "���b�Z�[�W", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.InitializeControl();
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    } else {
                        try {
                            _hToukanpoTrainingCardDao.InsertOneHToukanpoTrainingCardMaster(this.SetToukanpoTrainingCardVo());
                            MessageBox.Show("�V�K�o�^���������܂����B", "���b�Z�[�W", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.InitializeControl();
                        } catch (Exception exception) {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// SetToukanpoTrainingCardVo
        /// </summary>
        /// <returns></returns>
        private H_ToukanpoTrainingCardVo SetToukanpoTrainingCardVo() {
            H_ToukanpoTrainingCardVo hToukanpoTrainingCardVo = new();
            hToukanpoTrainingCardVo.StaffCode = _selectedHStaffMasterVo.StaffCode;
            hToukanpoTrainingCardVo.DisplayName = _selectedHStaffMasterVo.DisplayName;
            hToukanpoTrainingCardVo.CompanyName = HComboBoxExCompany.Text;
            hToukanpoTrainingCardVo.CardName = _selectedHStaffMasterVo.DisplayName;
            hToukanpoTrainingCardVo.CertificationDate = HDateTimePickerExCertificationDate.GetValue().Date;
            hToukanpoTrainingCardVo.Picture = (byte[])new ImageConverter().ConvertTo(PictureBoxCard.Image, typeof(byte[])); // �ʐ^
            hToukanpoTrainingCardVo.InsertPcName = Environment.MachineName;
            hToukanpoTrainingCardVo.InsertYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.UpdatePcName = Environment.MachineName;
            hToukanpoTrainingCardVo.UpdateYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.DeletePcName = Environment.MachineName;
            hToukanpoTrainingCardVo.DeleteYmdHms = DateTime.Now;
            hToukanpoTrainingCardVo.DeleteFlag = false;
            return hToukanpoTrainingCardVo;
        }

        /// <summary>
        /// InitializeComboBoxSelectName
        /// ComboBox�Ƀf�[�^������
        /// </summary>
        private void InitializeComboBoxSelectName() {
            HComboBoxExStaffName.Items.Clear();
            foreach (H_StaffMasterVo hStaffMasterVo in _hStaffMasterDao.SelectAllHStaffMaster().OrderBy(x => x.NameKana))
                HComboBoxExStaffName.Items.Add(new ComboBoxSelectNameVo(hStaffMasterVo.Name, hStaffMasterVo));
            HComboBoxExStaffName.DisplayMember = "Name";
            // �����ŃC�x���g�ǉ����Ȃ��Ə������Ŕ��΂����Ⴄ��
            HComboBoxExStaffName.SelectedIndexChanged += ComboBoxSelectName_SelectedIndexChanged;
            // �I�[�g�R���v���[�g���[�h�̐ݒ�
            HComboBoxExStaffName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // �R���{�{�b�N�X�̃A�C�e�����I�[�g�R���v���[�g�̑I�����Ƃ���
            HComboBoxExStaffName.AutoCompleteSource = AutoCompleteSource.ListItems;
            HComboBoxExStaffName.Focus();
        }

        /// <summary>
        /// �R���g���[����������
        /// </summary>
        private void InitializeControl() {
            HComboBoxExCompany.Text = "�������|�������";
            HComboBoxExStaffName.Text = "";
            HDateTimePickerExCertificationDate.SetValue(DateTime.Now.Date);
            PictureBoxCard.Image = null;
        }

        /// <summary>
        /// ComboBoxSelectNameVo
        /// �����N���X
        /// </summary>
        private class ComboBoxSelectNameVo {
            private string _name;
            private H_StaffMasterVo _hStaffMasterVo;

            // �v���p�e�B���R���X�g���N�^�ŃZ�b�g
            public ComboBoxSelectNameVo(string name, H_StaffMasterVo hStaffMasterVo) {
                _name = name;
                _hStaffMasterVo = hStaffMasterVo;
            }

            public string Name {
                get => _name;
                set => _name = value;
            }
            public H_StaffMasterVo HStaffMasterVo {
                get => _hStaffMasterVo;
                set => _hStaffMasterVo = value;
            }
        }

        /// <summary>
        /// ComboBoxSelectName�őI�����ꂽStaffLedgerVo��ێ�
        /// </summary>
        private H_StaffMasterVo _selectedHStaffMasterVo = new();
        /// <summary>
        /// ComboBoxSelectName�őI�����ꂽToukanpoTrainingCardVo��ێ�
        /// </summary>
        private H_ToukanpoTrainingCardVo _selectedHToukanpoTrainingCardVo = new();
        /// <summary>
        /// ComboBoxSelectName_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectName_SelectedIndexChanged(object sender, EventArgs e) {
            _selectedHStaffMasterVo = ((ComboBoxSelectNameVo)((H_ComboBoxEx)sender).SelectedItem).HStaffMasterVo;
            _selectedHToukanpoTrainingCardVo = _hToukanpoTrainingCardDao.SelectOneHToukanpoTrainingCardMaster(_selectedHStaffMasterVo.StaffCode);
            if (_selectedHToukanpoTrainingCardVo.StaffCode > 0) {
                ToolStripStatusLabelDetail.Text = "�o�^����Ă��܂�";
                // Control�ɒl���Z�b�g
                HComboBoxExCompany.Text = _selectedHToukanpoTrainingCardVo.CompanyName;
                HDateTimePickerExCertificationDate.SetValue(_selectedHToukanpoTrainingCardVo.CertificationDate.Date);
                if (_selectedHToukanpoTrainingCardVo.Picture.Length != 0) {
                    PictureBoxCard.Image = (Image)new ImageConverter().ConvertFrom(_selectedHToukanpoTrainingCardVo.Picture);
                } else {
                    PictureBoxCard.Image = null;
                }
            } else {
                ToolStripStatusLabelDetail.Text = "�o�^����Ă��܂���";
                // Control�ɒl���Z�b�g
                HComboBoxExCompany.SelectedIndex = -1;
                //ComboBoxSelectName.Text = "";
                HDateTimePickerExCertificationDate.SetValue(DateTime.Now.Date);
                PictureBoxCard.Image = null;
            }
        }

        /// <summary>
        /// HButtonExClip_Click
        /// �N���b�v�{�[�h�̃f�[�^�𗘗p����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExClip_Click(object sender, EventArgs e) {
            /*
             * �Ȃ񂩌^�̃`�F�b�N�͂���Ȃ������E�E�E�G���[���o�Ȃ����E�E�E
             */
            PictureBoxCard.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
        }

        /// <summary>
        /// PictureBoxCard���N���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HButtonExDelete_Click(object sender, EventArgs e) {
            PictureBoxCard.Image = null;
        }

        /// <summary>
        /// ToolStripMenuItemExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// H_ToukanpoTrainingCardDetail_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void H_ToukanpoTrainingCardDetail_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dialogResult = MessageBox.Show("�A�v���P�[�V�������I�����܂��B��낵���ł����H", "���b�Z�[�W", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dialogResult) {
                case DialogResult.OK:
                    e.Cancel = false;
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
