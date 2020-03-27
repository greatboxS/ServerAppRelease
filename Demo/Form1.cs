using EF_CONFIG.Data;
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

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataContext DataContext = new DataContext();
            Data_Services Data_Services = new Data_Services(DataContext);

            DataBaseInitialize.Begin();
        }
    }
}
