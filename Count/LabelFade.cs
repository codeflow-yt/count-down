using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Count
{
    public class LabelFade
    {
        public enum FadeType
        {
            IN,
            OUT
        };

		private List<int> colorRGB = new List<int>(3);
		private List<int> defaultRGB = new List<int>(3);
		private List<int> backgroundRGB = new List<int>(3);

        private FadeType fadeType;

        private Timer timer = new Timer();

        private Label label;

        public LabelFade(ref Label targetLabel, Color backGroundColor, FadeType fadeType)
        {
            this.label = targetLabel;
            this.fadeType = fadeType;
			this.backgroundRGB = ConvertToList(backGroundColor);
			this.defaultRGB = ConvertToList(label.ForeColor);

            timer.Interval = 10;
            timer.Tick += Timer_Tick;

			if (this.fadeType == FadeType.IN)
			{
				label.ForeColor = backGroundColor;
			}
		}

        public void SetReferenceInterval(int timerInterval)
		{
            timer.Interval = timerInterval / 100;
		}

		private Color ConvertToColor(List<int> rgb)
		{
			if (rgb.Count < 3)
				return Color.FromArgb(0, 0, 0);

			Color color = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
			return color;
		}

		private List<int> ConvertToList(Color color)
		{
			List<int> list = new List<int>(3);

			list.Add(color.R);
			list.Add(color.G);
			list.Add(color.B);

			return list;
		}

        public void FadeLabel()
        {
			timer.Stop();

			if (this.fadeType == FadeType.IN)
			{
				label.ForeColor = ConvertToColor(backgroundRGB);
			}
			else
			{
				label.ForeColor = ConvertToColor(defaultRGB);
			}

			this.colorRGB.Clear();
			this.colorRGB = ConvertToList(label.ForeColor);

			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (this.fadeType == FadeType.IN)
			{
				for (int i = 0; i < 3; i++)
				{
					colorRGB[i] = colorRGB[i] < defaultRGB[i] ?
						colorRGB[i] + (255 / 100) * timer.Interval :
						colorRGB[i] - (255 / 100) * timer.Interval;
					
					colorRGB[i] = colorRGB[i] < 0 ? Convert.ToByte(0) : colorRGB[i];
					colorRGB[i] = colorRGB[i] > 255 ? Convert.ToByte(255) : colorRGB[i];
				}

				label.ForeColor = ConvertToColor(colorRGB);
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					colorRGB[i] = colorRGB[i] < backgroundRGB[i] ?
						colorRGB[i] + (255 / 100) * timer.Interval :
						colorRGB[i] - (255 / 100) * timer.Interval;
					
					colorRGB[i] = colorRGB[i] < 0 ? Convert.ToByte(0) : colorRGB[i];
					colorRGB[i] = colorRGB[i] > 255 ? Convert.ToByte(255) : colorRGB[i];
				}

				label.ForeColor = ConvertToColor(colorRGB);
			}
		}
    }
}
