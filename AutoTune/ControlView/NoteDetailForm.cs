using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_CONFIG.Models;
using EF_CONFIG.Data;

namespace AutoTune.ControlView
{
    public partial class NoteDetailForm : Form
    {
        public NoteDetailForm()
        {
            InitializeComponent();
        }

        private ECheckNoteExtension ECheckNoteExtension;
        private Data_Services Data_Services;

        public NoteDetailForm(ECheckNoteExtension noteExtension, 
            string personName, string areaName, string checkTime, string itemName)
        {
            InitializeComponent();

            Data_Services = new Data_Services(new DataContext());

            ECheckNoteExtension = noteExtension;
            DS_NOTE_EXTENSION.DataSource = noteExtension;

            lbArea.Text = areaName;
            lbPeople.Text = personName;
            lbItem.Text = itemName;
            lbCheckTime.Text = checkTime;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var noteExtension = DS_NOTE_EXTENSION.DataSource as ECheckNoteExtension;

            if(Data_Services.Edit_NoteExtension(noteExtension))
            {
                MessageBox.Show("Save note detail successfully");
            }
            else
            {
                MessageBox.Show("An error orccurs while saving data");
            }
        }
    }
}
