using System;
using System.Runtime.InteropServices;

class Calculator
{
    float num; string? operation="default"; //string? is a nullable string.
    float result;
    string overallCalculation= "default";
    List<float> numbers = new List<float>();
    List<string> operations = new List<string>();

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
            num=Convert.ToInt32(Console.ReadLine());
            numbers.Add(num);
            
            Console.WriteLine("enter operator: ");
            operation = Console.ReadLine();
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
                
            }
            
        }
        return result;
    }
    public void FinalResult()
    {
        Console.WriteLine("the answer is ");
        Console.WriteLine(Calculation());
    }
    public void Expression()
    {
        Console.WriteLine(numbers[0]);
        for(int i=0; i<operations.Count; i++)
        {
            Console.WriteLine(operations[i]+numbers[i+1]);
        }
    }
}

class MainProgram
{
    static void Main() //why is static important here? todo.
    {
        Console.Clear();
        Calculator calculator = new Calculator();
        calculator.WelcomeMessage();
        calculator.Input();
        calculator.Calculation();
        //calculator.Expression(); needs work
        calculator.FinalResult();

    }
}
