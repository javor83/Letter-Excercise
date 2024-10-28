using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    public class Stars
    {



        private List<PlanetList> data = null;

        //****************************************************************************************

        public Stars(string[] star_list)
        {

            this.data = new List<PlanetList>();
            foreach (string k in star_list)
            {
                var element = this.FromText(k);
                this.data.Add(element);

            }

        }
        //****************************************************************************************
        public void Print()
        {
            PrintActions(enum_AttackType.Attack,this.data);
            PrintActions(enum_AttackType.Destroy,this.data);
        
        }
        //****************************************************************************************
        private void PrintActions(enum_AttackType key,List<PlanetList> list_finds)
        {
            var query = from x in list_finds
                        where x.PlanetAction == key
                        select x;
            switch (key)
            {
                case enum_AttackType.Destroy:
                    Console.WriteLine($"Destroyed planets : {query.Count()}");
                    break;
                case enum_AttackType.Attack:
                    Console.WriteLine($"Attacked planets : {query.Count()}");
                    break;
            }
            foreach (var k in query)
            {
                Console.WriteLine($"-> {k.PlanetName}");
            }
        }


        //****************************************************************************************
        private PlanetList FromText(string attack)
        {
            //Console.WriteLine(">> : "+this.DecryptMessage(attack));
            string[] parts = this.PartsArmy(this.DecryptMessage(attack));
            string attack_type = this.AttackType(parts);
            string planet_name = this.PlanetName(parts);
            int population = this.Population(parts);
            var army_count = this.ArmyCount(parts);

            PlanetList result = new PlanetList()
            {
                PlanetName = planet_name,
                Population = population,
                PlanetAction = this.TypeFromString(attack_type),
                ArmyCount = army_count

            };
            if (result.ArmyCount.HasValue == false)
            {
                result.PlanetAction = enum_AttackType.None;
            }
            return result;
        }


        //****************************************************************************************
        private string PlanetName(string[] parts)
        {
            int posDveTi = parts[0].IndexOf(':');
            int posAt = parts[0].IndexOf('@') + 1;

            string subs = parts[0].Substring(posAt, posDveTi - posAt);



            char[] query = subs.ToArray().Where(x => Char.IsLetter(x)).Select(x => x).ToArray();

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
        private enum_AttackType TypeFromString(string key)
        {
            enum_AttackType result = enum_AttackType.None;
            switch (key.ToUpper())
            {
                case "A":
                    result = enum_AttackType.Attack;
                    break;
                case "D":
                    result = enum_AttackType.Destroy;
                    break;
            }
            return result;
        }
        //****************************************************************************************
        private string AttackType(string[] parts)
        {
            string result = parts[1];

            return result;
        }
        //****************************************************************************************
        private int? ArmyCount(string[] parts)
        {
            int? result = null;
            if (parts[2].IndexOf("->") > -1)
            {
                char[] char_list = parts[2].Substring(parts[2].IndexOf("->") + 1).ToArray();
                var query = (from x in char_list
                             where Char.IsDigit(x)
                             select x).ToArray();
                result = int.Parse(new string(query));
            }
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

    }
}
