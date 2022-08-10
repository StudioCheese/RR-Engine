using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customdrop : MonoBehaviour
{
    Dropdown drop;
    // Start is called before the first frame update
    void Start()
    {
        drop = this.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    public void Selected()
    {
        drop.SetValueWithoutNotify(-1);
    }
}
