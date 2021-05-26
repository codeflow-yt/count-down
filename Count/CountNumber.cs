using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Count
{
    public class CountNumber
    {
        enum CountDirection
        {
            FW,
            BW
        };

        private int currentNumber = 0;
        private int countStartOn = 0;
        private int countEndOn = 0;

        private CountDirection countDirection;

        public CountNumber(int countStartOn = 0, int countEndOn = 10)
        {
            this.countStartOn = countStartOn;
            this.countEndOn = countEndOn;
            this.currentNumber = countStartOn;

            this.countDirection = countEndOn > countStartOn ? CountDirection.FW : CountDirection.BW;
        }

        public void SetToLabel(Label label, Vector dimension)
        {
            label.Text = this.currentNumber.ToString();
            CenterizedLabel(label, dimension);
        }

        public void Count()
        {
            if (this.countDirection == CountDirection.FW && this.currentNumber < this.countEndOn)
            {
                this.currentNumber++;
            }
            else if (this.countDirection == CountDirection.BW && this.currentNumber > this.countEndOn)
            {
                this.currentNumber--;
            }
        }

        private void CenterizedLabel(Label label, Vector dimension)
        {
            int x = Convert.ToInt32((dimension.X / 2) - (label.Width / 2));
            int y = Convert.ToInt32((dimension.Y / 2) - (label.Height / 2));

            label.Location = new System.Drawing.Point(x, y);
        }
    }
}
