using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOff : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Light>().enabled = false;
    }
}
