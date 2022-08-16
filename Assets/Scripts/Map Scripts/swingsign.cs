using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingsign : MonoBehaviour
{
    float speed;
    public float maxMin;
    private void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, Random.Range(0.0f,180.0f), 0);
    }
    void Update()
    {
        speed += Random.Range(-maxMin/5.0f, maxMin/5.0f)*Time.deltaTime;
        speed = Mathf.Clamp(speed, -maxMin, maxMin);
        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + speed, 0);
    }
}
