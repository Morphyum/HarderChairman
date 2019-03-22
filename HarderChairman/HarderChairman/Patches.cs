using Harmony;
using MM2;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HarderChairman {
    class Patches {
        static string version = " +HC-0.1";
        [HarmonyPatch(typeof(SetUITextToVersionNumber), "Awake")]
        public static class SetUITextToVersionNumber_Awake_Patch {
            public static void Postfix(SetUITextToVersionNumber __instance) {
                Text component = __instance.GetComponent<Text>();
                if (component != null) {
                    component.text += version;
                }
                TextMeshProUGUI component2 = __instance.GetComponent<TextMeshProUGUI>();
                if (component2 != null) {
                    component2.text += version;
                }
            }
        }

        [HarmonyPatch(typeof(Chairman), "GetEstimatedPosition")]
        public static class Chairman_GetEstimatedPosition_Patch {
            public static void Postfix(Chairman __instance, ref int __result, Chairman.EstimatedPosition inPosition, Team inTeam) {
                int startOfSeasonExpectedChampionshipResult = inTeam.startOfSeasonExpectedChampionshipResult;
                int teamEntryCount = inTeam.championship.standings.teamEntryCount;
                switch (inPosition) {
                    case Chairman.EstimatedPosition.Low:
                        __result = Mathf.Clamp(startOfSeasonExpectedChampionshipResult, 1, teamEntryCount);
                        break;
                    case Chairman.EstimatedPosition.Medium:
                        __result = Mathf.Clamp(startOfSeasonExpectedChampionshipResult - 1, 1, teamEntryCount);
                        break;
                    case Chairman.EstimatedPosition.High:
                        __result = Mathf.Clamp(startOfSeasonExpectedChampionshipResult - 2, 1, teamEntryCount);
                        break;
                    default:
                        __result = 0;
                        break;
                }
            }  
        }
    }
}
