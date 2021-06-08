using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GenericDelegatesAssignment
{
    delegate void MathDelegate(int numberA, int numberB);
    class Program
    {
        static void Main(string[] args)
        {
            //This app demonstrates using generic delegates (Action<> and/or Func<>) to do some math based on the values entered by the user in two numbers
            Console.WriteLine("Please enter Number A:");
            int numA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter Number B:");
            int numB = Convert.ToInt32(Console.ReadLine());

            //Decare our action.  It will accepts 2 ints as input <int, int>.
            //Using Action<> because we have no return type from our methods (if our methods returned stuff we'd need to use Func<> instead).
            Action<int, int> mathAction;
                        
            if (numA > numB)
            {
                //Subtract A - B
                //Add the method to our action, just like we did with lambdas
                //Format:  action = (inputs) => { method body / content };
                mathAction = (numberA, numberB) => { Console.WriteLine($"{numberA} - {numberB} = {numberA - numberB}."); };
            }
            else
            {
                //Subtract B - A
                mathAction = (numberA, numberB) => { Console.WriteLine($"{numberB} - {numberA} = {numberB - numberA}."); };
            }

            //Multiply A * B
            mathAction += (numberA, numberB) => { Console.WriteLine($"{numberA} * {numberB} = {numberA * numberB}."); };

            if (numA > 0 && numB > 0)
            {
                //Divide A / B
                mathAction += (numberA, numberB) => { Console.WriteLine($"{numberA} / {numberB} = {numberA / numberB}."); };

                //Divide B / A
                mathAction += (numberA, numberB) => { Console.WriteLine($"{numberB} / {numberA} = {numberB / numberA}."); };
            }

            //Execute all the chained-together delegates
            mathAction(numA, numB);

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
