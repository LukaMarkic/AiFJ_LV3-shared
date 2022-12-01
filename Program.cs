using System;
using System.IO;
using System.Text;

namespace AiFJ_LV3
{
    class Program
    {

        
        static void Main(string[] args)
        {
            string readContents;
            string path = "../../../TempCode.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            if (readContents.Length != 0) { 
                 Token token = new Utility().detectTokens(readContents);
            Console.WriteLine(token.ToString());
            }

           
        }
    }
}

