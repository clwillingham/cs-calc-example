using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorExample
{
    public partial class Form1 : Form
    {
        bool didCalc = false;
        bool hasOperator = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void insert(object sender, EventArgs e)
        {
            Button sendBtn = ((Button)sender);
            if (didCalc && !sendBtn.Text.StartsWith(" "))
            {
                calcTxtBx.Text = "";
                hasOperator = false;
            }
            else if (!hasOperator && sendBtn.Text.StartsWith(" "))
            {
                hasOperator = true;
            }else if(hasOperator && sendBtn.Text.StartsWith(" "))
            {
                calculate(null, null);
                hasOperator = true;
            }
            didCalc = false;
            calcTxtBx.Text += ((Button)sender).Text;// + calcTxtBx.Text;
        }

        private void calculate(object sender, EventArgs e)
        {
            string[] text = calcTxtBx.Text.Split(' ');
            double left;
            string op;
            double right;
            double output;
            try
            {
                left = Double.Parse(text[0]);
                op = text[1];
                right = Double.Parse(text[2]);
            }catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            
            switch (op)
            {
                case "+": output = left + right;break;
                case "-": output = left - right; break;
                case "*": output = left * right; break;
                case "/":
                    if(right == 0)
                    {
                        output = Double.PositiveInfinity;
                    }
                    else
                    {
                        output = left / right;
                    }
                    break;
                default: output = Double.NaN;break;
            }
            if(output == Double.PositiveInfinity)
            {
                calcTxtBx.Text = "Infinity and Beyond!";
            }
            else
            {
                calcTxtBx.Text = "" + output;
            }
            didCalc = true;
            hasOperator = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calcTxtBx.Text = "";
            didCalc = false;
            hasOperator = false;
        }
    }
}
