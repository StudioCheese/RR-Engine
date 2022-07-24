using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public int lightBit;
    public char topOrBottom;
    [Range(0.01f, .3f)]
    public float fadeSpeed;
    public float intensity;
    public float intensityMultiplier = 1.0f;
    Mack_Valves bitChart;
    HDAdditionalLightData currentLight;
    public bool strobe;
    public bool flash;

    public bool materialLight = false;
    public GameObject emissiveObject;
    public string emmissiveMatName;
    Material emissiveTexture;
    public float emissiveMultiplier = 1;
    public Color emissiveMatColor = Color.white;
    public bool invertBit;
    public bool materialStars;
    public bool helicopter;
    public bool chuckStar;
    public Texture2D[] starCookies;
    //Values
    bool flashCheck;
    float nextTime = 0;
    float acceleration = 0;
    float speed = 0;
    bool textureSet;
    int currentTextureSet;

    private void Start()
    {
        bitChart = this.transform.root.Find("Mack Valves").GetComponent<Mack_Valves>();
        if (!materialLight)
        {
            currentLight = this.GetComponent<HDAdditionalLightData>();
        }
        else
        {
            foreach (Material matt in emissiveObject.GetComponent<MeshRenderer>().materials)
            {
                if (matt.name == emmissiveMatName)
                {
                    emissiveTexture = matt;
                    emissiveTexture.EnableKeyword("_EMISSIVE_COLOR_MAP");
                }
            }
        }
        if (materialStars)
        {
            emissiveObject.SetActive(false);
        }
    }

    public void CreateMovements(float num3)
    {
        bool onOff = false;
        if (topOrBottom == 'T' && bitChart.topDrawer[lightBit - 1])
        {
            onOff = true;
        }
        else if (topOrBottom == 'B' && bitChart.bottomDrawer[lightBit - 1])
        {
            onOff = true;
        }
        if (invertBit)
        {
            onOff = !onOff;
        }
        if (flash)
        {
            if (onOff)
            {
                if (!flashCheck)
                {
                    flashCheck = true;
                    nextTime = 1;
                }
                else
                {
                    nextTime -= fadeSpeed * num3;
                }
            }
            else
            {
                if (flashCheck)
                {
                    flashCheck = false;
                }
                nextTime -= fadeSpeed * num3;
            }
        }
        else if (strobe)
        {
            if (onOff)
            {
                if (nextTime != 0)
                {
                    nextTime -= fadeSpeed * 2 * num3;
                }
                else
                {
                    nextTime = 1;
                }
            }
            else
            {
                nextTime -= fadeSpeed * 2 * num3;
            }
        }
        else
        {
            if (onOff)
            {
                nextTime += fadeSpeed * num3;
            }
            else
            {
                nextTime -= fadeSpeed * num3;
            }
        }
        nextTime = Mathf.Min(Mathf.Max(nextTime, 0), 1);
        if (!materialLight)
        {
            currentLight.intensity = intensity * nextTime * intensityMultiplier;
        }
        else if (!materialStars)
        {
            emissiveTexture.SetColor("_EmissiveColor", emissiveMatColor * nextTime * emissiveMultiplier * intensityMultiplier);
        }
        else
        {
            if (onOff && !emissiveObject.activeSelf)
            {
                emissiveObject.SetActive(true);
            }
            if (!onOff && emissiveObject.activeSelf)
            {
                emissiveObject.SetActive(false);
            }
        }
        if (helicopter)
        {
            if (onOff)
            {
                acceleration = Mathf.Max(50, acceleration + Time.deltaTime);
            }
            else
            {
                if (speed > 0)
                {
                    acceleration = Mathf.Min(-50, acceleration + (Time.deltaTime / 8.0f));
                }
                else
                {
                    acceleration = 0;
                }
            }
            speed = Mathf.Clamp((acceleration * Time.deltaTime) + speed, 0, 40);
            this.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * 8.0f));
        }
        if (chuckStar)
        {
            //Acceleration = time between patterns
            //Flashcheck = pattern swap
            //speed = cookie check
            if(onOff)
            {
                acceleration += Time.deltaTime;
            }

            
            if (acceleration > 10.0f)
            {
                acceleration = 0;
                flashCheck = !flashCheck;
                textureSet = false;
            }
            //Flash or Burst pattern?
            if (!flashCheck)
            {
                //(int)Speed = Texture Frame
                if (speed > 4)
                {
                    speed = 0;
                }
                //Move to next texture frame when speed > current image
                if (currentTextureSet != Mathf.FloorToInt(speed) + 1)
                {
                    currentLight.SetCookie(starCookies[Mathf.FloorToInt(speed) + 1]);
                    currentTextureSet = Mathf.FloorToInt(speed) + 1;
                }

                //Modulate light intensity by sine wave
                currentLight.intensity = Mathf.Clamp((Mathf.Sin((speed * Mathf.PI*2) - (Mathf.PI / 2.0f)) + 1),0.5f,1) * intensity * intensityMultiplier * nextTime;

                //Advance Speed
                speed += Time.deltaTime*15;
            } 
            else
            {
                //Advance Speed
                speed += Time.deltaTime;
                //Change to flash frame if not
                if (!textureSet)
                {
                    currentLight.SetCookie(starCookies[0]);
                }
                textureSet = true;
                //Modulate light intensity by sine wave
                currentLight.intensity = (Mathf.Sin((speed * 40) - 0.5f) + 1) * intensity * intensityMultiplier * nextTime;
            }
        }
    }
}
