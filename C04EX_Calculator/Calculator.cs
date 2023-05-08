using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04EX_Calculator
{
    internal class Calculator
    {
        public double? PerformOperation(int a, int b, char symbol)
        {
            string operation = Convert.ToString(symbol);

            double? result = null;
            if (operation == "+")
                result = a + b;
            else if (operation == "-")
                result = a - b;
            else if (operation == "*")
                result = a * b;
            else if (operation == "/")
                result = Convert.ToDouble(a) / b;

            if (result != null)
                return result;
            else
                throw new Exception("cannot calculate the result");
        }

        public double? PerformOperation(string equation)
        {
            string operation = equation.Substring(1, 1);
            int number1 = Convert.ToInt32(equation.Substring(0, 1));
            int number2 = Convert.ToInt32(equation.Substring(2));

            double? result = null;

            if (operation == "+")
                result = number1 + number2;
            else if (operation == "-")
                result = number1 - number2;
            else if (operation == "*")
                result = number1 * number2;
            else if (operation == "/")
                result = Convert.ToDouble(number1) / number2;

            if (result != null)
                return result;
            else
                throw new Exception("cannot calculate the result");
            //return 0;

        }

    }
}