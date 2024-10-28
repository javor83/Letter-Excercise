using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    public class PCase
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
