using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PascalCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Stars commands = new Stars();
            string[] list = new string[]
                {
                    "STCDoghudd4=63333$D$0A53333",
                    "EHfsytsnhf?8555&I&2C9555SR"
                };
            foreach (var k in list)
            {
                Console.WriteLine(commands.print(k));
                Console.WriteLine(commands.AttackType(commands.print(k)));
            }
        }
    }

    public class Stars
    {
        public string print(string input)
        {
            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] =

                        m(ascii(input[i]), cprint(input));
                    
            }
            return new string(result);
        }

        public string AttackType(string decr_message)
        {
            string result = "";
            string[] parts = decr_message.Split(new char[] { '!' }, StringSplitOptions.None);
            switch (parts[1])
            {
                case "A":
                    result = string.Format("Attack with {0} soldiers", parts[2].Substring(2));
                    break;
                case "D":
                    result = string.Format("Destroy -> {0}", parts[2].Substring(2));
                    break;
            }

            return result;


            
        }

        private int ascii(char input)
        {
            return (int)input;
           
        }

        private char m(int ascii_code, int star_letter_count)
        {
            char result = Convert.ToChar(ascii_code - star_letter_count);
            return result;
        }

        private int cprint(string key )
        {
            int result = 0;
            char[] allow = new char[] { 's', 't', 'a', 'r' };
            //
            for (int i = 0; i < key.Length; i++)
            {
                if (Array.IndexOf<char>(allow, Char.ToLower(key[i]))>-1)
                {
                    result++;
                }
            }
            return result;

            


        }


    }

    public class PhoneNums
    {

        public bool Print(string input)
        {
            


            Func<bool[] ,char> valid_sep = (bool[] char_sep) =>
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
          

           
            char[] nums = new char[] { '+', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',' '};
            
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

    public  class PCase
    {
        public string print(string input)
        {
            List<int> upcases = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsUpper(input[i]))
                {
                    upcases.Add(i);
                }
            }

            List<string> results = new List<string>();
            for (int i = 0; i < upcases.Count; i++)
            {
                if (i == upcases.Count - 1)
                {
                    results.Add(input.Substring(upcases[i]));
                }
                else
                {
                    results.Add(input.Substring(upcases[i], upcases[i + 1] - upcases[i]));
                }
            }
            foreach (string k in results)
            {
                Console.WriteLine(k);

            }
            return "";
        }

    }
}
