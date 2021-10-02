using System;

namespace Compiladores
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parserobj = new Parser();

            Console.Write("Escriba la operacion: ");
            string expression = Console.ReadLine();
            if (expression != null)
            {
                Console.WriteLine(parserobj.InitializeExpression(expression));
                Console.ReadLine();
            }
        }
    }
}
