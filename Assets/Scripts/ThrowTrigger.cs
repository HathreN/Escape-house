using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour
{
    public RawImage crosshair;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CoconutThrower.canThrow = true;
            crosshair.enabled = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CoconutThrower.canThrow = false;
            crosshair.enabled = false;
        }
    }
}
