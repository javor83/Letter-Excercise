using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    public class PhoneNums
    {

        public bool Print(string input)
        {



            Func<bool[], char> valid_sep = (bool[] char_sep) =>
            {
                char result_sep = '?';

                int i = 0;
                while (i <= char_sep.Length - 1 && result_sep == '?')
                {
                    if (char_sep[i])
                    {
                        if (i == 0)
                        {

                            result_sep = '-';

                        }
                        else
                        if (i == 1)
                        {
                            result_sep = ' ';

                        }
                    }
                    i++;
                }

                return result_sep;
            };



            char[] nums = new char[] { '+', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };

            bool result = false;
            bool all_in = input.All(x => Array.IndexOf<char>(nums, x) > -1);
            if (all_in)
            {
                if (input.StartsWith("+359"))
                {


                    bool[] char_sep = new bool[] { input.Contains('-'), input.Contains(' ') };
                    if (char_sep.Where(x => x == true).Count() == 1)
                    {


                        char local_separator = valid_sep(char_sep);


                        string[] parts = input.Split(new char[] { local_separator }, StringSplitOptions.None);
                        if (parts.Last().Length == 4 && parts[parts.Count() - 1 - 1].Length == 3 && parts[parts.Count() - 3].Length == 1)
                        {
                            result = true;
                            Console.WriteLine(input);

                        }
                    }

                }
            }

            return result;
        }

    }
}
