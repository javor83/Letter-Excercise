using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


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
                    @"tt(''DGsvywgerx>5444444444%H%1B9444",
                    "GQhrr|A977777(H(TTTT",
                    "EHfsytsnhf?8555&I&2C9555SR",
                    "STCDoghudd4=63333$D$0A53333",




               };

            Stars ss = new Stars(list);
            ss.Print();
        }
    }



    
}
