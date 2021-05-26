using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Count
{
    public partial class Form1 : Form
    {
        CountNumber countNumber = new CountNumber(0, 99);

        Vector formDimension = new Vector();

        public Form1()
        {
            InitializeComponent();

            formDimension.X = this.Width;
            formDimension.Y = this.Height;

            countNumber.SetToLabel(label1, formDimension);

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countNumber.Count();

            countNumber.SetToLabel(label1, formDimension);
        }
    }
}
