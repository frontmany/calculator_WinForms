using CalculatorMath;
using System.DirectoryServices;
using CalculatorUI;
using System.Windows.Forms;
using System.Reflection.Emit;

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

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Size = new Size(600, 870);
            
            CalcRoundedLabel label3 = new CalcRoundedLabel();
            label3.Width = 500;
            label3.Height = 8; // ������ �����
            label3.BackColor = Color.LightGray; // ������-����� ����
            label3.Location = new Point(50, 215);
            this.Controls.Add(label3);



            label1.BackColor = Color.FromArgb(30, 30, 30);
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(180, 40);
            label1.Size = new Size(540, 60);
            label1.AutoSize = true;

            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.VerticalScroll.Enabled = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Location = new Point(55, 30);
            flowLayoutPanel1.Size = new Size(480, 65);
            flowLayoutPanel1.Controls.Add(label1);

            
            button1.Location = new Point(50, 370);
            button1.BackColor = Color.FromArgb(50, 50, 50);
            button1.Size = new Size(90, 90);
            button1.ForeColor = Color.White;
            button1.Font = new Font("Arial", 16, FontStyle.Bold);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.MouseEnter += (s, e) => button1.BackColor = Color.Gray;
            button1.MouseLeave += (s, e) => button1.BackColor = Color.FromArgb(50, 50, 50);

            button2.Location = new Point(185, 370);
            button2.BackColor = Color.FromArgb(50, 50, 50);
            button2.Size = new Size(90, 90);
            button2.ForeColor = Color.White;
            button2.Font = new Font("Arial", 16, FontStyle.Bold);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.MouseEnter += (s, e) => button2.BackColor = Color.Gray;
            button2.MouseLeave += (s, e) => button2.BackColor = Color.FromArgb(50, 50, 50);

            button3.Location = new Point(315, 370);
            button3.BackColor = Color.FromArgb(50, 50, 50);
            button3.Size = new Size(90, 90);
            button3.ForeColor = Color.White;
            button3.Font = new Font("Arial", 16, FontStyle.Bold);
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.MouseEnter += (s, e) => button3.BackColor = Color.Gray;
            button3.MouseLeave += (s, e) => button3.BackColor = Color.FromArgb(50, 50, 50);

            button4.Location = new Point(185, 475);
            button4.BackColor = Color.FromArgb(50, 50, 50);
            button4.Size = new Size(90, 90);
            button4.ForeColor = Color.White;
            button4.Font = new Font("Arial", 16, FontStyle.Bold);
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.MouseEnter += (s, e) => button4.BackColor = Color.Gray;
            button4.MouseLeave += (s, e) => button4.BackColor = Color.FromArgb(50, 50, 50);

            button5.Location = new Point(315, 475);
            button5.BackColor = Color.FromArgb(50, 50, 50);
            button5.Size = new Size(90, 90);
            button5.ForeColor = Color.White;
            button5.Font = new Font("Arial", 16, FontStyle.Bold);
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.MouseEnter += (s, e) => button5.BackColor = Color.Gray;
            button5.MouseLeave += (s, e) => button5.BackColor = Color.FromArgb(50, 50, 50);

            button6.Location = new Point(50, 475);
            button6.BackColor = Color.FromArgb(50, 50, 50);
            button6.Size = new Size(90, 90);
            button6.ForeColor = Color.White;
            button6.Font = new Font("Arial", 16, FontStyle.Bold);
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.MouseEnter += (s, e) => button6.BackColor = Color.Gray;
            button6.MouseLeave += (s, e) => button6.BackColor = Color.FromArgb(50, 50, 50);

            button7.Location = new Point(185, 580);
            button7.BackColor = Color.FromArgb(50, 50, 50);
            button7.Size = new Size(90, 90);
            button7.ForeColor = Color.White;
            button7.Font = new Font("Arial", 16, FontStyle.Bold);
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.MouseEnter += (s, e) => button7.BackColor = Color.Gray;
            button7.MouseLeave += (s, e) => button7.BackColor = Color.FromArgb(50, 50, 50);

            button8.Location = new Point(315, 580);
            button8.BackColor = Color.FromArgb(50, 50, 50);
            button8.Size = new Size(90, 90);
            button8.ForeColor = Color.White;
            button8.Font = new Font("Arial", 16, FontStyle.Bold);
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.MouseEnter += (s, e) => button8.BackColor = Color.Gray;
            button8.MouseLeave += (s, e) => button8.BackColor = Color.FromArgb(50, 50, 50);

            button9.Location = new Point(50, 580);
            button9.BackColor = Color.FromArgb(50, 50, 50);
            button9.Size = new Size(90, 90);
            button9.ForeColor = Color.White;
            button9.Font = new Font("Arial", 16, FontStyle.Bold);
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.MouseEnter += (s, e) => button9.BackColor = Color.Gray;
            button9.MouseLeave += (s, e) => button9.BackColor = Color.FromArgb(50, 50, 50);

            button10.Location = new Point(315, 685);
            button10.BackColor = Color.FromArgb(50, 50, 50);
            button10.Size = new Size(90, 90);
            button10.ForeColor = Color.White;
            button10.Font = new Font("Arial", 16, FontStyle.Bold);
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;
            button10.MouseEnter += (s, e) => button10.BackColor = Color.Gray;
            button10.MouseLeave += (s, e) => button10.BackColor = Color.FromArgb(50, 50, 50);

            button11.Location = new Point(185, 685);
            button11.BackColor = Color.FromArgb(50, 50, 50);
            button11.Size = new Size(90, 90);
            button11.ForeColor = Color.White;
            button11.Font = new Font("Arial", 16, FontStyle.Bold);
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.MouseEnter += (s, e) => button11.BackColor = Color.Gray;
            button11.MouseLeave += (s, e) => button11.BackColor = Color.FromArgb(50, 50, 50);

            button12.Location = new Point(50, 685);
            button12.BackColor = Color.FromArgb(50, 50, 50);
            button12.Size = new Size(90, 90);
            button12.ForeColor = Color.White;
            button12.Font = new Font("Arial", 16, FontStyle.Bold);
            button12.FlatStyle = FlatStyle.Flat;
            button12.FlatAppearance.BorderSize = 0;
            button12.MouseEnter += (s, e) => button12.BackColor = Color.Gray;
            button12.MouseLeave += (s, e) => button12.BackColor = Color.FromArgb(50, 50, 50);

            button13.Location = new Point(445, 685);
            button13.BackColor = Color.FromArgb(50, 50, 50);
            button13.Size = new Size(90, 90);
            button13.ForeColor = Color.White;
            button13.Font = new Font("Arial", 16, FontStyle.Bold);
            button13.FlatStyle = FlatStyle.Flat;
            button13.FlatAppearance.BorderSize = 0;
            button13.MouseEnter += (s, e) => button13.BackColor = Color.Gray;
            button13.MouseLeave += (s, e) => button13.BackColor = Color.FromArgb(50, 50, 50);

            button14.Location = new Point(445, 580);
            button14.BackColor = Color.FromArgb(50, 50, 50);
            button14.Size = new Size(90, 90);
            button14.ForeColor = Color.White;
            button14.Font = new Font("Arial", 16, FontStyle.Bold);
            button14.FlatStyle = FlatStyle.Flat;
            button14.FlatAppearance.BorderSize = 0;
            button14.MouseEnter += (s, e) => button14.BackColor = Color.Gray;
            button14.MouseLeave += (s, e) => button14.BackColor = Color.FromArgb(50, 50, 50);

            button15.Location = new Point(445, 475);
            button15.BackColor = Color.FromArgb(50, 50, 50);
            button15.Size = new Size(90, 90);
            button15.ForeColor = Color.White;
            button15.Font = new Font("Arial", 16, FontStyle.Bold);
            button15.FlatStyle = FlatStyle.Flat;
            button15.FlatAppearance.BorderSize = 0;
            button15.MouseEnter += (s, e) => button15.BackColor = Color.Gray;
            button15.MouseLeave += (s, e) => button15.BackColor = Color.FromArgb(50, 50, 50);

            button16.Location = new Point(445, 370);
            button16.BackColor = Color.FromArgb(50, 50, 50);
            button16.Size = new Size(90, 90);
            button16.ForeColor = Color.White;
            button16.Font = new Font("Arial", 16, FontStyle.Bold);
            button16.FlatStyle = FlatStyle.Flat;
            button16.FlatAppearance.BorderSize = 0;
            button16.MouseEnter += (s, e) => button16.BackColor = Color.Gray;
            button16.MouseLeave += (s, e) => button16.BackColor = Color.FromArgb(50, 50, 50);

            button18.Location = new Point(185, 265);
            button18.BackColor = Color.FromArgb(50, 50, 50);
            button18.Size = new Size(90, 90);
            button18.ForeColor = Color.White;
            button18.Font = new Font("Arial", 16, FontStyle.Bold);
            button18.FlatStyle = FlatStyle.Flat;
            button18.FlatAppearance.BorderSize = 0;
            button18.MouseEnter += (s, e) => button18.BackColor = Color.Gray;
            button18.MouseLeave += (s, e) => button18.BackColor = Color.FromArgb(50, 50, 50);

            button19.Location = new Point(50, 265);
            button19.BackColor = Color.FromArgb(50, 50, 50);
            button19.Size = new Size(90, 90);
            button19.ForeColor = Color.White;
            button19.Font = new Font("Arial", 16, FontStyle.Bold);
            button19.FlatStyle = FlatStyle.Flat;
            button19.FlatAppearance.BorderSize = 0;
            button19.MouseEnter += (s, e) => button19.BackColor = Color.Gray;
            button19.MouseLeave += (s, e) => button19.BackColor = Color.FromArgb(50, 50, 50);

            button20.Location = new Point(315, 265);
            button20.BackColor = Color.FromArgb(50, 50, 50);
            button20.Size = new Size(90, 90);
            button20.ForeColor = Color.White;
            button20.Font = new Font("Arial", 16, FontStyle.Bold);
            button20.FlatStyle = FlatStyle.Flat;
            button20.FlatAppearance.BorderSize = 0;
            button20.MouseEnter += (s, e) => button20.BackColor = Color.Gray;
            button20.MouseLeave += (s, e) => button20.BackColor = Color.FromArgb(50, 50, 50);

            button21.Location = new Point(445, 265);
            button21.BackColor = Color.FromArgb(50, 50, 50);
            button21.Size = new Size(90, 90);
            button21.ForeColor = Color.White;
            button21.Font = new Font("Arial", 16, FontStyle.Bold);
            button21.FlatStyle = FlatStyle.Flat;
            button21.FlatAppearance.BorderSize = 0;
            button21.MouseEnter += (s, e) => button21.BackColor = Color.Gray;
            button21.MouseLeave += (s, e) => button21.BackColor = Color.FromArgb(50, 50, 50);

            button17.Location = new Point(450, 145);
            button17.SetRadius(10);
            button17.BackColor = Color.FromArgb(50, 50, 50);
            button17.Size = new Size(80, 45);
            button17.ForeColor = Color.White;
            button17.Font = new Font("Arial", 15, FontStyle.Bold);
            button17.FlatStyle = FlatStyle.Flat;
            button17.FlatAppearance.BorderSize = 0;
            button17.MouseEnter += (s, e) => button17.BackColor = Color.Gray;
            button17.MouseLeave += (s, e) => button17.BackColor = Color.FromArgb(50, 50, 50);

        }


        private void button1_Click(object sender, EventArgs e)
        {
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
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
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
                                m_equation += "sqrt(" + num + ")";

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
                                    m_equation += "(-sqrt(" + num + "))";

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
                                    m_equation += "sqrt(" + m_numbers_list[i].Substring(1) + ")";

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

                if (str == "+ " || str == "- " || str == "x " || str == "/ " ||
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
                                m_equation += "sqrt(" + num + ")";

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
                                    m_equation += "(-sqrt(" + num + "))";

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
                                    m_equation += "sqrt(" + m_numbers_list[i].Substring(1) + ")";

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
                            m_equation += "sqrt(" + num + ")";

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
                                m_equation += "(-sqrt(" + num + "))";

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
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == 'E' || m_numbers_list[m_current_number_index].Contains("-"))
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
                        m_equation += "sqrt(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";
                    }

                    if (m_numbers_list[i].Length >= 2)
                    {
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                        {
                            m_equation += "(-" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";
                        }

                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                        {
                            m_equation += "(-sqrt(" + m_numbers_list[i].Substring(2) + "))";
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
                        m_equation += "sqrt(" + m_numbers_list[i] + ")";

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
            if (m_equation.Length - 1 == -1) { return; }
            if ((m_equation[m_equation.Length - 1] != '.' && m_equation[m_equation.Length - 1] != 'E' && m_equation[m_equation.Length - 1] != ')') && m_numbers_list[m_current_number_index].Length <= MAX_LENGTH_NUMBER - 1
                && m_numbers_list[m_current_number_index] != "" && !m_equation.Contains('.'))
            {
                m_numbers_list[m_current_number_index] += ",";

                m_equation += ".";
                label1.Text = m_equation;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
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
                label2.Text = "";
            }

            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
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
                label2.Text = "";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
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
                label2.Text = "";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string str = "";
            if (m_equation.Length >= 2)
            {
                str += m_equation[m_equation.Length - 2];
                str += m_equation[m_equation.Length - 1];

                if (str == "+ " || str == "- " || str == "x "
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E') { return; }
            }
            if (m_equation == "-") { return; }
            else if (m_equation == "") { return; }

            if (!IS_REMAINDER_OPERATOR)
            {
                m_equation += " / ";
                m_current_number_index++;
                m_operators_list.Add("/");
                m_numbers_list.Add("");
                label1.Text = m_equation;
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
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == '+' || str[1] == 'E')
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
            label2.Text = "";
            IS_REMAINDER_OPERATOR = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
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
                            m_equation += "sqrt(" + num + ")";

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
                                m_equation += "(-sqrt(" + num + "))";

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
                            m_equation += "sqrt(" + m_numbers_list[i].Substring(1) + ")";

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
                    || str == "/ " || str == "% " || str[1] == '.' || str[1] == 'E')
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
                        m_equation += "sqrt(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";

                    }
                    if (m_numbers_list[i].Length >= 2)
                    {
                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] != 'q')
                        {
                            m_equation += "(-" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + ")";

                        }

                        if (m_numbers_list[i][0] == 's' && m_numbers_list[i][1] == 'q')
                        {
                            m_equation += "(-sqrt(" + m_numbers_list[i].Substring(2) + "))";

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
                        m_equation += "(-sqrt(" + m_numbers_list[i].Substring(1, m_numbers_list[i].Length - 1) + "))";

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
                    if (m_operators_list[m_operators_list.Count-1] == "/" && m_numbers_list[m_numbers_list.Count - 1] == "")
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
