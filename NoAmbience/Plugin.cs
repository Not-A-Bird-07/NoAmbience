using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoAmbience;
[BepInPlugin(Plugin_Info.GUID, Plugin_Info.NAME, Plugin_Info.VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        new Harmony(Plugin_Info.GUID).PatchAll(Assembly.GetExecutingAssembly());
        GorillaTagger.OnPlayerSpawned(Init);

        SceneManager.sceneLoaded += SceneChange;
    }

    private void SceneChange(Scene arg0, LoadSceneMode arg1)
    {
        switch (arg0.name)
        {
            case "Beach":
                GameObject.Find("Beach/Beach_SoundObjects").SetActive(false);
                break;
            
            case "Cave":
                GameObject.Find("Cave_Main_Prefab/NewCave/Cave_Audio_Prefab").SetActive(false);
                break;
        }
    }

    private void Init()
    {
        GameObject.Find("Environment Objects/LocalObjects_Prefab/Vista_Prefab/NewOutside (1)/Audio Source").SetActive(false);
        GameObject.Find("Environment Objects/LocalObjects_Prefab/Vista_Prefab/NewOutside (1)/Audio Source (2)").SetActive(false);
    }
}