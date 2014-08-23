using System;
using System.Text.RegularExpressions;

namespace MelliCodeValidator
{
    public static class Validator
    {
        public static bool Validate(string value)
        {
            int n = 0;
            bool isValid = Regex.IsMatch(value, "^\\d{10}$");
            if (isValid)
            {
                char ch;
                for (int index = 2; index < 11; ++index)
                {
                    int num1 = n;
                    ch = value[index - 2];
                    int num2 = int.Parse(ch.ToString()) * (12 - index);
                    n = num1 + num2;
                }
                int result;
                Math.DivRem(n, 11, out result);
                ch = value[9];
                int num = int.Parse(ch.ToString());
                isValid = result == 0 && num == 0 || result == 1 && num == 1 || num == 11 - result;
            }
            return isValid;
        }
    }
}
