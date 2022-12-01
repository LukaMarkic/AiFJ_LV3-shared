using System;

namespace AiFJ_LV3
{
    class Program
    {

        
        static void Main(string[] args)
        {
            String code = "float sumPlusOne (float a, float b)" +
            "{float result = a + b + 1; return result;}";


            Token token = new Utility().detectTokens(code);
            Console.WriteLine(token.ToString());
        }
    }
}

