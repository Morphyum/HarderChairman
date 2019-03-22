using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HarderChairman
{
    public class HarderChairman
    {
        public static void Init() {
            var harmony = HarmonyInstance.Create("de.morphyum.HarderChairman");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
