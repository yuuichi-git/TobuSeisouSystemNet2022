namespace Toukanpo {
    partial class ToukanpoTrainingCardDetail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToukanpoTrainingCardDetail));
            this.ButtonDeletePicture = new System.Windows.Forms.Button();
            this.ButtonClipPicture = new System.Windows.Forms.Button();
            this.ButtonSelectPicture = new System.Windows.Forms.Button();
            this.PictureBoxCard = new System.Windows.Forms.PictureBox();
            this.DateTimeCertificationDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ComboBoxSelectName = new System.Windows.Forms.ComboBox();
            this.ComboBoxCompanyName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelDetail = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonDeletePicture
            // 
            this.ButtonDeletePicture.Location = new System.Drawing.Point(516, 168);
            this.ButtonDeletePicture.Name = "ButtonDeletePicture";
            this.ButtonDeletePicture.Size = new System.Drawing.Size(68, 24);
            this.ButtonDeletePicture.TabIndex = 25;
            this.ButtonDeletePicture.Text = "削除";
            this.ButtonDeletePicture.UseVisualStyleBackColor = true;
            this.ButtonDeletePicture.Click += new System.EventHandler(this.ButtonDeletePicture_Click);
            // 
            // ButtonClipPicture
            // 
            this.ButtonClipPicture.Location = new System.Drawing.Point(516, 140);
            this.ButtonClipPicture.Name = "ButtonClipPicture";
            this.ButtonClipPicture.Size = new System.Drawing.Size(68, 24);
            this.ButtonClipPicture.TabIndex = 23;
            this.ButtonClipPicture.Text = "クリップ";
            this.ButtonClipPicture.UseVisualStyleBackColor = true;
            this.ButtonClipPicture.Click += new System.EventHandler(this.ButtonClipPicture_Click);
            // 
            // ButtonSelectPicture
            // 
            this.ButtonSelectPicture.Location = new System.Drawing.Point(516, 112);
            this.ButtonSelectPicture.Name = "ButtonSelectPicture";
            this.ButtonSelectPicture.Size = new System.Drawing.Size(68, 24);
            this.ButtonSelectPicture.TabIndex = 21;
            this.ButtonSelectPicture.Text = "選択";
            this.ButtonSelectPicture.UseVisualStyleBackColor = true;
            this.ButtonSelectPicture.Click += new System.EventHandler(this.ButtonSelectPicture_Click);
            // 
            // PictureBoxCard
            // 
            this.PictureBoxCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBoxCard.Location = new System.Drawing.Point(20, 108);
            this.PictureBoxCard.Name = "PictureBoxCard";
            this.PictureBoxCard.Size = new System.Drawing.Size(484, 308);
            this.PictureBoxCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxCard.TabIndex = 30;
            this.PictureBoxCard.TabStop = false;
            // 
            // DateTimeCertificationDate
            // 
            this.DateTimeCertificationDate.CustomFormat = "yyyy年MM月dd日(ddd)";
            this.DateTimeCertificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeCertificationDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DateTimeCertificationDate.Location = new System.Drawing.Point(188, 72);
            this.DateTimeCertificationDate.Name = "DateTimeCertificationDate";
            this.DateTimeCertificationDate.Size = new System.Drawing.Size(144, 23);
            this.DateTimeCertificationDate.TabIndex = 29;
            this.DateTimeCertificationDate.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "認定日";
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdate.Location = new System.Drawing.Point(452, 16);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(132, 36);
            this.ButtonUpdate.TabIndex = 19;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ComboBoxSelectName
            // 
            this.ComboBoxSelectName.FormattingEnabled = true;
            this.ComboBoxSelectName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ComboBoxSelectName.Location = new System.Drawing.Point(188, 44);
            this.ComboBoxSelectName.Name = "ComboBoxSelectName";
            this.ComboBoxSelectName.Size = new System.Drawing.Size(240, 23);
            this.ComboBoxSelectName.TabIndex = 26;
            this.ComboBoxSelectName.TabStop = false;
            // 
            // ComboBoxCompanyName
            // 
            this.ComboBoxCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCompanyName.FormattingEnabled = true;
            this.ComboBoxCompanyName.Items.AddRange(new object[] {
            "東武清掃株式会社"});
            this.ComboBoxCompanyName.Location = new System.Drawing.Point(188, 16);
            this.ComboBoxCompanyName.Name = "ComboBoxCompanyName";
            this.ComboBoxCompanyName.Size = new System.Drawing.Size(240, 23);
            this.ComboBoxCompanyName.TabIndex = 24;
            this.ComboBoxCompanyName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "氏名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "所属会社";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStatusLabelDetail});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 434);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(602, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 31;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // ToolStripStatusLabelDetail
            // 
            this.ToolStripStatusLabelDetail.Name = "ToolStripStatusLabelDetail";
            this.ToolStripStatusLabelDetail.Size = new System.Drawing.Size(145, 17);
            this.ToolStripStatusLabelDetail.Text = "ToolStripStatusLabelStatus";
            // 
            // ToukanpoTrainingCardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 456);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ButtonDeletePicture);
            this.Controls.Add(this.ButtonClipPicture);
            this.Controls.Add(this.ButtonSelectPicture);
            this.Controls.Add(this.PictureBoxCard);
            this.Controls.Add(this.DateTimeCertificationDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ComboBoxSelectName);
            this.Controls.Add(this.ComboBoxCompanyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToukanpoTrainingCardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToukanpoDetail";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ButtonDeletePicture;
        private Button ButtonClipPicture;
        private Button ButtonSelectPicture;
        private PictureBox PictureBoxCard;
        private DateTimePicker DateTimeCertificationDate;
        private Label label4;
        private Button ButtonUpdate;
        private ComboBox ComboBoxSelectName;
        private ComboBox ComboBoxCompanyName;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel ToolStripStatusLabelDetail;
    }
}