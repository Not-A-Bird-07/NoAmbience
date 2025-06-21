using HarmonyLib;

namespace NoAmbience;

[HarmonyPatch(typeof(TimeOfDayDependentAudio))]
public class TimeOfDayDependentAudioPatch
{
    [HarmonyPatch("OnEnable"), HarmonyPrefix]
    public static bool OnEnablePatch(TimeOfDayDependentAudio __instance)
    {
        if (__instance.gameObject.name is "SoundPostForest" or "SoundPost (1)")
            return true;
        __instance.gameObject.SetActive(false);
        return false;
    }
}