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
    public Button startButton;
    public Color startGreen;
    public Color startGrey;

    public Sprite errorImage;
    public AudioClip uiSoundTabIn;
    public AudioClip uiSoundTabOut;
    public AudioClip uiSoundClick;
    public AudioClip uiSoundFail;
    public AudioSource speaker;
    public Transform[] camPos;
    int currentBotSel;
    int currentStageSel;
    int currentMapSel;
    int currentSpawnSel;
    int currentTimeSel;

    List<int> mapGen;

    void Start()
    {
        int t = Random.Range(0, camPos.Length);
        Camera.main.transform.position = camPos[t].position;
        Camera.main.transform.rotation = camPos[t].rotation;
        QualitySettings.vSyncCount = 1;
    }

    public void GenerateDefault()
    {
        currentBotSel = PlayerPrefs.GetInt("PrevBotSelection"); ;
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
            if (sel != 0)
            {
                speaker.PlayOneShot(uiSoundFail);
            }
        }
        else
        {
            speaker.PlayOneShot(uiSoundClick);
            currentStageSel = 0;
        }
        PlayerPrefs.SetInt("PrevBotSelection", currentBotSel);
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
                if (sel != 0)
                {
                    speaker.PlayOneShot(uiSoundFail);
                }
            }
            else
            {
                speaker.PlayOneShot(uiSoundClick);
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
                if (sel != 0)
                {
                    speaker.PlayOneShot(uiSoundFail);
                }
            }
            else
            {
                speaker.PlayOneShot(uiSoundClick);
            }
            startButton.interactable = true;
            startButton.GetComponent<Image>().color = startGreen;
        }
        else
        {
            mapSelection.text = "[NO MAP]";
            mapPreviewImage.sprite = errorImage;
            startButton.interactable = false;
            startButton.GetComponent<Image>().color = startGrey;
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
                    if (currentStageSel == 0)
                    {
                        mapGen.Add(i);
                    }
                    else
                    {
                        for (int j = 0; j < maps[i].stageType.Length; j++)
                        {
                            if (maps[i].stageType[j] == currentStageSel - 1)
                            {
                                mapGen.Add(i);
                            }
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
            if (sel != 0)
            {
                speaker.PlayOneShot(uiSoundFail);
            }
        }
        else
        {
            speaker.PlayOneShot(uiSoundClick);
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
            if (sel != 0)
            {
                speaker.PlayOneShot(uiSoundFail);
            }
        }
        else
        {
            speaker.PlayOneShot(uiSoundClick);
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
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(maps[mapGen[currentMapSel]].scenePath);
    }
    public void GoToEditor()
    {
        StartCoroutine(GoToMapEditor());
    }
    IEnumerator GoToMapEditor()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Bit Crusher");
    }

    public void AudioTabIn(bool inOut)
    {
        if (inOut)
        {
            speaker.PlayOneShot(uiSoundTabIn);
        }
        else
        {
            speaker.PlayOneShot(uiSoundTabOut);
        }
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
