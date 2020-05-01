namespace AutoTune.ControlView
{
    partial class NotOkLogs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPlace = new System.Windows.Forms.Label();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbPerson = new System.Windows.Forms.Label();
            this.lbItem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbCheckTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPlace
            // 
            this.lbPlace.AutoSize = true;
            this.lbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPlace.Location = new System.Drawing.Point(5, 30);
            this.lbPlace.Name = "lbPlace";
            this.lbPlace.Size = new System.Drawing.Size(38, 16);
            this.lbPlace.TabIndex = 0;
            this.lbPlace.Text = "STT";
            // 
            // lbArea
            // 
            this.lbArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbArea.Location = new System.Drawing.Point(3, 2);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(314, 22);
            this.lbArea.TabIndex = 1;
            this.lbArea.Text = "Area:";
            this.lbArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPerson
            // 
            this.lbPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPerson.Location = new System.Drawing.Point(323, 2);
            this.lbPerson.Name = "lbPerson";
            this.lbPerson.Size = new System.Drawing.Size(226, 22);
            this.lbPerson.TabIndex = 2;
            this.lbPerson.Text = "People:";
            this.lbPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbItem
            // 
            this.lbItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbItem.Location = new System.Drawing.Point(3, 27);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(546, 30);
            this.lbItem.TabIndex = 3;
            this.lbItem.Text = "CheckItem:";
            this.lbItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(489, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Note Detail";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPlace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 74);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbStatus);
            this.panel2.Controls.Add(this.lbArea);
            this.panel2.Controls.Add(this.lbPerson);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbItem);
            this.panel2.Controls.Add(this.lbCheckTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(65, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 74);
            this.panel2.TabIndex = 7;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStatus.Location = new System.Drawing.Point(269, 59);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(69, 13);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "#DateTime";
            // 
            // lbCheckTime
            // 
            this.lbCheckTime.AutoSize = true;
            this.lbCheckTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCheckTime.Location = new System.Drawing.Point(3, 59);
            this.lbCheckTime.Name = "lbCheckTime";
            this.lbCheckTime.Size = new System.Drawing.Size(69, 13);
            this.lbCheckTime.TabIndex = 4;
            this.lbCheckTime.Text = "#DateTime";
            // 
            // NotOkLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NotOkLogs";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(623, 84);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbPlace;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbPerson;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbCheckTime;
    }
}
