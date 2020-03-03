namespace AutoTune
{
    partial class AutoTuneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbxPerson = new System.Windows.Forms.ComboBox();
            this.DS_PERSON = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbxHour = new System.Windows.Forms.ComboBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.QueueData = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxHis = new System.Windows.Forms.ComboBox();
            this.btnOpenHis = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_Finish = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS_PERSON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueData)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxPerson
            // 
            this.cbxPerson.DataSource = this.DS_PERSON;
            this.cbxPerson.DisplayMember = "Name";
            this.cbxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPerson.FormattingEnabled = true;
            this.cbxPerson.Location = new System.Drawing.Point(15, 24);
            this.cbxPerson.Name = "cbxPerson";
            this.cbxPerson.Size = new System.Drawing.Size(181, 21);
            this.cbxPerson.TabIndex = 0;
            this.cbxPerson.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DS_PERSON
            // 
            this.DS_PERSON.DataSource = typeof(EF_CONFIG.Models.CheckingPerson);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn người trực";
            // 
            // cbxHour
            // 
            this.cbxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHour.FormattingEnabled = true;
            this.cbxHour.Items.AddRange(new object[] {
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.cbxHour.Location = new System.Drawing.Point(15, 72);
            this.cbxHour.Name = "cbxHour";
            this.cbxHour.Size = new System.Drawing.Size(85, 21);
            this.cbxHour.TabIndex = 2;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(106, 73);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(90, 20);
            this.txtMin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn giờ trực (hh:mm)";
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.Location = new System.Drawing.Point(15, 117);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(181, 37);
            this.btnAddQueue.TabIndex = 5;
            this.btnAddQueue.Text = "Thêm hàng chờ";
            this.btnAddQueue.UseVisualStyleBackColor = true;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(15, 160);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(110, 22);
            this.btnSaveSetting.TabIndex = 6;
            this.btnSaveSetting.Text = "Lưu hàng chờ";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // QueueData
            // 
            this.QueueData.AllowUserToAddRows = false;
            this.QueueData.AllowUserToDeleteRows = false;
            this.QueueData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QueueData.ColumnHeadersHeight = 40;
            this.QueueData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.QueueData.Location = new System.Drawing.Point(202, 24);
            this.QueueData.Name = "QueueData";
            this.QueueData.RowHeadersWidth = 10;
            this.QueueData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QueueData.Size = new System.Drawing.Size(316, 341);
            this.QueueData.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hàng đợi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tải hàng chờ đã lưu";
            // 
            // cbxHis
            // 
            this.cbxHis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHis.FormattingEnabled = true;
            this.cbxHis.Location = new System.Drawing.Point(15, 210);
            this.cbxHis.Name = "cbxHis";
            this.cbxHis.Size = new System.Drawing.Size(181, 21);
            this.cbxHis.TabIndex = 9;
            this.cbxHis.DropDown += new System.EventHandler(this.cbxHis_DropDown);
            // 
            // btnOpenHis
            // 
            this.btnOpenHis.Location = new System.Drawing.Point(86, 237);
            this.btnOpenHis.Name = "btnOpenHis";
            this.btnOpenHis.Size = new System.Drawing.Size(110, 22);
            this.btnOpenHis.TabIndex = 11;
            this.btnOpenHis.Text = "Tải lịch sử";
            this.btnOpenHis.UseVisualStyleBackColor = true;
            this.btnOpenHis.Click += new System.EventHandler(this.btnOpenHis_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Bắt đầu check tự động";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_Finish
            // 
            this.lb_Finish.Location = new System.Drawing.Point(15, 303);
            this.lb_Finish.Name = "lb_Finish";
            this.lb_Finish.Size = new System.Drawing.Size(181, 22);
            this.lb_Finish.TabIndex = 13;
            this.lb_Finish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(15, 284);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(181, 19);
            this.lbStatus.TabIndex = 14;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoTuneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 371);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lb_Finish);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenHis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxHis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QueueData);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.cbxHour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxPerson);
            this.MaximumSize = new System.Drawing.Size(539, 410);
            this.MinimumSize = new System.Drawing.Size(539, 410);
            this.Name = "AutoTuneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoTuneForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DS_PERSON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource DS_PERSON;
        private System.Windows.Forms.ComboBox cbxHour;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.DataGridView QueueData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxHis;
        private System.Windows.Forms.Button btnOpenHis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_Finish;
        private System.Windows.Forms.Label lbStatus;
    }
}