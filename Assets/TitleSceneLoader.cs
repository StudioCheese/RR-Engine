using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : MonoBehaviour
{
    public RRMapSetup[] mapTypes;
    public RRMap[] maps;
    public string[] spawnLocations;
    public string[] times;
    public TMP_Text botSelection;
    public TMP_Text stageSelection;
    public TMP_Text mapSelection;
    public TMP_Text spawnSelection;
    public TMP_Text timeSelection;
    public Image mapPreviewImage;

    public Sprite errorImage;

    int currentBotSel;
    int currentStageSel;
    int currentMapSel;
    int currentSpawnSel;
    int currentTimeSel;

    List<int> mapGen;

    public void GenerateDefault()
    {
        currentBotSel = 0;
        currentStageSel = 0;
        currentMapSel = 0;
        currentSpawnSel = PlayerPrefs.GetInt("PrevSpawnSelection");
        currentTimeSel = PlayerPrefs.GetInt("PrevTimeSelection");
        spawnSelection.text = spawnLocations[currentSpawnSel];
        timeSelection.text = times[currentTimeSel];
        ChangeBotSelection(0);
    }

    public void ChangeBotSelection(int sel)
    {
        int old = currentBotSel;
        currentBotSel = (int)Mathf.Clamp(currentBotSel + sel, 0, mapTypes.Length - 1);
        botSelection.text = mapTypes[currentBotSel].bottype;
        if (old == currentBotSel)
        {

        }
        else
        {
            currentStageSel = 0;
        }

        ChangeStageSelection(0);
    }
    public void ChangeStageSelection(int sel)
    {
        if (mapTypes[currentBotSel].stagetypes != null)
        {
            int old = currentStageSel;
            currentStageSel = (int)Mathf.Clamp(currentStageSel + sel, 0, mapTypes[currentBotSel].stagetypes.Length);
            if (currentStageSel > 0)
            {
                stageSelection.text = "Filter: " + mapTypes[currentBotSel].stagetypes[currentStageSel - 1];
            }
            else
            {
                stageSelection.text = "Filter: All";
            }
            if (old == currentStageSel)
            {

            }
            else
            {
                currentMapSel = 0;
            }
        }
        else
        {
            stageSelection.text = "Filter: All";
            currentStageSel = 0;
        }
        GenerateMaps();
        ChangeMapSelection(0);
    }
    public void ChangeMapSelection(int sel)
    {
        if (mapGen.Count > 0)
        {
            int old = currentMapSel;
            currentMapSel = (int)Mathf.Clamp(currentMapSel + sel, 0, mapGen.Count - 1);
            mapSelection.text = maps[mapGen[currentMapSel]].sceneName;
            switch (currentTimeSel)
            {
                case 0:
                    mapPreviewImage.sprite = maps[mapGen[currentMapSel]].thumbnailDay;
                    break;
                case 1:
                    mapPreviewImage.sprite = maps[mapGen[currentMapSel]].thumbnailNight;
                    break;
                case 2:
                    mapPreviewImage.sprite = maps[mapGen[currentMapSel]].thumbnailMorning;
                    break;
                case 3:
                    mapPreviewImage.sprite = maps[mapGen[currentMapSel]].thumbnailSunset;
                    break;
                case 4:
                    mapPreviewImage.sprite = maps[mapGen[currentMapSel]].thumbnailRain;
                    break;
                default:
                    break;
            }
            if (old == currentMapSel)
            {

            }
            else
            {

            }
        }
        else
        {
            mapSelection.text = "[NO MAP]";
            mapPreviewImage.sprite = errorImage;
        }
    }

    void GenerateMaps()
    {
        mapGen = new List<int>();
        for (int i = 0; i < maps.Length; i++)
        {
            for (int e = 0; e < maps[i].botType.Length; e++)
            {
                if (maps[i].botType[e] == currentBotSel)
                {
                    for (int j = 0; j < maps[i].stageType.Length; j++)
                    {
                        if (maps[i].stageType[j] == currentStageSel)
                        {
                            mapGen.Add(i);
                        }
                    }
                }
            }
        }
        currentMapSel = 0;
    }

    public void ChangeSpawnSelection(int sel)
    {
        int old = currentSpawnSel;
        currentSpawnSel = (int)Mathf.Clamp(currentSpawnSel + sel, 0, spawnLocations.Length - 1);
        if (old == currentSpawnSel)
        {

        }
        else
        {
            PlayerPrefs.SetInt("PrevSpawnSelection", currentSpawnSel);
            spawnSelection.text = spawnLocations[currentSpawnSel];
        }

    }
    public void ChangeTimeSelection(int sel)
    {
        int old = currentTimeSel;
        currentTimeSel = (int)Mathf.Clamp(currentTimeSel + sel, 0, times.Length - 1);
        if (old == currentTimeSel)
        {

        }
        else
        {
            PlayerPrefs.SetInt("PrevTimeSelection", currentTimeSel);
            timeSelection.text = times[currentTimeSel];
        }
        ChangeMapSelection(0);
    }

    public void GoToMap()
    {
        StartCoroutine(GoToMapCRT());
    }

    IEnumerator GoToMapCRT()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(maps[mapGen[currentMapSel]].scenePath);
    }
}

[System.Serializable]
public class RRMap
{
    public string sceneName;
    public string scenePath;
    public Sprite thumbnailDay;
    public Sprite thumbnailNight;
    public Sprite thumbnailMorning;
    public Sprite thumbnailSunset;
    public Sprite thumbnailRain;
    public int[] botType;
    public int[] stageType;
}
[System.Serializable]
public class RRMapSetup
{
    public string bottype;
    public string[] stagetypes;
}
