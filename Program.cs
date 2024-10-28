using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace PascalCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] list = new string[]
               {
                    "STCDoghudd4=63333$D$0A53333",
                    "EHfsytsnhf?8555&I&2C9555SR",
                    @"tt(""DGsvywgerx>5444444444%H%1bB9444",
                    "GQhrr|A977777(HTTT",
                    "EHfsytsnhf?8555&I&2C9555SR"




               };

        

            Stars commands = new Stars(list);

            commands.Index();
        }
    }


    
    public class Stars
    {
        private int attack_counter = 0;
        private int destroy_counter = 0;
        private string[] star_list = null;



        //****************************************************************************************

        public Stars(string[] list)
        {
            this.star_list = list;
            this.CountAttackType(ref this.attack_counter, ref this.destroy_counter);
        }
        //****************************************************************************************

        public void Index()
        {
            this.PrintAttackOnly();
            //this.PrintDestroyOnly();
        }

        //****************************************************************************************
        private void PrintAttackOnly()
        {
            
            Console.WriteLine($"Attacked planets : {this.attack_counter}");
            foreach (string attack in this.star_list)
            {
                string[] parts = this.PartsArmy(this.DecryptMessage(attack));
                //if (this.AttackType(parts) == "A")
                {
                    Console.WriteLine($"-> {PlanetName(parts)}");
                }
            }
        }
        //****************************************************************************************
        private void PrintDestroyOnly()
        {
            Console.WriteLine($"Destroyed planets : {this.destroy_counter}");
            foreach (string attack in this.star_list)
            {
                string[] parts = this.PartsArmy(this.DecryptMessage(attack));
                if (this.AttackType(parts) == "D")
                {
                    Console.WriteLine($"-> {PlanetName(parts)}");
                }
            }
        }





        #region privates
        //****************************************************************************************
        private void CountAttackType(ref int a, ref int d)
        {
            foreach (string attack in this.star_list)
            {
                string[] parts = this.PartsArmy(this.DecryptMessage(attack));
                string attack_type = this.AttackType(parts);
                switch (attack_type)
                {
                    case "A":
                        a++;
                        break;
                    case "D":
                        d++;
                        break;
                }


            }
        }


        //****************************************************************************************
        private string PlanetName(string[] parts)
        {
            int posDveTi = parts[0].IndexOf(':');
            int posAt = parts[0].IndexOf('@')+1;

            string subs = parts[0].Substring(posAt, posDveTi - posAt);

          

            char[] query = subs.ToArray().Where(x => Char.IsLetter(x)).Select(x=>x).ToArray();

            string result = new string(query);
            return result;
        }
        //****************************************************************************************

        private int Population(string[] parts)
        {
            int result = int.Parse(parts[0].Substring(parts[0].IndexOf(':') + 1));
            return result;
        }

        //****************************************************************************************
        private string DecryptMessage(string input)
        {
            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] =

                        ascii_reduce(ascii(input[i]), star_letter_counter(input));

            }
            return new string(result);
        }
        //****************************************************************************************
        private string[] PartsArmy(string input)
        {
            return input.Split(new char[] { '!' }, StringSplitOptions.None);
        }
        //****************************************************************************************
        private string AttackType(string[] parts)
        {
            string result = parts[1];
           
            return result;
        }
        //****************************************************************************************
        private int ArmyCount(string[] parts)
        {


            char[] char_list = parts[2].Substring(parts[2].IndexOf("->") + 1).ToArray();
            var query = (from x in char_list
                         where Char.IsDigit(x)
                         select x).ToArray();
            int result = int.Parse(new string(query));

            return result;
        }
        //****************************************************************************************
        private int ascii(char input)
        {
            return (int)input;

        }
        //****************************************************************************************
        private char ascii_reduce(int ascii_code, int star_letter_count)
        {
            char result = Convert.ToChar(ascii_code - star_letter_count);
            return result;
        }
        //****************************************************************************************
        private int star_letter_counter(string key)
        {
            int result = 0;
            char[] allow = new char[] { 's', 't', 'a', 'r' };
            //
            for (int i = 0; i < key.Length; i++)
            {
                if (Array.IndexOf<char>(allow, Char.ToLower(key[i])) > -1)
                {
                    result++;
                }
            }
            return result;




        }
        //****************************************************************************************
        #endregion




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
