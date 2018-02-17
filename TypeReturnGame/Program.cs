using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReturnGame
{
    class Program
    {

        const int MAX_FAILS = 8;

        static void Main(string[] args)
        {

            Console.WriteLine("TYPE RETURN, a game by Studiosi");
            Console.WriteLine("You are a desperate programmer, trying to exit a function desperately... TYPE RETURN!");
            Console.WriteLine("(Note: Your keyboard might be broken)");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

            // Changing the mapping of the characters
            ReturnChecker rc = new ReturnChecker();
            rc.generateEncoding();

            int fails = MAX_FAILS;
            while(fails > 0)
            {
                Console.WriteLine(String.Format("Iterations left: {0}", fails));
                Console.Write("> ");
                string inStr = Console.ReadLine();
                inStr = inStr.ToUpper();
                string translatedStr = rc.translateString(inStr);
                RETURN_TYPE ret = rc.checkString(translatedStr);
                if(ret == RETURN_TYPE.SUCCESS)
                {
                    Console.WriteLine("Exiting! Success!");                    
                    break;
                }                  
                else if(ret == RETURN_TYPE.ERROR_LENGTH)
                {
                    Console.WriteLine("SYNTAX ERROR: Command exceeded maximum length");
                    fails--;
                }
                else if(ret == RETURN_TYPE.ERROR)
                {
                    Console.WriteLine("Executing command... " + translatedStr);
                    Console.WriteLine("SYNTAX ERROR");
                    fails--;
                }
            }
            if(fails == 0)
            {
                Console.WriteLine("You did not succeed... now the whole world is destroyed.");
            }
            Console.ReadLine();
        }
    }
}
