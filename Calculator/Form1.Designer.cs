using CalculatorUI;

namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new CalcButton();
            button2 = new CalcButton();
            button3 = new CalcButton();
            button4 = new CalcButton();
            button5 = new CalcButton();
            button6 = new CalcButton();
            button7 = new CalcButton();
            button8 = new CalcButton();
            button9 = new CalcButton();
            button10 = new CalcButton();
            button11 = new CalcButton();
            button12 = new CalcButton();
            button13 = new CalcButton();
            button14 = new CalcButton();
            button15 = new CalcButton();
            button16 = new CalcButton();
            button17 = new CalcButton();
            button18 = new CalcButton();
            button20 = new CalcButton();
            label2 = new Label();
            button19 = new CalcButton();
            button21 = new CalcButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(231, 24);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(39, 201);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "7";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(173, 201);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 2;
            button2.Text = "8";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(303, 201);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "9";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(303, 278);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 6;
            button4.Text = "6";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(173, 278);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(39, 278);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 4;
            button6.Text = "4";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(303, 360);
            button7.Name = "button7";
            button7.Size = new Size(112, 34);
            button7.TabIndex = 9;
            button7.Text = "3";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(173, 360);
            button8.Name = "button8";
            button8.Size = new Size(112, 34);
            button8.TabIndex = 8;
            button8.Text = "2";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(39, 360);
            button9.Name = "button9";
            button9.Size = new Size(112, 34);
            button9.TabIndex = 7;
            button9.Text = "1";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(303, 443);
            button10.Name = "button10";
            button10.Size = new Size(112, 34);
            button10.TabIndex = 12;
            button10.Text = ".";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(173, 443);
            button11.Name = "button11";
            button11.Size = new Size(112, 34);
            button11.TabIndex = 11;
            button11.Text = "0";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(39, 443);
            button12.Name = "button12";
            button12.Size = new Size(112, 34);
            button12.TabIndex = 10;
            button12.Text = "+/-";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(452, 443);
            button13.Name = "button13";
            button13.Size = new Size(112, 34);
            button13.TabIndex = 16;
            button13.Text = "=";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Location = new Point(452, 360);
            button14.Name = "button14";
            button14.Size = new Size(112, 34);
            button14.TabIndex = 15;
            button14.Text = "+";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(452, 278);
            button15.Name = "button15";
            button15.Size = new Size(112, 34);
            button15.TabIndex = 14;
            button15.Text = "-";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(452, 201);
            button16.Name = "button16";
            button16.Size = new Size(112, 34);
            button16.TabIndex = 13;
            button16.Text = "х";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(452, 56);
            button17.Name = "button17";
            button17.Size = new Size(112, 34);
            button17.TabIndex = 20;
            button17.Text = "delete";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button18
            // 
            button18.Location = new Point(173, 126);
            button18.Name = "button18";
            button18.Size = new Size(112, 34);
            button18.TabIndex = 19;
            button18.Text = "sqrt";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button20
            // 
            button20.Location = new Point(303, 126);
            button20.Name = "button20";
            button20.Size = new Size(112, 34);
            button20.TabIndex = 17;
            button20.Text = "%";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 65);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 21;
            // 
            // button19
            // 
            button19.Location = new Point(39, 126);
            button19.Name = "button19";
            button19.Size = new Size(112, 34);
            button19.TabIndex = 22;
            button19.Text = "C";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button21
            // 
            button21.Location = new Point(452, 126);
            button21.Name = "button21";
            button21.Size = new Size(112, 34);
            button21.TabIndex = 23;
            button21.Text = "/";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 517);
            Controls.Add(button21);
            Controls.Add(button19);
            Controls.Add(label2);
            Controls.Add(button17);
            Controls.Add(button18);
            Controls.Add(button20);
            Controls.Add(button13);
            Controls.Add(button14);
            Controls.Add(button15);
            Controls.Add(button16);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button12);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CalcButton button1;
        private CalcButton button2;
        private CalcButton button3;
        private CalcButton button4;
        private CalcButton button5;
        private CalcButton button6;
        private CalcButton button7;
        private CalcButton button8;
        private CalcButton button9;
        private CalcButton button10;
        private CalcButton button11;
        private CalcButton button12;
        private CalcButton button13;
        private CalcButton button14;
        private CalcButton button15;
        private CalcButton button16;
        private CalcButton button17;
        private CalcButton button18;
        private CalcButton button20;
        private Label label2;
        private Button button19;
        private Button button21;
    }
}
