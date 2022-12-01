using System;
using System.Collections.Generic;

namespace AiFJ_LV3
{
    public class Token
    {
        public List<string> separatorTokens;
        public List<string> operatorTokens;
        public List<string> keywordTokens;
        public List<string> identificatorTokens;
        public List<string> constantTokens;
        public List<string> commentsTokens;

        public Token()
        {
            separatorTokens = new List<string>() { };
            operatorTokens = new List<string>() { };
            keywordTokens = new List<string>() { };
            identificatorTokens = new List<string>() { };
            constantTokens = new List<string>() { };
            commentsTokens = new List<string>() { };
        }
        public override string ToString()
        {
            return $"Separatori[{separatorTokens.Count}]: {getStringOfTokens(separatorTokens)}\n"
            + $"Operatori[{operatorTokens.Count}]: {getStringOfTokens(operatorTokens)} " +
            $"\nKljučne riječi[{keywordTokens.Count}]: {getStringOfTokens(keywordTokens)} "
            + $"\nIdentifikatori[{identificatorTokens.Count}]: {getStringOfTokens(identificatorTokens)}" +
             $"\nKonstante[{constantTokens.Count}]: {getStringOfTokens(constantTokens)}" +
            $"\nKomentari[{commentsTokens.Count}]: {getStringOfTokens(commentsTokens)}";
        }
        string getStringOfTokens(List<string> tokens)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>() { };
            string result = "";
            foreach (var token in tokens)
            {
                if (!elements.ContainsKey(token))
                {
                    elements.Add(token, 1);
                }
                else
                {
                    int num = elements[token];
                    elements[token] = num + 1;
                }
            }
            foreach (var element in elements)
            {
                result += $" '{element.Key}'[{element.Value}],";
            }
            return result;
        }

    }
}