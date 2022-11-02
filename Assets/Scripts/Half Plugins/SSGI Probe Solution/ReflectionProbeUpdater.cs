using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
 
[ExecuteAlways]
public class ReflectionProbeUpdater : MonoBehaviour
{
    [Range(0.1f, 60)] public float interval = 2;
     [Range(0.0f, 10)] public float start = 0;
    HDAdditionalReflectionData[] reflectionData = new HDAdditionalReflectionData[2];
    float[] updateTime = new float[2];
    float[] weight = new float[2];
    float intervalTwo;
 
    void OnValidate()
    {
        Setup();
    }
 
    void Start()
    {
        Setup();
    }
 
    void Update()
    {
        weight[1] = Mathf.Abs((updateTime[0] - Time.time) / intervalTwo * 2 - 1);
        weight[0] = 1 - weight[1];
 
        for (int i = 0; i < 2; i++)
        {
            reflectionData[i].weight = weight[i];
            if (Time.time >= updateTime[i])
            {
                updateTime[i] += intervalTwo;
                reflectionData[i].RequestRenderNextUpdate();
            }
        }
    }
 
    void Setup()
    {
        for (int i = 0; i < 2; i++)
        {
            reflectionData[i] = transform.GetChild(i).GetComponent<HDAdditionalReflectionData>();
        }
        updateTime[0] = Time.time + start;
        updateTime[1] = updateTime[0] + interval;
        intervalTwo = interval * 2;
    }
}