using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMath
{
    internal class Calculator
    {
        List<string> m_numbers;
        List<string> m_operators;

        public string getResult()
        {
            string res = m_numbers[0];
            res = res.Replace(",", ".");
            return res;
        }

        private List<double> parseNumbers2(List<int> indicies, int i)
        {
            double num2 = 0;
            double num1 = 0;

            if (m_numbers[indicies[i]].Length >= 2)
            {
                
                if (m_numbers[indicies[i]][0] == 's' && m_numbers[indicies[i]][1] == 'q')
                {
                    num1 = Math.Sqrt(double.Parse(m_numbers[indicies[i]].Substring(2))) * (-1);
                }
                else if (m_numbers[indicies[i]][0] == 's' && m_numbers[indicies[i]][1] != 'q')
                {
                    num1 = double.Parse(m_numbers[indicies[i]].Substring(1)) * (-1);
                }
                else if(m_numbers[indicies[i]][0] == 'q')
                {
                    num1 = Math.Sqrt(double.Parse(m_numbers[indicies[i]].Substring(1, m_numbers[indicies[i]].Length - 1)));
                }
                else
                {
                    num1 = double.Parse(m_numbers[indicies[i]]);
                }
            }
            if (m_numbers[indicies[i] + 1].Length >= 2)
            {
                if (m_numbers[indicies[i] + 1][0] == 's' && m_numbers[indicies[i] + 1][1] != 'q')
                {
                    num2 = double.Parse(m_numbers[indicies[i] + 1].Substring(1)) * (-1);
                }
                else if (m_numbers[indicies[i] + 1][0] == 's' && m_numbers[indicies[i] + 1][1] == 'q')
                {
                    num2 = Math.Sqrt(double.Parse(m_numbers[indicies[i] + 1].Substring(2))) * (-1);
                }
                else if (m_numbers[indicies[i] + 1][0] == 'q')
                {
                    num2 = Math.Sqrt(double.Parse(m_numbers[indicies[i] + 1].Substring(1, m_numbers[indicies[i] + 1].Length - 1)));
                }
                else
                {
                    num2 = double.Parse(m_numbers[indicies[i]+1]);
                }
            }

            if (m_numbers[indicies[i]].Length == 1)
            {
                num1 = double.Parse(m_numbers[indicies[i]]);
            }
            if (m_numbers[indicies[i] + 1].Length == 1)
            {
                num2 = double.Parse(m_numbers[indicies[i] + 1]);
            }
            
            

            List<double> lst = new List<double> { num1, num2};
            return lst;
        }
        public Calculator(List<string> numbers, List<string> operators) {
            m_numbers = new List<string>(numbers);
            m_operators = new List<string>(operators);
            
            for (int i = 0; i < m_numbers.Count; i++)
            {
                m_numbers[i] = m_numbers[i].Replace(".", ",");
            }

            if (operators.Count > 0)
            {
                doDevisionRemainder();
                doDevision();
                doMultiplication();
                doSubtraction();
                doAddition();
            } 

            else
            {
                if (m_numbers[0][0] == 'q')
                {
                    int remainder = 15 - Math.Round(Math.Sqrt(double.Parse(m_numbers[0].Substring(1, m_numbers[0].Length - 1)))).ToString().Length;
                    double result = Math.Sqrt(double.Parse(m_numbers[0].Substring(1, m_numbers[0].Length - 1)));
                    if (remainder >= 0)
                    {
                        result = Math.Round(result, remainder);
                    }
                    else
                    {
                        result = Math.Round(result);
                    }


                    

                    m_numbers[0] = result.ToString();
                }
                if (m_numbers[0].Length >= 2 && m_numbers[0][0] == 's' && m_numbers[0][1] == 'q')
                {
                    int remainder = 15 - Math.Round(Math.Sqrt(double.Parse(m_numbers[0].Substring(2))) * (-1)).ToString().Length;
                    double result = Math.Sqrt(double.Parse(m_numbers[0].Substring(2))) * (-1);
                    if (remainder >= 0)
                    {

                        result = Math.Round(result, remainder);
                    }
                    else
                    {
                        result = Math.Round(result);
                    }


                    m_numbers[0] = result.ToString();
                }
                else
                {
                    return;
                }
            }
            
            
        }

        private void doDevisionRemainder()
        { 
            if (m_operators[0] == "%")
            {
                double num2 = 0;
                double num1 = 0;
                if (m_numbers[0].Length >= 2)
                {

                    if (m_numbers[0][0] == 's' && m_numbers[0][1] == 'q')
                    {
                        num1 = Math.Sqrt(double.Parse(m_numbers[0].Substring(2))) * (-1);
                    }
                    else if (m_numbers[0][0] == 's' && m_numbers[0][1] != 'q')
                    {
                        num1 = double.Parse(m_numbers[0].Substring(1)) * (-1);
                    }
                    else if (m_numbers[0][0] == 'q')
                    {
                        num1 = Math.Sqrt(double.Parse(m_numbers[0].Substring(1, m_numbers[0].Length - 1)));
                    }
                    else
                    {
                        num1 = double.Parse(m_numbers[0]);
                    }
                }
                if (m_numbers[0 + 1].Length >= 2)
                {
                    if (m_numbers[0 + 1][0] == 's' && m_numbers[0 + 1][1] != 'q')
                    {
                        num2 = double.Parse(m_numbers[0 + 1].Substring(1)) * (-1);
                    }
                    else if (m_numbers[0 + 1][0] == 's' && m_numbers[0 + 1][1] == 'q')
                    {
                        num2 = Math.Sqrt(double.Parse(m_numbers[0 + 1].Substring(2))) * (-1);
                    }
                    else if (m_numbers[0 + 1][0] == 'q')
                    {
                        num2 = Math.Sqrt(double.Parse(m_numbers[0 + 1].Substring(1, m_numbers[0 + 1].Length - 1)));
                    }
                    else
                    {
                        num2 = double.Parse(m_numbers[0 + 1]);
                    }
                }

                if (m_numbers[0].Length == 1)
                {
                    num1 = double.Parse(m_numbers[0]);
                }
                if (m_numbers[0 + 1].Length == 1)
                {
                    num2 = double.Parse(m_numbers[0 + 1]);
                }

                int remainder = 15 - Math.Round(num1 % num2).ToString().Length;
                double result = -1;
                if (remainder >= 0)
                {
                    result = Math.Round(num1 % num2, remainder);
                }
                else
                {
                    result = Math.Round(num1 % num2);
                }

                

                m_numbers[0] = result.ToString();

            }
        }

        private void doDevision()
        {
            List<int> indicies = new List<int>();

            for (int i = 0; i < m_operators.Count; i++)
            {
                if (m_operators[i] == "/")
                {
                    indicies.Add(i);
                }
            }

            for (int i = 0; i < indicies.Count; i++)
            {
                for (int j = 0; j < indicies.Count; j++)
                {
                    
                    
                    indicies[j] -= i >= 1 ? 1 : i;
                    


                }

                List<double> lst = parseNumbers2(indicies,i);
                double num1 = lst[0];
                double num2 = lst[1];

                int remainder = 15 - Math.Round(num1 / num2).ToString().Length;
                double result = -1;
                if (remainder >= 0)
                {
                    result = Math.Round(num1 / num2, remainder);
                }
                else
                {
                    result = Math.Round(num1 / num2);
                }

                

                m_numbers[indicies[i]] = result.ToString();
                m_numbers.RemoveAt(indicies[i] + 1);
                m_operators.RemoveAt(indicies[i]);

            }


        }
        private void doMultiplication()
        {
            List<int> indicies = new List<int>();

            for (int i = 0; i < m_operators.Count; i++)
            {
                if (m_operators[i] == "x")
                {
                    indicies.Add(i);
                }
            }

            for (int i = 0; i < indicies.Count; i++)
            {
                for (int j = 0; j < indicies.Count; j++)
                {
                    
                    indicies[j] -= i >= 1 ? 1 : i;
                    


                }

                List<double> lst = parseNumbers2(indicies, i);
                double num1 = lst[0];
                double num2 = lst[1];

                int remainder = 15 - Math.Round(num1 * num2).ToString().Length;
                double result = -1;
                if (remainder >= 0)
                {
                    result = Math.Round(num1 * num2, remainder);
                }
                else
                {
                    result = Math.Round(num1 * num2);
                }


                m_numbers[indicies[i]] = result.ToString();
                m_numbers.RemoveAt(indicies[i] + 1);
                m_operators.RemoveAt(indicies[i]);

            }
        }
        private void doAddition()
        {
            List<int> indicies = new List<int>();

            for (int i = 0; i < m_operators.Count; i++)
            {
                if (m_operators[i] == "+")
                {
                    indicies.Add(i);
                }   
            }

            for (int i = 0; i < indicies.Count; i++)
            {
                for (int j = 0; j < indicies.Count; j++)
                {
                    
                    indicies[j] -= i >= 1 ? 1 : i;
                    
                    
                    
                }

                List<double> lst = parseNumbers2(indicies, i);
                double num1 = lst[0];
                double num2 = lst[1];

                int remainder = 15 - Math.Round(num1 + num2).ToString().Length;
                double result = -1;
                if (remainder >= 0)
                {
                    result = Math.Round(num1 + num2, remainder);
                }
                else
                {
                    result = Math.Round(num1 + num2);
                }

                

                m_numbers[indicies[i]] = result.ToString();
                m_numbers.RemoveAt(indicies[i] + 1);
                m_operators.RemoveAt(indicies[i]);
            }

            
        }
        private void doSubtraction()
        {
            List<int> indicies = new List<int>();

            for (int i = 0; i < m_operators.Count; i++)
            {
                if (m_operators[i] == "-")
                {
                    indicies.Add(i);
                }
            }

            for (int i = 0; i < indicies.Count; i++)
            {
                for (int j = 0; j < indicies.Count; j++)
                {
                    if (i <= 1)
                    {
                        indicies[j] -= i >= 1 ? 1 : i;
                    }


                }

                List<double> lst = parseNumbers2(indicies, i);
                double num1 = lst[0];
                double num2 = lst[1];

                int remainder = 15 - Math.Round(num1 - num2).ToString().Length;
                double result = -1;
                if (remainder >= 0)
                {
                    result = Math.Round(num1 - num2, remainder);
                }
                else
                {
                    result = Math.Round(num1 - num2);
                }


                m_numbers[indicies[i]] = result.ToString();
                m_numbers.RemoveAt(indicies[i] + 1);
                m_operators.RemoveAt(indicies[i]);

            }
        }
    }

}
