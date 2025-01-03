using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    internal class CalcButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Создаем закругленный прямоугольник
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 20, 20, 180, 90); // Верхний левый угол
                path.AddArc(this.Width - 20, 0, 20, 20, 270, 90); // Верхний правый угол
                path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90); // Нижний правый угол
                path.AddArc(0, this.Height - 20, 20, 20, 90, 90); // Нижний левый угол
                path.CloseFigure();
                this.Region = new Region(path);
            }

            // Рисуем кнопку
            base.OnPaint(pevent);
        }
    }
}
