
using System.Drawing.Drawing2D;


namespace CalculatorUI
{
    public class RightTopRoundedButton : Button
    {
        // Радиус закругления
        private int radius = 25;


        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Создаем закругленный прямоугольник
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 1, 1, 180, 90); // Верхний левый угол
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Верхний правый угол
                path.AddArc(this.Width - 1, this.Height - 1, 1, 1, 0, 90); // Нижний правый угол
                path.AddArc(0, this.Height - 1, 1, 1, 90, 90); // Нижний левый угол
                path.CloseFigure();
                this.Region = new Region(path);
            }

            // Рисуем кнопку
            base.OnPaint(pevent);
        }
    }
    
    internal class CalcButton : Button
    {
        private int radius = 20; // Значение по умолчанию для радиуса

        // Метод для установки радиуса
        public void SetRadius(int r)
        {
            radius = r;
            this.Invalidate(); // Перерисовываем кнопку при изменении радиуса
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Создаем закругленный прямоугольник
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90); // Верхний левый угол
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Верхний правый угол
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Нижний правый угол
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Нижний левый угол
                path.CloseFigure();
                this.Region = new Region(path);
            }

            // Рисуем кнопку
            base.OnPaint(pevent);
        }
    }

    public class CalcRoundedLabel : Label
    {
        public CalcRoundedLabel()
        {
            this.AutoSize = false; // Отключаем авторазмер
            this.Height = 30; // Устанавливаем высоту
            this.BackColor = Color.LightGray; // Светло-серый цвет
            this.BorderStyle = BorderStyle.None; // Убираем стандартную рамку
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 7; // Радиус закругления
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }
    }
}
