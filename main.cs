using System;
using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Numerics;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.InteropServices;
//using System.Security.Cryptography.X509Certificates;


class Calculator
{
    float num; string? operation="default"; //string? is a nullable string.
    float result;
    public string overallCalculation= "";
    public bool continueOperation=true;
    List<float> numbers = new List<float>();
    List<string> operations = new List<string>();
    List<string> history = new List<string>();

    public void WelcomeMessage()
    {
        Console.WriteLine("welcome to calculator. start typing to start!");
    }

    public void Input()
    {
        bool continueInput=true;
        while(continueInput)
        {
            Console.WriteLine("enter number: ");
            //num=Convert.ToSingle(Console.ReadLine());
            bool validation = float.TryParse((Console.ReadLine()), out float num);
            if(!validation)
            {
                Console.WriteLine("enter valid number.");
                continue; //continues from the while loop
            }
            numbers.Add(num);
            overallCalculation += num;
            
            Console.WriteLine("enter operator: ");
            operation = Console.ReadLine();
            overallCalculation += " "+operation+" ";
            while(string.IsNullOrWhiteSpace(operation) || (operation!="+") && (operation!="-") && (operation!="/") && (operation!="x") && (operation!="/") && (operation!="="))
            {
                Console.WriteLine("invalid operator. please re-enter: ");
                operation=Console.ReadLine();
            }
            if(operation=="=")
            {
                continueInput=false;
            }
            operations.Add(operation);
        }
    }
    public float Calculation()
    {
        result= numbers[0];
        for(int i=0; i<operations.Count; i++)
        {
            switch(operations[i])
            {
                case "+":
                    result+=numbers[i+1];
                    break;
                case "-":
                    result -= numbers[i+1];
                    break;
                case "/":
                    result /= numbers[i+1];
                    break;
                case "*":
                case "x":
                    result *= numbers[i+1];
                    break;
                case "=":
                    break;
                default:
                    Console.WriteLine("invalid operator.");
                    break;
            }
            
        }
        return result;
    }
    public void FinalResult()
    {
        
        Console.WriteLine("the answer is ");
        Console.WriteLine(overallCalculation + Calculation());
        //Console.WriteLine(Calculation());
    }
    public void History()
    {
        history.Add(overallCalculation + Calculation());
    }
    public void PrintHistory()
    {
        
        Console.WriteLine("-----------------------");
        Console.WriteLine("history: ");
        foreach(string i in history)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("-----------------------");
    }
    public void ContinueOperation()
    {
        
        
        Console.WriteLine("enter to continue. type 'exit' to quit. 'h' to view history.");
        string? userInput= Console.ReadLine(); //nullable string.
        if(userInput=="exit")
        {
            continueOperation=false;
        }
        else if(userInput=="h")
        {
            PrintHistory();
            Console.WriteLine("enter to continue. 'exit' to quit.");
            string? validation=Console.ReadLine();
            if(!(validation=="exit"))
            {
                continueOperation=true;
            }
            else continueOperation=false;
            
            
            
        }
        else continueOperation=true;
    }
    public void ResetCalculator()
    {
        result=0;
        overallCalculation="";
        numbers.Clear();
        operations.Clear();
    }

}

class MainProgram
{
    static void Main() //why is static important here? todo.
    {
        
        Console.Clear();
        Calculator calculator = new Calculator();
        calculator.WelcomeMessage();
        
        while(calculator.continueOperation)
        {            
            calculator.ResetCalculator(); //important.
            calculator.Input();
            calculator.Calculation();
            calculator.FinalResult();
            calculator.History();
            //calculator.PrintHistory();
            calculator.ContinueOperation();
        }
    }
}
