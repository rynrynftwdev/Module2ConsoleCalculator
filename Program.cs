// Module 2: Console Calculator
// Demonstrates Variable types, Operators, Conditionals, Loops, and Constants
// Created by: Ryn Wykoff

using System.Globalization;
using System.Runtime.CompilerServices;

class Program

{   //Constant for the tax rate
    private const decimal TaxRate = 0.056m;

    static void Main()
    {
        Console.WriteLine("Module 2: Console Calculator");

        //Loop Control Boolean
        bool continueRunning = true;

        //Last result tracking
        double lastResult = 0;
        bool hasLastResult = false;

        //Operation counter dictionary
        Dictionary<string, int> operationCount = new()
        {
            ["add"] = 0,
            ["sub"] = 0,
            ["mul"] = 0,
            ["div"] = 0,
            ["avg"] = 0,
            ["tax"] = 0
        };


        // Do while loop to handle user input
        do
        {
            Console.WriteLine("Operations: + - * / avg tax exit");
            Console.Write("Enter an operator: ");

            string choice = Console.ReadLine();


            switch (choice)
            {

                case "+":
                    lastResult = Add();
                    operationCount["add"]++;
                    hasLastResult = true;
                    break;

                case "-":
                    lastResult = Subtract();
                    operationCount["sub"]++;
                    hasLastResult = true;
                    break;

                case "*":
                    lastResult = Multiply();
                    operationCount["mul"]++;
                    hasLastResult = true;
                    break;

                case "/":
                    lastResult = Divide();
                    operationCount["div"]++;
                    hasLastResult = true;
                    break;

                case "avg":
                    lastResult = Average();
                    operationCount["avg"]++;
                    hasLastResult = true;
                    break;

                case "tax":
                    CalculateTax();
                    operationCount["tax"]++;
                    hasLastResult = false;
                    break;

                case "exit":
                    Console.WriteLine("Have a nice day!");
                    return;

                default:
                    Console.WriteLine("Unknown Operation. Please try again.");
                    break;

            }

            //Ternary operator example to print the last result
            string lastDisplay = hasLastResult ? lastResult.ToString("G", CultureInfo.InvariantCulture) : "N/A";
            Console.WriteLine($"Last numeric result: {lastDisplay}");

            //Control to break out of the program
            Console.Write("Perform another operation? (y/n):");
            string again = Console.ReadLine().Trim().ToLowerInvariant();
            continueRunning = (again == "y" || again == "yes");

        } while (continueRunning);

        //Display a summary with a for loop
        Console.WriteLine("===== Session Summary =====");
        int totalOps = 0;
        foreach (var kvp in operationCount)
            totalOps += kvp.Value;

        Console.WriteLine($"Total operations: {totalOps}");
        Console.WriteLine("Operations Breakdown: ");

        var keys = new List<string>(operationCount.Keys);
        for (int i = 0; i < keys.Count; i++)
            Console.WriteLine($"{keys[i]}: {operationCount[keys[i]]}");

        Console.WriteLine("Thank you for using the console calculator!");
    }

    //Helper Methods

    //Method to validate user entered doubles
    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                return value;
            Console.WriteLine("Invalid number. Please try again.");

        }
    }

    //Method to validate user entered decimals
    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
                return value;
            Console.WriteLine("Invalid number. Please try again.");
        }
    }

    // Method to add 2 numbers
    private static double Add()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the seond number");
        double result = a + b;
        Console.WriteLine($"Result: {a} + {b} = {result}");
        return result;
    }

    //Method to Subtract 2 numbers
    private static double Subtract()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = a - b;
        Console.WriteLine($"Result: {a} - {b} = {result}");
        return result;
    }

    //Method to Multiply 2 numbers
    private static double Multiply()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = a * b;
        Console.WriteLine($"Result: {a} * {b} = {result}");
        return result;
    }

    //Method to Divide 2 numbers
    private static double Divide()
    {
        double a = ReadDouble("Enter the first number");
        double b; //Variable is created but not assigned
        do
        {

            b = ReadDouble("Enter the second number (non-zero)");
            if (b == 0)
                Console.WriteLine("Cannot divide by zero");
        } while (b == 0);


        double result = a / b;
        Console.WriteLine($"Result: {a} / {b} = {result}");
        return result;
    }

    //Method to get the Average of 2 numbers
    private static double Average()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = (a + b) / 2.0;
        Console.WriteLine($"Average of {a} and {b} is {result}");
        return result;
    }

    //Method to calculate Sales Tax
    private static void CalculateTax()
    {
        decimal amount = ReadDecimal("Enter item cost");
        decimal tax = amount * TaxRate;
        decimal total = amount + tax;
        Console.WriteLine($"Tax ({TaxRate}): {tax:C}");
        Console.WriteLine($"Total with tax: {total:C}");
    }
}