using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleQualitySaver : MonoBehaviour
{
    public TMP_Text[] texts;
    public void SetGI(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: GI") + quality, 0, 8);
        PlayerPrefs.SetInt("Settings: GI", check);
        UpdateSettings();
    }
    public void SetGIBounces(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: GI Bounces") + quality, 0, 10);
        PlayerPrefs.SetInt("Settings: GI Bounces", check);
        UpdateSettings();
    }
    public void SetSSR(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: SSR") + quality, 0, 6);
        PlayerPrefs.SetInt("Settings: SSR", check);
        UpdateSettings();
    }
    public void SetSSRBounces(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: SSR Bounces") + quality, 0, 10);
        PlayerPrefs.SetInt("Settings: SSR Bounces", check);
        UpdateSettings();
    }
    public void SetSSAO(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: SSAO") + quality, 0, 1);
        PlayerPrefs.SetInt("Settings: SSAO", check);
        UpdateSettings();
    }
    public void SetTextureQ(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: Texture") + quality, 0, 1);
        PlayerPrefs.SetInt("Settings: Texture", check);
        UpdateSettings();
    }
    public void SetDLSS(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: DLSS") + quality, 0, 4);
        PlayerPrefs.SetInt("Settings: DLSS", check);
        UpdateSettings();
    }
    public void SetAntiAlias(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: AntiAlias") + quality, 0, 2);
        PlayerPrefs.SetInt("Settings: AntiAlias", check);
        UpdateSettings();
    }
    public void SetResPercent(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: Res Percent") + quality, 0, 18);
        PlayerPrefs.SetInt("Settings: Res Percent", check);
        UpdateSettings();
    }
    public void SetVsync(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: VSync") + quality, 0, 1);
        PlayerPrefs.SetInt("Settings: VSync", check);
        UpdateSettings();
    }
    public void SetMotionBlur(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: Motion Blur") + quality, 0, 1);
        PlayerPrefs.SetInt("Settings: Motion Blur", check);
        UpdateSettings();
    }
    public void SetWindowed(int quality)
    {
        int check = Mathf.Clamp(PlayerPrefs.GetInt("Settings: Windowed") + quality, 0, 1);
        PlayerPrefs.SetInt("Settings: Windowed", check);
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        QualitySave.ApplySavedQualitySettings();
        //0 GI
        switch (PlayerPrefs.GetInt("Settings: GI"))
        {
            case 0:
                texts[0].text = "Off";
                break;
            case 1:
                texts[0].text = "Ray March Low";
                break;
            case 2:
                texts[0].text = "Ray March Med";
                break;
            case 3:
                texts[0].text = "Ray March High";
                break;
            case 4:
                texts[0].text = "Mixed RT Low";
                break;
            case 5:
                texts[0].text = "Mixed RT Med";
                break;
            case 6:
                texts[0].text = "Mixed RT High";
                break;
            case 7:
                texts[0].text = "RT Performance";
                break;
            case 8:
                texts[0].text = "RT Quality";
                break;
            default:
                break;
        }
        //1 GI Bounce
        texts[1].text = (PlayerPrefs.GetInt("Settings: GI Bounces") + 1).ToString();
        if (PlayerPrefs.GetInt("Settings: GI") >= 7)
        {
            texts[1].color = Color.white;
        }
        else
        {
            texts[1].color = Color.grey;
        }
        //2 Reflections
        switch (PlayerPrefs.GetInt("Settings: SSR"))
        {
            case 0:
                texts[2].text = "Off";
                break;
            case 1:
                texts[2].text = "SSR Low";
                break;
            case 2:
                texts[2].text = "SSR Medium";
                break;
            case 3:
                texts[2].text = "SSR High";
                break;
            case 4:
                texts[2].text = "SSR Ultra";
                break;
            case 5:
                texts[2].text = "RT Performance";
                break;
            case 6:
                texts[2].text = "RT Quality";
                break;
            default:
                break;
        }
        //3 Refl Bounce
        texts[3].text = (PlayerPrefs.GetInt("Settings: SSR Bounces") + 1).ToString();
        if (PlayerPrefs.GetInt("Settings: SSR") >= 5)
        {
            texts[3].color = Color.white;
        }
        else
        {
            texts[3].color = Color.grey;
        }
        //4 AO
        switch (PlayerPrefs.GetInt("Settings: SSAO"))
        {
            case 0:
                texts[4].text = "Off";
                break;
            case 1:
                texts[4].text = "SS AO";
                break;
            default:
                break;
        }
        //5 Tex Res
        switch (PlayerPrefs.GetInt("Settings: Texture"))
        {
            case 0:
                texts[5].text = "Half Res";
                break;
            case 1:
                texts[5].text = "Full Res";
                break;
            default:
                break;
        }
        //6 DLSS
        switch (PlayerPrefs.GetInt("Settings: DLSS"))
        {
            case 0:
                texts[6].text = "Off";
                break;
            case 1:
                texts[6].text = "Ultra Perf";
                break;
            case 2:
                texts[6].text = "Max Perf";
                break;
            case 3:
                texts[6].text = "Balanced";
                break;
            case 4:
                texts[6].text = "Quality";
                break;
            default:
                break;
        }
        //7 Anti Aliasing
        switch (PlayerPrefs.GetInt("Settings: AntiAlias"))
        {
            case 0:
                texts[7].text = "Off";
                break;
            case 1:
                texts[7].text = "FXAA";
                break;
            case 2:
                texts[7].text = "SMAA";
                break;
            default:
                break;
        }
        if (PlayerPrefs.GetInt("Settings: DLSS") == 0)
        {
            texts[7].color = Color.white;
        }
        else
        {
            texts[7].color = Color.grey;
        }
        //8 Res %
        texts[8].text = (100 - (PlayerPrefs.GetInt("Settings: Res Percent") * 5)).ToString();
        //9 VSync
        switch (PlayerPrefs.GetInt("Settings: VSync"))
        {
            case 0:
                texts[9].text = "Off";
                break;
            case 1:
                texts[9].text = "On";
                break;
            default:
                break;
        }
        //10 Motion Blur
        switch (PlayerPrefs.GetInt("Settings: Motion Blur"))
        {
            case 0:
                texts[10].text = "Off";
                break;
            case 1:
                texts[10].text = "On";
                break;
            default:
                break;
        }
        //11 Window Mode
        switch (PlayerPrefs.GetInt("Settings: Windowed"))
        {
            case 0:
                texts[11].text = "Fullscreen";
                break;
            case 1:
                texts[11].text = "Windowed";
                break;
            default:
                break;
        }
    }
}
