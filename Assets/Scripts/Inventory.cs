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
    bool TVIsOn = false;
    GameObject TVText;

    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    // Zapa³ki
    bool haveMatches = false;
    bool haveBatteries = false;
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
        if (charge == 4)
        {
            haveBatteries = true;
        }
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
        else if(col.gameObject.tag == "TV")
        {
            if (!TVIsOn)
            {
                Debug.Log("strefa telewizorni");
                if (haveBatteries)
                {
                    GameObject text = new GameObject();
                    TextMesh t = text.AddComponent<TextMesh>();
                    t.text = "new text set";
                    t.fontSize = 30;
                    t.transform.localPosition += new Vector3(548f, 0.8f, 632f);
                    t.transform.localEulerAngles += new Vector3(0, 90, 0);
                    TurnTVOn(col.gameObject);
                    Debug.Log("telewizor dzia³a");
                }
                else
                {
                    Debug.Log("telewizor nie dziala");
                }
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
    void TurnTVOn(GameObject TV)
    {
        Debug.Log("Funkcja telewizora");
        //TV.GetComponent<AudioSource>().Play();
        chargeHudGUI.enabled = false;
        haveBatteries = false;
        TVIsOn = true;
    }
}
