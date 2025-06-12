using System;
using System.Collections.Generic;


namespace Hesap.Makinesi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter an expression like: 2 + 5 * 3");
                string input = Console.ReadLine();

                try
                {
                    int result = Calculator.Calculate(input);
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }

    public static class Calculator
    {
        public static int Calculate(string expression)
        {
            string[] parts = expression.Split(' ');

            if (parts.Length < 3 || parts.Length % 2 == 0)
                throw new ArgumentException("Invalid expression");

            List<int> numbers = new List<int>();
            List<string> operators = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 == 0)
                    numbers.Add(Convert.ToInt32(parts[i]));
                else
                    operators.Add(parts[i]);
            }

            while (operators.Contains("*") || operators.Contains("/"))
            {
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == "*" || operators[i] == "/")
                    {
                        int result = (operators[i] == "*")
                            ? Multiply(numbers[i], numbers[i + 1])
                            : Divide(numbers[i], numbers[i + 1]);

                        numbers[i] = result;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        break;
                    }
                }
            }

            while (operators.Count > 0)
            {
                int result = (operators[0] == "+")
                    ? Add(numbers[0], numbers[1])
                    : Subtract(numbers[0], numbers[1]);

                numbers[0] = result;
                numbers.RemoveAt(1);
                operators.RemoveAt(0);
            }

            return numbers[0];
        }

        public static int Add(int a, int b) => a + b;

        public static int Subtract(int a, int b) => a - b;

        public static int Multiply(int a, int b) => a * b;

        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero");
                return 0;
            }
            return a / b;
        }
    }
}
