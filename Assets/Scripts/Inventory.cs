using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int charge = 0;
    public AudioClip collectSound;
    public Text textHints;
    bool fireIsLit = false;

    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    // Zapa³ki
    bool haveMatches = false;
    public RawImage matchHudGUI;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CellPickup()
    {
        HUDon();
        //AudioSource.minDistance(12.0f);
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
        charge++;
        chargeHudGUI.texture = hudCharge[charge];
        meter.material.mainTexture = meterCharge[charge];
        //Debug.Break();
    }

    void HUDon()
    {
        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }
    }

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchHudGUI.enabled = true;
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "campfire")
        {
            if (haveMatches)
            {
                LightFire(col.gameObject);
            }
            else if(!fireIsLit)
            {
                textHints.SendMessage("ShowHint", "Móg³bym rozpaliæ ognisko do wezwania pomocy.\nTylko czym...");
          }
        }
    }

    void LightFire(GameObject campfire)
    {
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem emitter in fireEmitters)
        {
            emitter.Play();
        }
        campfire.GetComponent<AudioSource>().Play();
        matchHudGUI.enabled = false;
        haveMatches = false;
        fireIsLit = true;
    }
}
