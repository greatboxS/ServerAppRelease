namespace AutoTune
{
    partial class ELogs
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
            this.rbToday = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbTimeAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.DS_AREA = new System.Windows.Forms.BindingSource(this.components);
            this.rbOneArea = new System.Windows.Forms.RadioButton();
            this.rbAllArea = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxPeople = new System.Windows.Forms.ComboBox();
            this.DS_PERSON = new System.Windows.Forms.BindingSource(this.components);
            this.rbOnePeople = new System.Windows.Forms.RadioButton();
            this.rbAllPeople = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbStatusAll = new System.Windows.Forms.RadioButton();
            this.rbStatusNotOk = new System.Windows.Forms.RadioButton();
            this.rbStatusOk = new System.Windows.Forms.RadioButton();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.ContainerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxGroupNotes = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_AREA)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_PERSON)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.Checked = true;
            this.rbToday.Location = new System.Drawing.Point(9, 17);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(55, 17);
            this.rbToday.TabIndex = 0;
            this.rbToday.TabStop = true;
            this.rbToday.Text = "Today";
            this.rbToday.UseVisualStyleBackColor = true;
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Location = new System.Drawing.Point(9, 37);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(77, 17);
            this.rbWeek.TabIndex = 1;
            this.rbWeek.Text = "This Week";
            this.rbWeek.UseVisualStyleBackColor = true;
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(9, 57);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(78, 17);
            this.rbMonth.TabIndex = 2;
            this.rbMonth.Text = "This Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            // 
            // rbTimeAll
            // 
            this.rbTimeAll.AutoSize = true;
            this.rbTimeAll.Location = new System.Drawing.Point(9, 77);
            this.rbTimeAll.Name = "rbTimeAll";
            this.rbTimeAll.Size = new System.Drawing.Size(36, 17);
            this.rbTimeAll.TabIndex = 3;
            this.rbTimeAll.Text = "All";
            this.rbTimeAll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbToday);
            this.groupBox1.Controls.Add(this.rbTimeAll);
            this.groupBox1.Controls.Add(this.rbWeek);
            this.groupBox1.Controls.Add(this.rbMonth);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select date to view";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxArea);
            this.groupBox2.Controls.Add(this.rbOneArea);
            this.groupBox2.Controls.Add(this.rbAllArea);
            this.groupBox2.Location = new System.Drawing.Point(202, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 47);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Area";
            // 
            // cbxArea
            // 
            this.cbxArea.DataSource = this.DS_AREA;
            this.cbxArea.DisplayMember = "AreaName";
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.Enabled = false;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(90, 18);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(202, 21);
            this.cbxArea.TabIndex = 4;
            // 
            // DS_AREA
            // 
            this.DS_AREA.DataSource = typeof(EF_CONFIG.Models.ECheckArea);
            // 
            // rbOneArea
            // 
            this.rbOneArea.AutoSize = true;
            this.rbOneArea.Location = new System.Drawing.Point(10, 22);
            this.rbOneArea.Name = "rbOneArea";
            this.rbOneArea.Size = new System.Drawing.Size(70, 17);
            this.rbOneArea.TabIndex = 0;
            this.rbOneArea.Text = "One Area";
            this.rbOneArea.UseVisualStyleBackColor = true;
            this.rbOneArea.CheckedChanged += new System.EventHandler(this.rbOneArea_CheckedChanged);
            // 
            // rbAllArea
            // 
            this.rbAllArea.AutoSize = true;
            this.rbAllArea.Checked = true;
            this.rbAllArea.Location = new System.Drawing.Point(299, 22);
            this.rbAllArea.Name = "rbAllArea";
            this.rbAllArea.Size = new System.Drawing.Size(61, 17);
            this.rbAllArea.TabIndex = 3;
            this.rbAllArea.TabStop = true;
            this.rbAllArea.Text = "All Area";
            this.rbAllArea.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxPeople);
            this.groupBox3.Controls.Add(this.rbOnePeople);
            this.groupBox3.Controls.Add(this.rbAllPeople);
            this.groupBox3.Location = new System.Drawing.Point(202, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select People";
            // 
            // cbxPeople
            // 
            this.cbxPeople.DataSource = this.DS_PERSON;
            this.cbxPeople.DisplayMember = "Name";
            this.cbxPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPeople.Enabled = false;
            this.cbxPeople.FormattingEnabled = true;
            this.cbxPeople.Location = new System.Drawing.Point(90, 18);
            this.cbxPeople.Name = "cbxPeople";
            this.cbxPeople.Size = new System.Drawing.Size(202, 21);
            this.cbxPeople.TabIndex = 4;
            // 
            // DS_PERSON
            // 
            this.DS_PERSON.DataSource = typeof(EF_CONFIG.Models.CheckingPerson);
            // 
            // rbOnePeople
            // 
            this.rbOnePeople.AutoSize = true;
            this.rbOnePeople.Location = new System.Drawing.Point(10, 22);
            this.rbOnePeople.Name = "rbOnePeople";
            this.rbOnePeople.Size = new System.Drawing.Size(81, 17);
            this.rbOnePeople.TabIndex = 0;
            this.rbOnePeople.Text = "One People";
            this.rbOnePeople.UseVisualStyleBackColor = true;
            this.rbOnePeople.CheckedChanged += new System.EventHandler(this.rbOnePeople_CheckedChanged);
            // 
            // rbAllPeople
            // 
            this.rbAllPeople.AutoSize = true;
            this.rbAllPeople.Checked = true;
            this.rbAllPeople.Location = new System.Drawing.Point(299, 22);
            this.rbAllPeople.Name = "rbAllPeople";
            this.rbAllPeople.Size = new System.Drawing.Size(72, 17);
            this.rbAllPeople.TabIndex = 3;
            this.rbAllPeople.TabStop = true;
            this.rbAllPeople.Text = "All People";
            this.rbAllPeople.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.btnViewLogs);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 107);
            this.panel1.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbStatusAll);
            this.groupBox4.Controls.Add(this.rbStatusNotOk);
            this.groupBox4.Controls.Add(this.rbStatusOk);
            this.groupBox4.Location = new System.Drawing.Point(121, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(77, 101);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // rbStatusAll
            // 
            this.rbStatusAll.AutoSize = true;
            this.rbStatusAll.Checked = true;
            this.rbStatusAll.Location = new System.Drawing.Point(6, 17);
            this.rbStatusAll.Name = "rbStatusAll";
            this.rbStatusAll.Size = new System.Drawing.Size(36, 17);
            this.rbStatusAll.TabIndex = 0;
            this.rbStatusAll.TabStop = true;
            this.rbStatusAll.Text = "All";
            this.rbStatusAll.UseVisualStyleBackColor = true;
            // 
            // rbStatusNotOk
            // 
            this.rbStatusNotOk.AutoSize = true;
            this.rbStatusNotOk.Location = new System.Drawing.Point(6, 77);
            this.rbStatusNotOk.Name = "rbStatusNotOk";
            this.rbStatusNotOk.Size = new System.Drawing.Size(66, 17);
            this.rbStatusNotOk.TabIndex = 3;
            this.rbStatusNotOk.Text = "NOT OK";
            this.rbStatusNotOk.UseVisualStyleBackColor = true;
            // 
            // rbStatusOk
            // 
            this.rbStatusOk.AutoSize = true;
            this.rbStatusOk.Location = new System.Drawing.Point(6, 47);
            this.rbStatusOk.Name = "rbStatusOk";
            this.rbStatusOk.Size = new System.Drawing.Size(40, 17);
            this.rbStatusOk.TabIndex = 2;
            this.rbStatusOk.Text = "OK";
            this.rbStatusOk.UseVisualStyleBackColor = true;
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnViewLogs.Location = new System.Drawing.Point(581, 9);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(83, 92);
            this.btnViewLogs.TabIndex = 7;
            this.btnViewLogs.Text = "Get Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.AutoScroll = true;
            this.ContainerPanel.AutoSize = true;
            this.ContainerPanel.BackColor = System.Drawing.Color.White;
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 140);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(669, 443);
            this.ContainerPanel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbxGroupNotes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 33);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Check Item Filter";
            // 
            // cbxGroupNotes
            // 
            this.cbxGroupNotes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroupNotes.Enabled = false;
            this.cbxGroupNotes.FormattingEnabled = true;
            this.cbxGroupNotes.Location = new System.Drawing.Point(93, 6);
            this.cbxGroupNotes.Name = "cbxGroupNotes";
            this.cbxGroupNotes.Size = new System.Drawing.Size(477, 21);
            this.cbxGroupNotes.TabIndex = 5;
            this.cbxGroupNotes.SelectedIndexChanged += new System.EventHandler(this.cbxGroupNotes_SelectedIndexChanged);
            // 
            // ELogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 583);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(685, 622);
            this.MinimumSize = new System.Drawing.Size(685, 622);
            this.Name = "ELogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.ELogs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_AREA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_PERSON)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbToday;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbTimeAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.RadioButton rbOneArea;
        private System.Windows.Forms.RadioButton rbAllArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxPeople;
        private System.Windows.Forms.RadioButton rbOnePeople;
        private System.Windows.Forms.RadioButton rbAllPeople;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.FlowLayoutPanel ContainerPanel;
        private System.Windows.Forms.BindingSource DS_AREA;
        private System.Windows.Forms.BindingSource DS_PERSON;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxGroupNotes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbStatusAll;
        private System.Windows.Forms.RadioButton rbStatusNotOk;
        private System.Windows.Forms.RadioButton rbStatusOk;
    }
}