namespace AutoTune.ControlView
{
    partial class NoteDetailForm
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
            this.lbArea = new System.Windows.Forms.Label();
            this.lbPeople = new System.Windows.Forms.Label();
            this.lbItem = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.lbCheckTime = new System.Windows.Forms.Label();
            this.chbResolved = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtResolvedTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSolution = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DS_NOTE_EXTENSION = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_NOTE_EXTENSION)).BeginInit();
            this.SuspendLayout();
            // 
            // lbArea
            // 
            this.lbArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbArea.Location = new System.Drawing.Point(6, 16);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(314, 30);
            this.lbArea.TabIndex = 4;
            this.lbArea.Text = "Area:";
            this.lbArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPeople
            // 
            this.lbPeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPeople.Location = new System.Drawing.Point(326, 16);
            this.lbPeople.Name = "lbPeople";
            this.lbPeople.Size = new System.Drawing.Size(226, 30);
            this.lbPeople.TabIndex = 5;
            this.lbPeople.Text = "People:";
            this.lbPeople.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbItem
            // 
            this.lbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbItem.Location = new System.Drawing.Point(6, 48);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(546, 30);
            this.lbItem.TabIndex = 6;
            this.lbItem.Text = "CheckItem:";
            this.lbItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtError
            // 
            this.txtError.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DS_NOTE_EXTENSION, "NoteDetail", true));
            this.txtError.Location = new System.Drawing.Point(56, 20);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(496, 53);
            this.txtError.TabIndex = 7;
            // 
            // lbCheckTime
            // 
            this.lbCheckTime.AutoSize = true;
            this.lbCheckTime.Location = new System.Drawing.Point(4, 81);
            this.lbCheckTime.Name = "lbCheckTime";
            this.lbCheckTime.Size = new System.Drawing.Size(63, 13);
            this.lbCheckTime.TabIndex = 11;
            this.lbCheckTime.Text = "Check time:";
            // 
            // chbResolved
            // 
            this.chbResolved.AutoSize = true;
            this.chbResolved.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.DS_NOTE_EXTENSION, "Resolved", true));
            this.chbResolved.Location = new System.Drawing.Point(9, 271);
            this.chbResolved.Name = "chbResolved";
            this.chbResolved.Size = new System.Drawing.Size(71, 17);
            this.chbResolved.TabIndex = 13;
            this.chbResolved.Text = "Resolved";
            this.chbResolved.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Resolved time:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtResolvedTime);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtProgress);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSolution);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtError);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chbResolved);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 297);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note Detail:";
            // 
            // dtResolvedTime
            // 
            this.dtResolvedTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DS_NOTE_EXTENSION, "CheckTime_", true));
            this.dtResolvedTime.Location = new System.Drawing.Point(169, 268);
            this.dtResolvedTime.Name = "dtResolvedTime";
            this.dtResolvedTime.Size = new System.Drawing.Size(200, 20);
            this.dtResolvedTime.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Location = new System.Drawing.Point(463, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DS_NOTE_EXTENSION, "NoteProgress", true));
            this.txtProgress.Location = new System.Drawing.Point(56, 201);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(496, 53);
            this.txtProgress.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Progress:";
            // 
            // txtSolution
            // 
            this.txtSolution.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DS_NOTE_EXTENSION, "Solution", true));
            this.txtSolution.Location = new System.Drawing.Point(56, 142);
            this.txtSolution.Multiline = true;
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.Size = new System.Drawing.Size(496, 53);
            this.txtSolution.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Solution:";
            // 
            // txtReason
            // 
            this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DS_NOTE_EXTENSION, "NoteReason", true));
            this.txtReason.Location = new System.Drawing.Point(56, 80);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(496, 53);
            this.txtReason.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Reason:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Detail:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbArea);
            this.groupBox2.Controls.Add(this.lbItem);
            this.groupBox2.Controls.Add(this.lbCheckTime);
            this.groupBox2.Controls.Add(this.lbPeople);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 109);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Information:";
            // 
            // DS_NOTE_EXTENSION
            // 
            this.DS_NOTE_EXTENSION.DataSource = typeof(EF_CONFIG.Models.ECheckNoteExtension);
            // 
            // NoteDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "NoteDetailForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Note Detail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_NOTE_EXTENSION)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbPeople;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label lbCheckTime;
        private System.Windows.Forms.CheckBox chbResolved;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSolution;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtResolvedTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource DS_NOTE_EXTENSION;
    }
}