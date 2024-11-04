using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Transactions;

class Calculator
{
    List<float> numbers=new List<float>();
    List<string> operators= new List<string>();
    public void WelcomeMessage()
    {
        Console.WriteLine("Welcome to Calculator. Enter a number to start.");
    }
    public void Main()
    {
        Input();
        Console.WriteLine("test");
    }


    public void StoreValues()
    {

    }
    public void Input()
    {
        bool ContinueOP=true;
        while(ContinueOP)
        {
        Console.WriteLine("Number: ");
        int num=Convert.ToInt32(Console.ReadLine());
        numbers.Add(num);

        Console.WriteLine("Enter an operator (+,-) or enter (=) to calculate result: ");
        string? op=Console.ReadLine(); //string? is a nullable string type.
        if(string.IsNullOrWhiteSpace(op))
        {
            Console.WriteLine("operator is blank");
            return;
        }
        operators.Add(op);
        if(op=="=")
        {
            ContinueOP=false;
        }
        }
    }
    public void Calculate()
    {
        float result=numbers[0]; //define the one which is in excess first.
        for(int i=0; i<operators.Count; i++)
        {
            switch(operators[i])
            {
                case "+":
                    result += numbers[i+1];
                    break;
                case "-":
                    result -= numbers[i+1];
                    break;

            }
        }
        Console.WriteLine(result);
    }
}
class Program
{
    static void Main()
    {
        Console.Clear();
        Calculator calculator= new Calculator();
        calculator.WelcomeMessage();
        calculator.Input();
        calculator.Calculate();
        Console.WriteLine("test");
    }
}
