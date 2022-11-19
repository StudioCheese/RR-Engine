using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QualitySave
{
    public static void ApplySavedQualitySettings()
    {
        switch (PlayerPrefs.GetInt("Settings: Windowed"))
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            default:
                break;
        }
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Settings: Texture"), true);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("Settings: VSync");
    }

    public static void FirstTimeSave()
    {
        if (PlayerPrefs.GetInt("First Time Starting 1.63 2") != 1)
        {
            PlayerPrefs.SetInt("First Time Starting 1.63 2", 1);
            PlayerPrefs.SetInt("Settings: GI", 1);
            PlayerPrefs.SetInt("Settings: GI Bounces", 0);
            PlayerPrefs.SetInt("Settings: SSR", 2);
            PlayerPrefs.SetInt("Settings: SSR Bounces", 0);
            PlayerPrefs.SetInt("Settings: SSAO", 1);
            PlayerPrefs.SetInt("Settings: Texture", 1);
            PlayerPrefs.SetInt("Settings: DLSS", 3);
            PlayerPrefs.SetInt("Settings: AntiAlias", 2);
            PlayerPrefs.SetInt("Settings: Res Percent", 6);
            PlayerPrefs.SetInt("Settings: VSync", 1);
            PlayerPrefs.SetInt("Settings: Motion Blur", 1);
            PlayerPrefs.SetInt("Settings: Windowed", 0);
        }
    }
}