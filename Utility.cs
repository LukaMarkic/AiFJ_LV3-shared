using System;
using System.Collections.Generic;

namespace AiFJ_LV3
{
    class Utility
    {

        List<char> separators = new List<char> { ' ', ',', ';', '(', ')', '[', ']', '{', '}'};
        List<char> operators = new List<char> { '+', '-', '*', '/', '=' };
        List<string> validKeywords = new List<string>{ "int", "float", "return", "char", "void"};
        List<char> constants = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char comment = '#';

        bool isValidSeparator(char ch)
        {
            if (separators.Contains(ch))
                return true;
            return false;
        }

        bool isValidOperator(char ch)
        {
            if (operators.Contains(ch))
                return true;
            return false;
        }


        bool isvalidIdentifier(string str)
        {
            if (constants.Contains(str[0]) || isValidSeparator(str[0]) == true || isValidOperator(str[0]) == true)
                return false;
            return true;
        }

        bool isValidComment(string str)
        {
            if (comment != str[0])
                return false;
            return true;
        }

        bool isValidKeyword(string str)
        {
            if (validKeywords.Contains(str))
                return true;
            return false;
        }

        bool isValidConstant(string str)
        {
            int i, len = str.Length;
            if (len == 0)
                return false;
            for (i = 0; i < len; i++)
            {
                if (!constants.Contains(str[i]))
                    return false;
            }
            return true;
        }


        string subString(string str, int left, int right)
        {
            return str.Substring(left, right);
        }

        public Token detectTokens(string str)
        {
            Token token = new Token();
            int left = 0, right = 0;
            int length = str.Length;

            while (right <= length && left <= right)
            {

                if (isValidSeparator(str[right]) == false)
                    right++;
                if (isValidSeparator(str[right]) == true && left == right)
                {
                    Console.WriteLine($"'{str[right]}', separator");
                    token.separatorTokens.Add(str[right].ToString());
                    right++;
                    left = right;
                    if (left == length) return token;
                }
                else if (isValidSeparator(str[right]) == true && left != right || right == length && left != right)
                {
                    string subStr = subString(str, left, right - left);
                    if (isValidKeyword(subStr) == true)
                    {
                        Console.WriteLine($"'{subStr}', ključna riječ");
                        token.keywordTokens.Add(subStr);
                    }
                    else if (isValidConstant(subStr) == true)
                    {
                        Console.WriteLine($"'{subStr}', konstanta");
                        token.constantTokens.Add(subStr);
                    }
                    else if (isValidComment(subStr) == true)
                    {
                        Console.WriteLine($"'{subStr}', komentar");
                        token.commentsTokens.Add(subStr);
                    }
                    else if (isvalidIdentifier(subStr) == true
                       && isValidSeparator(str[right - 1]) == false)
                    {
                        Console.WriteLine($"'{subStr}', identifikator");
                        token.identificatorTokens.Add(subStr);
                    }
                    else if (isvalidIdentifier(subStr) == false
                       && isValidOperator(str[right - 1]) == true)
                    {
                        Console.WriteLine($"'{subStr}', operator");
                        token.operatorTokens.Add(subStr);
                    }
                    left = right;
                }
            }
            return token;
        }
    }
}