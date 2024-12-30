using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent(); // Initialize components (UI elements)
        }

        double leftOperand, rightOperand; // Store operands for calculations
        String op; // Store the current operator

        // Event handler for entering numbers
        private void EnterNumber(object sender, EventArgs e)
        {
            Button num = (Button)sender; // Get the number button clicked

            // If the text box is "0" and the user clicks a number (not a decimal), replace the text
            if (textBox.Text == "0" && num.Text != ".")
            {
                textBox.Text = num.Text;
            }
            // If the user clicks a decimal point and there isn't one already, add it
            else if (num.Text == "." && !textBox.Text.Contains("."))
            {
                textBox.Text += ".";
            }
            // If it's a number, append it to the current text
            else if (num.Text != ".")
            {
                textBox.Text += num.Text;
            }
        }

        // Event handler for entering an operator
        private void EnterOperator(object sender, EventArgs e)
        {
            Button oper = (Button)sender; // Get the operator button clicked
            leftOperand = Convert.ToDouble(textBox.Text); // Store the left operand
            op = oper.Text; // Store the current operator
            textBox.Text = "0"; // Clear the display for the next number input
        }

        // Event handler for the equals button to perform the calculation
        private void EqualsTo(object sender, EventArgs e)
        {
            rightOperand = Convert.ToDouble(textBox.Text); // Get the right operand

            // Perform calculation based on the operator
            switch (op)
            {
                case "+":
                    textBox.Text = (leftOperand + rightOperand).ToString("G6"); // Add and display result
                    break;

                case "-":
                    textBox.Text = (leftOperand - rightOperand).ToString("G6"); // Subtract and display result
                    break;

                case "×":
                    textBox.Text = (leftOperand * rightOperand).ToString("G6"); // Multiply and display result
                    break;

                case "÷":
                    textBox.Text = (leftOperand / rightOperand).ToString("G6"); // Divide and display result
                    break;
            }
        }

        // Event handler for the backspace button to remove one character
        private void BackSpace(object sender, EventArgs e)
        {
            if (textBox.TextLength > 0)
            {
                textBox.Text = textBox.Text.Remove(textBox.TextLength - 1, 1); // Remove last character
            }

            // If the text box becomes empty, reset it to "0"
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
        }

        // Event handler for clearing the current entry (resetting the text box to "0")
        private void ClearEntry(object sender, EventArgs e)
        {
            if (textBox.Text != "0")
            {
                textBox.Text = "0"; // Reset text box to "0"
            }
            else if ("+-×÷".Contains(op))
            {
                op = String.Empty; // Clear the operator if one exists
            }
        }

        // Event handler for clearing all values (resetting everything)
        private void AllClear(object sender, EventArgs e)
        {
            textBox.Text = "0"; // Reset text box to "0"
            op = String.Empty; // Clear the operator
            leftOperand = rightOperand = 0; // Reset operands to 0
        }

        // Event handler for changing the sign of the current number (positive to negative or vice versa)
        private void ChangeSign(object sender, EventArgs e)
        {
            textBox.Text = (-1 * Convert.ToDouble(textBox.Text)).ToString("G6"); // Negate the current value
        }
    }
}
