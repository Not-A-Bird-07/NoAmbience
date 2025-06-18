using HarmonyLib;

namespace NoAmbience;

[HarmonyPatch(typeof(TimeOfDayDependentAudio))]
public class TimeOfDayDependentAudioPatch
{
    [HarmonyPatch("OnEnable"), HarmonyPrefix]
    public static bool OnEnablePatch(TimeOfDayDependentAudio __instance)
    {
        __instance.gameObject.SetActive(false);
        return false;
    }
}