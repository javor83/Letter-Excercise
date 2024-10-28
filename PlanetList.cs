using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    public class PlanetList
    {
        public string PlanetName { get; set; }
        public int Population { get; set; }

        public enum_AttackType PlanetAction { get; set; }

        public int? ArmyCount { get; set; }

        public override string ToString()
        {
            string pl_army = "[?]";
            if (this.ArmyCount.HasValue)
            {
                pl_army = this.ArmyCount.Value.ToString();
            }
            string[] result = new string[]
                {
                    $"Name : {this.PlanetName}",
                    $"Population : {this.Population}",
                    $"Attack : {this.PlanetAction}",
                    $"Army : {pl_army}"
                };
            return string.Join("\n", result);
        }


    }
}
