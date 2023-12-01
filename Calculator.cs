using System;
using System.Collections.Generic;

public class Calculator
{
    private List<string> memory;

    public Calculator()
    {
        memory = new List<string>();
    }

    public double Calculate(string operation, double num1, double num2)
    {
        switch (operation)
        {
            case "add":
                return num1 + num2;
            case "subtract":
                return num1 - num2;
            case "multiply":
                return num1 * num2;
            case "divide":
                if (num2 != 0)
                    return num1 / num2;
                else
                    throw new DivideByZeroException("Cannot divide by zero");
            default:
                throw new InvalidOperationException("Invalid operation");
        }
    }

    public void Remember(string message)
    {
        memory.Add(message);
    }

    public void Recall()
    {
        foreach (string message in memory)
        {
            Console.WriteLine(message);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        while (true)
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            if (command == "calculate")
            {
                Console.Write("Enter operation (add, subtract, multiply, divide): ");
                string operation = Console.ReadLine();
                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = calculator.Calculate(operation, num1, num2);
                Console.WriteLine("Result: " + result);
                calculator.Remember($"Calculated {num1} {operation} {num2} = {result}");
            }
            else if (command == "recall")
            {
                calculator.Recall();
            }
            else
            {
                calculator.Remember(command);
            }
        }
    }
}
