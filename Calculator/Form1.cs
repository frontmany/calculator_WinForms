
using CalculatorUI;
using System.Drawing.Drawing2D;

namespace Calculator
{
    

    public partial class Form1 : Form
    {
        public const int MAX_LENGTH_NUMBER = 15;
        private bool IS_REMAINDER_OPERATOR = false;

        private string m_equation = "";
        List<string> m_numbers_list = new List<string> { "" };
        List<string> m_operators_list = new List<string> { };
        int m_current_number_index = 0;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void fitSize()
        {
            if (label1.Text.Length >= 26)
            {
                label1.Font = new Font("Arial", 12, FontStyle.Bold);

                if (label1.Text.Length >= 72)
                {
                    label1.Font = new Font("Arial", 8, FontStyle.Bold);

                    if (label1.Text.Length >= 128)
                    {
                        label1.Font = new Font("Arial", 6, FontStyle.Bold);
                    }
                }
            }
            
            else
            {
                label1.Font = new Font("Arial", 16, FontStyle.Bold);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.FindForm().WindowState = FormWindowState.Minimized;
        }
        private void SetRoundedRegion()
        {
            int radius = 20; // ������ �����������
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // ������� ����� ����
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // ������� ������ ����
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // ������ ������ ����
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // ������ ����� ����
            path.CloseFigure();

            this.Region = new Region(path); // ��������� ������� �����
        }
        

        private void CustomTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.FindForm().Location;
            }
        }

        private void CustomTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.FindForm().Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void CustomTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Size = new Size(345, 610);
            this.Icon = new Icon("C:/prj/C#/Calculator/resources/calculator.ico");
            this.Text = "�����������";
            this.FormBorderStyle = FormBorderStyle.None;

            SetRoundedRegion();

            this.MouseDown += CustomTitleBar_MouseDown;
            this.MouseMove += CustomTitleBar_MouseMove;
            this.MouseUp += CustomTitleBar_MouseUp;

            calculatorIcon = new PictureBox();
            calculatorIcon.Image = Image.FromFile("C:/prj/C#/Calculator/resources/calculator.ico");
            calculatorIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            calculatorIcon.Size = new Size(15, 15); // ��������� � ��� ����
            calculatorIcon.Location = new Point(8, 5); // �������� �����

            titleLabel = new Label();
            titleLabel.Text = "�����������";
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(25, 5); // �������� �����
            titleLabel.AutoSize = true;

            closeButton = new RightTopRoundedButton();
            closeButton.Location = new Point(this.Width - 40, 0); // �������� �����
            closeButton.BackColor = Color.FromArgb(30, 30, 30);
            closeButton.Size = new Size(40, 26); // ��������� � ��� ����
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("Arial", 8, FontStyle.Bold); // �������� ������ ������
            
            Image oImage2 = Image.FromFile("C:/prj/C#/Calculator/resources/cross.png");
            Image resizedImage2 = oImage2.GetThumbnailImage(28, 28, null, IntPtr.Zero);
            closeButton.Image = resizedImage2;

            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.MouseEnter += (s, e) => closeButton.BackColor = Color.FromArgb(40, 40, 40);
            closeButton.MouseLeave += (s, e) => closeButton.BackColor = Color.FromArgb(30, 30, 30);
            closeButton.Click += CloseButton_Click;

            minimizeButton = new CalcButton();
            minimizeButton.SetRadius(1);
            minimizeButton.Location = new Point(this.Width - 80, 0); // �������� �����
            minimizeButton.BackColor = Color.FromArgb(30, 30, 30);
            minimizeButton.Size = new Size(40, 26); // ��������� � ��� ����
            minimizeButton.ForeColor = Color.White;
            minimizeButton.Font = new Font("Arial", 8, FontStyle.Bold); // �������� ������ ������

            Image oImage1 = Image.FromFile("C:/prj/C#/Calculator/resources/fold.png");
            Image resizedImage1 = oImage1.GetThumbnailImage(28, 28, null, IntPtr.Zero);
            minimizeButton.Image = resizedImage1;

            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.MouseEnter += (s, e) => minimizeButton.BackColor = Color.FromArgb(40, 40, 40);
            minimizeButton.MouseLeave += (s, e) => minimizeButton.BackColor = Color.FromArgb(30, 30, 30);
            minimizeButton.Click += MinimizeButton_Click;

            this.Controls.Add(calculatorIcon);
            this.Controls.Add(titleLabel);
            this.Controls.Add(closeButton);
            this.Controls.Add(minimizeButton);

            CalcRoundedLabel label3 = new CalcRoundedLabel();
            label3.Width = 310; // ��������� � ��� ����
            label3.Height = 6; // ��������� � ��� ����
            label3.BackColor = Color.LightGray;
            label3.Location = new Point(10, 150); // �������� �����
            this.Controls.Add(label3);

            label1.BackColor = Color.FromArgb(30, 30, 30);
            label1.Font = new Font("Arial", 8, FontStyle.Bold); // �������� ������ ������
            label1.ForeColor = Color.White;
            label1.Location = new Point(80, 80); // �������� �����
            label1.Size = new Size(270, 30); // ��������� � ��� ����
            label1.AutoSize = true;

            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(36, 40); // �������� �����
            flowLayoutPanel1.Size = new Size(280, 32); // ��������� � ��� ����
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label1);

            label2.BackColor = Color.FromArgb(30, 30, 30);
            label2.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            label2.ForeColor = Color.FromArgb(99, 99, 99);
            label2.Location = new Point(10, 130); // �������� �����
            label2.Size = new Size(270, 30); // ��������� � ��� ����
            label2.AutoSize = true;
            label2.TextAlign = ContentAlignment.MiddleRight;

            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.VerticalScroll.Enabled = false;
            flowLayoutPanel2.VerticalScroll.Visible = false;
            flowLayoutPanel2.Location = new Point(35, 75); // �������� �����
            flowLayoutPanel2.Size = new Size(280, 32); // ��������� � ��� ����
            flowLayoutPanel2.Controls.Add(label2);
            this.Controls.Add(flowLayoutPanel2);

            // ��������� ������
            button1.Location = new Point(10, 210); // �������� �����
            button1.BackColor = Color.FromArgb(50, 50, 50);
            button1.Size = new Size(70, 70); // ��������� � ��� ����
            button1.ForeColor = Color.White;
            button1.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.MouseEnter += (s, e) => button1.BackColor = Color.Gray;
            button1.MouseLeave += (s, e) => button1.BackColor = Color.FromArgb(50, 50, 50);

            button2.Location = new Point(90, 210); // �������� �����
            button2.BackColor = Color.FromArgb(50, 50, 50);
            button2.Size = new Size(70, 70); // ��������� � ��� ����
            button2.ForeColor = Color.White;
            button2.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.MouseEnter += (s, e) => button2.BackColor = Color.Gray;
            button2.MouseLeave += (s, e) => button2.BackColor = Color.FromArgb(50, 50, 50);

            button3.Location = new Point(170, 210); // �������� �����
            button3.BackColor = Color.FromArgb(50, 50, 50);
            button3.Size = new Size(70, 70); // ��������� � ��� ����
            button3.ForeColor = Color.White;
            button3.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.MouseEnter += (s, e) => button3.BackColor = Color.Gray;
            button3.MouseLeave += (s, e) => button3.BackColor = Color.FromArgb(50, 50, 50);

            button4.Location = new Point(90, 290); // �������� �����
            button4.BackColor = Color.FromArgb(50, 50, 50);
            button4.Size = new Size(70, 70); // ��������� � ��� ����
            button4.ForeColor = Color.White;
            button4.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.MouseEnter += (s, e) => button4.BackColor = Color.Gray;
            button4.MouseLeave += (s, e) => button4.BackColor = Color.FromArgb(50, 50, 50);

            button5.Location = new Point(170, 290); // �������� �����
            button5.BackColor = Color.FromArgb(50, 50, 50);
            button5.Size = new Size(70, 70); // ��������� � ��� ����
            button5.ForeColor = Color.White;
            button5.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.MouseEnter += (s, e) => button5.BackColor = Color.Gray;
            button5.MouseLeave += (s, e) => button5.BackColor = Color.FromArgb(50, 50, 50);

            button6.Location = new Point(10, 290); // �������� �����
            button6.BackColor = Color.FromArgb(50, 50, 50);
            button6.Size = new Size(70, 70); // ��������� � ��� ����
            button6.ForeColor = Color.White;
            button6.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.MouseEnter += (s, e) => button6.BackColor = Color.Gray;
            button6.MouseLeave += (s, e) => button6.BackColor = Color.FromArgb(50, 50, 50);

            button7.Location = new Point(90, 370); // �������� �����
            button7.BackColor = Color.FromArgb(50, 50, 50);
            button7.Size = new Size(70, 70); // ��������� � ��� ����
            button7.ForeColor = Color.White;
            button7.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.MouseEnter += (s, e) => button7.BackColor = Color.Gray;
            button7.MouseLeave += (s, e) => button7.BackColor = Color.FromArgb(50, 50, 50);

            button8.Location = new Point(170, 370); // �������� �����
            button8.BackColor = Color.FromArgb(50, 50, 50);
            button8.Size = new Size(70, 70); // ��������� � ��� ����
            button8.ForeColor = Color.White;
            button8.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.MouseEnter += (s, e) => button8.BackColor = Color.Gray;
            button8.MouseLeave += (s, e) => button8.BackColor = Color.FromArgb(50, 50, 50);

            button9.Location = new Point(10, 370); // �������� �����
            button9.BackColor = Color.FromArgb(50, 50, 50);
            button9.Size = new Size(70, 70); // ��������� � ��� ����
            button9.ForeColor = Color.White;
            button9.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.MouseEnter += (s, e) => button9.BackColor = Color.Gray;
            button9.MouseLeave += (s, e) => button9.BackColor = Color.FromArgb(50, 50, 50);

            button10.Location = new Point(170, 450); // �������� �����
            button10.BackColor = Color.FromArgb(50, 50, 50);
            button10.Size = new Size(70, 70); // ��������� � ��� ����
            button10.ForeColor = Color.White;
            button10.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;
            button10.MouseEnter += (s, e) => button10.BackColor = Color.Gray;
            button10.MouseLeave += (s, e) => button10.BackColor = Color.FromArgb(50, 50, 50);

            button11.Location = new Point(90, 450); // �������� �����
            button11.BackColor = Color.FromArgb(50, 50, 50);
            button11.Size = new Size(70, 70); // ��������� � ��� ����
            button11.ForeColor = Color.White;
            button11.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.MouseEnter += (s, e) => button11.BackColor = Color.Gray;
            button11.MouseLeave += (s, e) => button11.BackColor = Color.FromArgb(50, 50, 50);

            button12.Location = new Point(10, 450); // �������� �����
            button12.BackColor = Color.FromArgb(50, 50, 50);
            button12.Size = new Size(70, 70); // ��������� � ��� ����
            button12.ForeColor = Color.White;
            button12.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button12.FlatStyle = FlatStyle.Flat;
            button12.FlatAppearance.BorderSize = 0;
            button12.MouseEnter += (s, e) => button12.BackColor = Color.Gray;
            button12.MouseLeave += (s, e) => button12.BackColor = Color.FromArgb(50, 50, 50);

            button13.Location = new Point(250, 450); // �������� �����
            button13.BackColor = Color.FromArgb(50, 135, 59);
            button13.Size = new Size(70, 70); // ��������� � ��� ����
            button13.ForeColor = Color.White;
            button13.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button13.FlatStyle = FlatStyle.Flat;
            button13.FlatAppearance.BorderSize = 0;
            button13.MouseEnter += (s, e) => button13.BackColor = Color.FromArgb(84, 252, 58);
            button13.MouseLeave += (s, e) => button13.BackColor = Color.FromArgb(50, 135, 59);

            button14.Location = new Point(250, 370); // �������� �����
            button14.BackColor = Color.FromArgb(50, 50, 50);
            button14.Size = new Size(70, 70); // ��������� � ��� ����
            button14.ForeColor = Color.FromArgb(84, 252, 58);
            button14.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button14.FlatStyle = FlatStyle.Flat;
            button14.FlatAppearance.BorderSize = 0;
            button14.MouseEnter += (s, e) => button14.BackColor = Color.Gray;
            button14.MouseLeave += (s, e) => button14.BackColor = Color.FromArgb(50, 50, 50);

            button15.Location = new Point(250, 290); // �������� �����
            button15.BackColor = Color.FromArgb(50, 50, 50);
            button15.Size = new Size(70, 70); // ��������� � ��� ����
            button15.ForeColor = Color.FromArgb(84, 252, 58);
            button15.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button15.FlatStyle = FlatStyle.Flat;
            button15.FlatAppearance.BorderSize = 0;
            button15.MouseEnter += (s, e) => button15.BackColor = Color.Gray;
            button15.MouseLeave += (s, e) => button15.BackColor = Color.FromArgb(50, 50, 50);

            button16.Location = new Point(250, 210); // �������� �����
            button16.BackColor = Color.FromArgb(50, 50, 50);
            button16.Size = new Size(70, 70); // ��������� � ��� ����
            button16.ForeColor = Color.FromArgb(84, 252, 58);
            button16.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button16.FlatStyle = FlatStyle.Flat;
            button16.FlatAppearance.BorderSize = 0;
            button16.MouseEnter += (s, e) => button16.BackColor = Color.Gray;
            button16.MouseLeave += (s, e) => button16.BackColor = Color.FromArgb(50, 50, 50);

            button18.Location = new Point(90, 130); // �������� �����
            button18.BackColor = Color.FromArgb(50, 50, 50);
            button18.Size = new Size(70, 70); // ��������� � ��� ����
            button18.ForeColor = Color.FromArgb(84, 252, 58);
            button18.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button18.FlatStyle = FlatStyle.Flat;
            button18.FlatAppearance.BorderSize = 0;
            button18.MouseEnter += (s, e) => button18.BackColor = Color.Gray;
            button18.MouseLeave += (s, e) => button18.BackColor = Color.FromArgb(50, 50, 50);

            button19.Location = new Point(10, 130); // �������� �����
            button19.BackColor = Color.FromArgb(50, 50, 50);
            button19.Size = new Size(70, 70); // ��������� � ��� ����
            button19.ForeColor = Color.FromArgb(252, 58, 71);
            button19.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button19.FlatStyle = FlatStyle.Flat;
            button19.FlatAppearance.BorderSize = 0;
            button19.MouseEnter += (s, e) => button19.BackColor = Color.Gray;
            button19.MouseLeave += (s, e) => button19.BackColor = Color.FromArgb(50, 50, 50);

            button20.Location = new Point(170, 130); // �������� �����
            button20.BackColor = Color.FromArgb(50, 50, 50);
            button20.Size = new Size(70, 70); // ��������� � ��� ����
            button20.ForeColor = Color.FromArgb(84, 252, 58);
            button20.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button20.FlatStyle = FlatStyle.Flat;
            button20.FlatAppearance.BorderSize = 0;
            button20.MouseEnter += (s, e) => button20.BackColor = Color.Gray;
            button20.MouseLeave += (s, e) => button20.BackColor = Color.FromArgb(50, 50, 50);

            button21.Location = new Point(250, 130); // �������� �����
            button21.BackColor = Color.FromArgb(50, 50, 50);
            button21.Size = new Size(70, 70); // ��������� � ��� ����
            button21.ForeColor = Color.FromArgb(84, 252, 58);
            button21.Font = new Font("Arial", 16, FontStyle.Bold); // �������� ������ ������
            button21.FlatStyle = FlatStyle.Flat;
            button21.FlatAppearance.BorderSize = 0;
            button21.MouseEnter += (s, e) => button21.BackColor = Color.Gray;
            button21.MouseLeave += (s, e) => button21.BackColor = Color.FromArgb(50, 50, 50);

            button17.Location = new Point(200, 50); // �������� �����
            button17.SetRadius(10);
            button17.BackColor = Color.FromArgb(30, 30, 30);
            button17.Size = new Size(60, 30); // ��������� � ��� ����
            button17.ForeColor = Color.FromArgb(50, 135, 59);
            button17.Font = new Font("Arial", 14, FontStyle.Bold); // �������� ������ ������
            button17.FlatStyle = FlatStyle.Flat;
            button17.FlatAppearance.BorderSize = 0;
            button17.MouseEnter += (s, e) => button17.BackColor = Color.Gray;
            button17.MouseEnter += (s, e) => button17.ForeColor = Color.FromArgb(84, 252, 58);
            button17.MouseLeave += (s, e) => button17.BackColor = Color.FromArgb(30, 30, 30);
            button17.MouseLeave += (s, e) => button17.ForeColor = Color.FromArgb(50, 135, 59);

            button1.Location = new Point(10, 250); // �������� ���� �� 40
            button2.Location = new Point(90, 250); // �������� ���� �� 40
            button3.Location = new Point(170, 250); // �������� ���� �� 40
            button4.Location = new Point(90, 330); // �������� ���� �� 40
            button5.Location = new Point(170, 330); // �������� ���� �� 40
            button6.Location = new Point(10, 330); // �������� ���� �� 40
            button7.Location = new Point(90, 410); // �������� ���� �� 40
            button8.Location = new Point(170, 410); // �������� ���� �� 40
            button9.Location = new Point(10, 410); // �������� ���� �� 40
            button10.Location = new Point(170, 490); // �������� ���� �� 40
            button11.Location = new Point(90, 490); // �������� ���� �� 40
            button12.Location = new Point(10, 490); // �������� ���� �� 40
            button13.Location = new Point(250, 490); // �������� ���� �� 40
            button14.Location = new Point(250, 410); // �������� ���� �� 40
            button15.Location = new Point(250, 330); // �������� ���� �� 40
            button16.Location = new Point(250, 250); // �������� ���� �� 40
            button18.Location = new Point(90, 170); // �������� ���� �� 40
            button19.Location = new Point(10, 170); // �������� ���� �� 40
            button20.Location = new Point(170, 170); // �������� ���� �� 40
            button21.Location = new Point(250, 170); // �������� ���� �� 40
            button17.Location = new Point(260, 110); // �������� ���� �� 40
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }

            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "7";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "7";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "7";
                    m_numbers_list[m_current_number_index] += "7";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }

            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "8";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "8";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "8";
                    m_numbers_list[m_current_number_index] += "8";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "9";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "9";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "9";
                    m_numbers_list[m_current_number_index] += "9";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "4";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "4";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "4";
                    m_numbers_list[m_current_number_index] += "4";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "5";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "5";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "5";
                    m_numbers_list[m_current_number_index] += "5";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "6";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "6";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "6";
                    m_numbers_list[m_current_number_index] += "6";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "1";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "1";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "1";
                    m_numbers_list[m_current_number_index] += "1";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "2";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "2";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "2";
                    m_numbers_list[m_current_number_index] += "2";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }

                m_numbers_list[m_current_number_index] += "3";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "3";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                else
                {
                    m_equation += "3";
                    m_numbers_list[m_current_number_index] += "3";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (!IS_REMAINDER_OPERATOR)
            {
                m_equation += " + ";
                m_current_number_index++;
                m_operators_list.Add("+");
                m_numbers_list.Add("");
                label1.Text = m_equation;
                fitSize();
                label2.Text = "";
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (m_numbers_list[m_current_number_index].Contains('E'))
            {
                if (m_equation[m_equation.Length - 1] == ')')
                {
                    m_equation = "";
                    for (int i = 0; i < m_numbers_list.Count; i++)
                    {
                        if (i != (m_numbers_list.Count() - 1))
                        {
                            if (m_numbers_list[i][0] == 'q')
                            {
                                string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                num = num.Replace(',', '.');
                                m_equation += "\u221A(" + num + ")";

                            }
                            if (m_numbers_list[i].Length >= 2)
                            {
                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                                {
                                    string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                    num = num.Replace(',', '.');
                                    m_equation += "(-" + num + ")";


                                }

                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                                {
                                    string num = m_numbers_list[i].Substring(2);
                                    num = num.Replace(',', '.');
                                    m_equation += "(-\u221A(" + num + "))";

                                }

                                else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                                {
                                    string num = m_numbers_list[i];
                                    num = num.Replace(',', '.');
                                    m_equation += num;

                                }

                            }
                            else
                            {
                                string num = m_numbers_list[i];
                                num = num.Replace(',', '.');
                                m_equation += num;

                            }
                        }

                        if (m_operators_list.Count > i && m_operators_list.Count != 0)
                        {
                            m_equation += " " + m_operators_list[i] + " ";
                        }

                        else
                        {
                            if (m_numbers_list[i].Length >= 2)
                            {
                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    string num = m_numbers_list[i];
                                    num = num.Replace(',', '.');
                                    m_equation += num;

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }

                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    m_equation += "\u221A(" + m_numbers_list[i].Substring(1) + ")";

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }

                                if (m_numbers_list[i][0] == 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    m_equation += m_numbers_list[i];

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }
                            }

                        }

                    }
                }

                m_equation = m_equation.Substring(0, m_equation.Length - 1);
                m_numbers_list[m_current_number_index] = m_numbers_list[m_current_number_index].Substring(0, m_numbers_list[m_current_number_index].Length - 1);
                label1.Text = m_equation;
                fitSize();

                if (m_current_number_index > 0 && m_numbers_list[m_current_number_index].Length >= 1 && !m_equation.Contains('E'))
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                    return;
                }
                if (m_current_number_index > 0 && m_equation.Substring(m_equation.Length - 1) != "E" && m_equation.Substring(m_equation.Length - 1) != "+" && m_equation.Substring(m_equation.Length - 1) != ".")
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                    return;
                }

                else
                {
                    label2.Text = "";
                    return;
                }
            }

            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x " || str == "\u00F7 " ||
                    str == "% ")
                {
                    if (str == "% ")
                    {
                        IS_REMAINDER_OPERATOR = false;
                    }

                    m_equation = m_equation.Substring(0, m_equation.Length - 3);
                    m_numbers_list.RemoveAt(m_current_number_index);
                    m_operators_list.RemoveAt(m_current_number_index - 1);
                    m_current_number_index--;
                    label1.Text = m_equation;
                    fitSize();

                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }

                    else
                    {
                        label2.Text = "";
                    }
                    return;
                }

            }

            if (m_equation == "") { return; }



            if (m_numbers_list[m_current_number_index].Length >= 1)
            {
                if (m_equation[m_equation.Length - 1] == ')')
                {
                    m_equation = "";
                    for (int i = 0; i < m_numbers_list.Count; i++)
                    {
                        if (i != (m_numbers_list.Count() - 1))
                        {
                            if (m_numbers_list[i][0] == 'q')
                            {
                                string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                num = num.Replace(',', '.');
                                m_equation += "\u221A(" + num + ")";

                            }
                            if (m_numbers_list[i].Length >= 2)
                            {
                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                                {
                                    string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                    num = num.Replace(',', '.');
                                    m_equation += "(-" + num + ")";


                                }

                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                                {
                                    string num = m_numbers_list[i].Substring(2);
                                    num = num.Replace(',', '.');
                                    m_equation += "(-\u221A(" + num + "))";

                                }

                                else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                                {
                                    string num = m_numbers_list[i];
                                    num = num.Replace(',', '.');
                                    m_equation += num;

                                }

                            }
                            else
                            {
                                string num = m_numbers_list[i];
                                num = num.Replace(',', '.');
                                m_equation += num;

                            }
                        }

                        if (m_operators_list.Count > i && m_operators_list.Count != 0)
                        {
                            m_equation += " " + m_operators_list[i] + " ";
                        }

                        else
                        {
                            if (m_numbers_list[i].Length >= 2)
                            {
                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    string num = m_numbers_list[i];
                                    num = num.Replace(',', '.');
                                    m_equation += num;

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }

                                if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    m_equation += "\u221A(" + m_numbers_list[i].Substring(1) + ")";

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }

                                if (m_numbers_list[i][0] == 'q')
                                {
                                    m_numbers_list[i] = m_numbers_list[i].Substring(1);
                                    m_equation += m_numbers_list[i];

                                    string f_equation = m_equation;
                                    f_equation = f_equation.Replace(",", ".");
                                    label1.Text = f_equation;
                                    if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                                    {
                                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                        string res = calculator.getResult();
                                        if (res.Contains(','))
                                        {
                                            res = res.Replace(',', '.');
                                        }
                                        label2.Text = res;
                                    }
                                    else
                                    {
                                        label2.Text = "";
                                    }
                                    return;
                                }
                            }

                        }

                    }
                }



                m_equation = m_equation.Substring(0, m_equation.Length - 1);
                m_numbers_list[m_current_number_index] = m_numbers_list[m_current_number_index].Substring(0, m_numbers_list[m_current_number_index].Length - 1);

                string final_equation = m_equation;
                final_equation = final_equation.Replace(",", ".");
                label1.Text = final_equation;

                if (m_current_number_index > 0 && m_numbers_list[m_current_number_index].Length >= 1 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                    return;
                }

                if (m_numbers_list[m_current_number_index].Length == 0)
                {
                    label2.Text = "";
                }
            }


        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length >= 1 && m_numbers_list[m_current_number_index][0] == 'q')
            {
                m_equation = "";
                for (int i = 0; i < m_numbers_list.Count; i++)
                {
                    if (i != (m_numbers_list.Count() - 1))
                    {
                        if (m_numbers_list[i][0] == 'q')
                        {
                            string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                            num = num.Replace(',', '.');
                            m_equation += "\u221A(" + num + ")";

                        }
                        if (m_numbers_list[i].Length >= 2)
                        {
                            if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                            {
                                string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                num = num.Replace(',', '.');
                                m_equation += "(-" + num + ")";


                            }

                            if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                            {
                                string num = m_numbers_list[i].Substring(2);
                                num = num.Replace(',', '.');
                                m_equation += "(-\u221A(" + num + "))";

                            }

                            else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                            {
                                string num = m_numbers_list[i];
                                num = num.Replace(',', '.');
                                m_equation += num;

                            }

                        }
                        else
                        {
                            string num = m_numbers_list[i];
                            num = num.Replace(',', '.');
                            m_equation += num;

                        }
                    }

                    if (m_operators_list.Count > i && m_operators_list.Count != 0)
                    {
                        m_equation += " " + m_operators_list[i] + " ";
                    }

                    else
                    {
                        if (m_numbers_list[i][0] == 'q')
                        {
                            m_numbers_list[i] = m_numbers_list[i].Substring(1);
                            m_equation += m_numbers_list[i];

                            string f_equation = m_equation;
                            f_equation = f_equation.Replace(",", ".");
                            label1.Text = f_equation;
                            if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                            {
                                CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                string res = calculator.getResult();
                                if (res.Contains(','))
                                {
                                    res = res.Replace(',', '.');
                                }
                                label2.Text = res;
                            }
                            else
                            {
                                label2.Text = "";
                            }
                            return;
                        }
                    }
                }
            }

            if (m_numbers_list[m_current_number_index].Contains("-")) { return; }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == 'E' || m_numbers_list[m_current_number_index].Contains("-"))
                {
                    label2.Text = "invalid";
                    return;
                }

                if (str[1] == ')')
                {
                    return;
                }
            }

            if (m_equation == "") { return; }

            m_equation = "";
            for (int i = 0; i < m_numbers_list.Count; i++)
            {
                if (i != (m_numbers_list.Count() - 1))
                {
                    if (m_numbers_list[i][0] == 'q')
                    {
                        m_equation += "\u221A(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";
                    }

                    if (m_numbers_list[i].Length >= 2)
                    {
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                        {
                            m_equation += "(-" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";
                        }

                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                        {
                            m_equation += "(-\u221A(" + m_numbers_list[i].Substring(2) + "))";
                        }

                        else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                        {
                            m_equation += m_numbers_list[i];

                        }

                    }
                    else
                    {
                        m_equation += m_numbers_list[i];

                    }
                }

                if (m_operators_list.Count > i && m_operators_list.Count != 0)
                {
                    m_equation += " " + m_operators_list[i] + " ";
                }

                else
                {
                    if (m_numbers_list[i][0] == 'q')
                    {
                        return;
                    }
                    if (m_numbers_list[i][0] == 's')
                    {
                        return; //todo mightbe should delete operator
                    }
                    else
                    {
                        m_equation += "\u221A(" + m_numbers_list[i] + ")";

                        string final_equation = m_equation;
                        final_equation = final_equation.Replace(",", ".");
                        label1.Text = final_equation;

                        m_numbers_list[m_numbers_list.Count - 1] = "q" + m_numbers_list[m_numbers_list.Count - 1];

                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }

                }
            }

        }








        private void button19_Click(object sender, EventArgs e) // here C
        {
            m_numbers_list.Clear();
            m_numbers_list.Add("");
            m_operators_list.Clear();
            m_current_number_index = 0;

            m_equation = "";
            label1.Text = "";
            label2.Text = "";
            IS_REMAINDER_OPERATOR = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_equation.Length - 1 == -1) { return; }
            if ((m_equation[m_equation.Length - 1] != '.' && m_equation[m_equation.Length - 1] != 'E' && m_equation[m_equation.Length - 1] != ')') && m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER - 1
                && m_numbers_list[m_current_number_index] != "" && !m_numbers_list[m_current_number_index].Contains(',') && !m_numbers_list[m_current_number_index].Contains('E'))
            {
                m_numbers_list[m_current_number_index] += ",";

                m_equation += ".";
                label1.Text = m_equation;
                fitSize();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (m_current_number_index == 0)
            {
                IS_REMAINDER_OPERATOR = true;
                m_equation += " % ";
                m_current_number_index++;
                m_operators_list.Add("%");
                m_numbers_list.Add("");
                label1.Text = m_equation;
                fitSize();
                label2.Text = "";
            }

            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (!IS_REMAINDER_OPERATOR)
            {
                m_equation += " - ";
                m_current_number_index++;
                m_operators_list.Add("-");
                m_numbers_list.Add("");
                label1.Text = m_equation;
                fitSize();
                label2.Text = "";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (!IS_REMAINDER_OPERATOR)
            {
                m_equation += " x ";
                m_current_number_index++;
                m_operators_list.Add("x");
                m_numbers_list.Add("");
                label1.Text = m_equation;
                fitSize();
                label2.Text = "";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (!IS_REMAINDER_OPERATOR)
            {
                m_equation += " \u00F7 ";
                m_current_number_index++;
                m_operators_list.Add("\u00F7");
                m_numbers_list.Add("");
                label1.Text = m_equation;
                fitSize();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E')
                {
                    label2.Text = "invalid";
                    return;
                }
            }
            if (m_equation == "-") { return; }
            if (m_equation == "") { return; }

            if (m_numbers_list.Count == 1 && m_operators_list.Count == 0)
            {
                if (m_numbers_list[0][0] == 'q')
                {
                    m_numbers_list.Clear();
                    m_operators_list.Clear();
                    m_current_number_index = 0;
                    m_numbers_list.Add(label2.Text);
                    m_equation = label2.Text;
                    label1.Text = m_numbers_list[0];
                    label2.Text = "";

                }
                return;
            }
            

            m_numbers_list.Clear();
            m_operators_list.Clear();
            m_current_number_index = 0;
            string res = label2.Text.Replace(".", ",");
            m_numbers_list.Add(res);
            m_equation = label2.Text;
            label1.Text = label2.Text;
            fitSize();
            label2.Text = "";
            IS_REMAINDER_OPERATOR = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Contains("-") && !m_numbers_list[m_current_number_index].Contains("("))
            {
                string num = m_numbers_list[m_current_number_index].Substring(1);
                m_numbers_list[m_current_number_index] = num;
                m_equation = num;
                label1.Text = num;
                return;
            }

            if (m_numbers_list[m_current_number_index].Length >= 1 && m_numbers_list[m_current_number_index][0] == 's')
            {
                m_equation = "";
                for (int i = 0; i < m_numbers_list.Count; i++)
                {
                    if (i != (m_numbers_list.Count() - 1))
                    {
                        if (m_numbers_list[i][0] == 'q')
                        {
                            string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                            num = num.Replace(',', '.');
                            m_equation += "\u221A(" + num + ")";

                        }
                        if (m_numbers_list[i].Length >= 2)
                        {
                            if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                            {
                                string num = m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1);
                                num = num.Replace(',', '.');
                                m_equation += "(-" + num + ")";


                            }

                            if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                            {
                                string num = m_numbers_list[i].Substring(2);
                                num = num.Replace(',', '.');
                                m_equation += "(-\u221A(" + num + "))";

                            }

                            else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                            {
                                string num = m_numbers_list[i];
                                num = num.Replace(',', '.');
                                m_equation += num;

                            }

                        }
                        else
                        {
                            string num = m_numbers_list[i];
                            num = num.Replace(',', '.');
                            m_equation += num;

                        }
                    }

                    if (m_operators_list.Count > i && m_operators_list.Count != 0)
                    {
                        m_equation += " " + m_operators_list[i] + " ";
                    }

                    else
                    {
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                        {
                            m_numbers_list[i] = m_numbers_list[i].Substring(1);
                            string num = m_numbers_list[i];
                            num = num.Replace(',', '.');
                            m_equation += num;

                            string f_equation = m_equation;
                            f_equation = f_equation.Replace(",", ".");
                            label1.Text = f_equation;
                            if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                            {
                                CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                string res = calculator.getResult();
                                if (res.Contains(','))
                                {
                                    res = res.Replace(',', '.');
                                }
                                label2.Text = res;
                            }
                            else
                            {
                                label2.Text = "";
                            }
                            return;
                        }
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                        {
                            m_numbers_list[i] = m_numbers_list[i].Substring(1);
                            m_equation += "\u221A(" + m_numbers_list[i].Substring(1) + ")";

                            string f_equation = m_equation;
                            f_equation = f_equation.Replace(",", ".");
                            label1.Text = f_equation;
                            if (m_current_number_index > 0 || (m_current_number_index == 0 && (m_numbers_list[0].StartsWith('q') || m_numbers_list[0].StartsWith('s'))))
                            {
                                CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                                string res = calculator.getResult();
                                if (res.Contains(','))
                                {
                                    res = res.Replace(',', '.');
                                }
                                label2.Text = res;
                            }
                            else
                            {
                                label2.Text = "";
                            }
                            return;
                        }
                    }
                }
            }
            if (m_equation == "") { return; }
            if (m_numbers_list[m_current_number_index] == "0") { return; }
            
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "\u00F7 " || str == "% " || str[1] == '.' || str[1] == 'E')
                {
                    label2.Text = "invalid";
                    return;
                }
            }


            m_equation = "";
            for (int i = 0; i < m_numbers_list.Count; i++)
            {
                if (i != (m_numbers_list.Count() - 1))
                {
                    if (m_numbers_list[i][0] == 'q')
                    {
                        m_equation += "\u221A(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";

                    }
                    if (m_numbers_list[i].Length >= 2)
                    {
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                        {
                            m_equation += "(-" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";

                        }

                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                        {
                            m_equation += "(-\u221A(" + m_numbers_list[i].Substring(2) + "))";

                        }

                        else if (m_numbers_list[i][0] != 's' && m_numbers_list[i][1] != 'q' && m_numbers_list[i][0] != 'q')
                        {
                            m_equation += m_numbers_list[i];

                        }

                    }
                    else
                    {
                        m_equation += m_numbers_list[i];

                    }
                }

                if (m_operators_list.Count > i && m_operators_list.Count != 0)
                {
                    m_equation += " " + m_operators_list[i] + " ";
                }

                else
                {
                    if (m_numbers_list[i][0] == 'q')
                    {
                        m_equation += "(-\u221A(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + "))";

                        string final_equation = m_equation;
                        final_equation = final_equation.Replace(",", ".");
                        label1.Text = final_equation;
                        m_numbers_list[m_numbers_list.Count - 1] = "s" + m_numbers_list[m_numbers_list.Count - 1];
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                        return;
                    }
                    
                    else
                    {
                        m_equation += "(-" + m_numbers_list[i] + ")";

                        string final_equation = m_equation;
                        final_equation = final_equation.Replace(",", ".");
                        label1.Text = final_equation;

                        m_numbers_list[m_numbers_list.Count - 1] = "s" + m_numbers_list[m_numbers_list.Count - 1];

                        if (m_current_number_index > 0)
                        {
                            CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                            label2.Text = calculator.getResult();
                        }
                        else
                        {
                            label2.Text = "";
                        }

                    }

                }

            }

        }

        private void button11_Click(object sender, EventArgs e) // 0
        {
            if (label1.Text.Length >= 150)
            {
                label2.Text = "Limit reached";
                return;
            }
            if (m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER)
            {
                if (m_numbers_list[m_current_number_index].Length >= 1)
                {
                    if (m_equation.Substring(m_equation.Length - 1) == ")")
                    {
                        return;
                    }
                }
                if (m_numbers_list[m_current_number_index].Length == 1 && m_numbers_list[m_current_number_index][m_numbers_list[m_current_number_index].Length - 1] == '0') { return; }
                if (m_operators_list.Count != 0)
                {
                    if (m_operators_list[m_operators_list.Count-1] == "\u00F7" && m_numbers_list[m_numbers_list.Count - 1] == "")
                    {
                        return;
                    }
                }

                m_numbers_list[m_current_number_index] += "0";

                if (m_current_number_index > 0)
                {
                    CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                    label2.Text = calculator.getResult();
                }

                m_equation += "0";
                label1.Text = m_equation;
                fitSize();
            }
            else if (m_equation.Contains('E'))
            {

                int indexPlus = m_equation.IndexOf('+');
                if (indexPlus < 0) { return; }
                if (m_equation.Substring(indexPlus).Length >= 3)
                {
                    return;
                }
                if (indexPlus + 1 == m_numbers_list[m_current_number_index].Length)
                {
                    return;
                }
                else
                {
                    m_equation += "0";
                    m_numbers_list[m_current_number_index] += "0";
                    label1.Text = m_equation;
                    fitSize();
                    if (m_current_number_index > 0)
                    {
                        CalculatorMath.Calculator calculator = new CalculatorMath.Calculator(m_numbers_list, m_operators_list);
                        label2.Text = calculator.getResult();
                    }
                }
            }
        }
    }
}
