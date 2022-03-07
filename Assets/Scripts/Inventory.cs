using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	
    public static int charge = 0;
	public static int kunaiAmount = 0;
//public AudioClip tv_sound_1;
//public AudioClip tv_sound_2;
public AudioClip pickup_sound;
    public AudioClip collectSound;
    bool fireIsLit = false;
    bool TVIsOn = false;
    GameObject TVText;
    float timer = 0.0f;
   

    // HUD
    public Texture2D[] hudCharge;
	public Texture2D[] kunaiCharge;
    public RawImage chargeHudGUI;
	public RawImage kunaiHudGUI;
    public RawImage TVGUI;
    public RawImage TV_Hint_2;
    public RawImage Door1_Hint_1;
    public RawImage Door2_Hint_1;
    public RawImage Door2_Hint_2;
	public RawImage Key_1;
	public RawImage Key_2;
	
    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    // Zapa³ki
    bool haveMatches = false;
    bool haveBatteries = false;
    public Text textHints;
    public RawImage matchHudGUI;
	bool keyFound = false;
	bool secondKeyFound = false;
    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
		kunaiAmount = 0;
		chargeHudGUI.enabled = false;
		kunaiHudGUI.enabled = false;
kunaiHudGUI.texture = kunaiCharge[kunaiAmount];
    }

    // Update is called once per frame
    void Update()
    {
        if (TVGUI.enabled) {
			timer += Time.deltaTime;
			if(timer >=4){
				TVGUI.enabled = false;
				timer = 0.0f;
				haveBatteries = true;
				TVIsOn = false;
			}
		}

	if (TV_Hint_2.enabled) {
			timer += Time.deltaTime;
			if(timer >=4){
				TV_Hint_2.enabled = false;
				timer = 0.0f;
			}
		}

	if (Door1_Hint_1.enabled) {
			timer += Time.deltaTime;
			if(timer >=4){
				Door1_Hint_1.enabled = false;
				timer = 0.0f;
			}
		}

	if (Door2_Hint_1.enabled) {
			timer += Time.deltaTime;
			if(timer >=4){
				Door2_Hint_1.enabled = false;
				timer = 0.0f;
				TVIsOn = false;
			}
		}

	if (Door2_Hint_2.enabled) {
			timer += Time.deltaTime;
			if(timer >=4){
				Door2_Hint_2.enabled = false;
				timer = 0.0f;
				TVIsOn = false;
			}
		}
    }

    void CellPickup()
    {
        HUDon();
        //AudioSource.minDistance(12.0f);
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
        charge++;
	GetComponent<AudioSource>().PlayOneShot(pickup_sound);
        chargeHudGUI.texture = hudCharge[charge];
        if (charge == 4)
        {
            haveBatteries = true;
        }
        //Debug.Break();
    }
	
	void KunaiPickup()
    {
        KunaiHUDon();
        //AudioSource.minDistance(12.0f);
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
        kunaiAmount++;
	GetComponent<AudioSource>().PlayOneShot(pickup_sound);
        kunaiHudGUI.texture = kunaiCharge[kunaiAmount];
        if (kunaiAmount > 0)
        {
			KunaiThrower.canThrow = true;
        }
        //Debug.Break();
    }

	void KunaiThrown()
    {
        KunaiHUDon();
        //AudioSource.minDistance(12.0f);end
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
        kunaiAmount--;
        kunaiHudGUI.texture = kunaiCharge[kunaiAmount];
	Debug.Log("kunai thrown");
        if (kunaiAmount == 0)
        {
            //haveBatteries = true;
			KunaiThrower.canThrow = false;
        }
        //Debug.Break();
    }
	
	void KeyPickup()
    {
	GetComponent<AudioSource>().PlayOneShot(pickup_sound);
        //AudioSource.minDistance(12.0f);
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
		Key_1.enabled = true;
        	keyFound = true;
		GameObject.Find("PFB_DoorSingle_Open").SendMessage("UnlockDoor");
		Debug.Log("ma kluycz");
        //Debug.Break();
    }
	
	
	void KeyUsed()
    {
		Key_1.enabled = false;
    }


	void SecondKeyPickup()
    {
        //AudioSource.minDistance(12.0f);
	GetComponent<AudioSource>().PlayOneShot(pickup_sound);
        AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, -10), 0.02f);
		Key_2.enabled = true;
        	secondKeyFound = true;
		GameObject.Find("PFB_DoorDouble").SendMessage("UnlockDoor");
		Debug.Log("ma kluycz");
        //Debug.Break();
    }
	
	void SecondKeyUsed()
    {
		Key_2.enabled = false;
    }
    void HUDon()
    {
        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }
    }
	
    void KunaiHUDon()
    {
        if (!kunaiHudGUI.enabled)
        {
            kunaiHudGUI.enabled = true;
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
                    TurnTVOn(col.gameObject);
                    Debug.Log("telewizor dzia³a");
			GameObject.Find("PFB_TV").SendMessage("PlaySound");
		    //GetComponent<AudioSource>().PlayOneShot(tv_sound_1);
		    //GetComponent<AudioSource>().PlayOneShot(tv_sound_2);
		    TVGUI.enabled = true;
                }
                else
                {
		    TV_Hint_2.enabled = true;
                    Debug.Log("telewizor nie dziala");
                }
            }
        }

	//else if(col.gameObject.tag == "Door1")
      //  {
      //      if (!keyFound){
		//    Door1_Hint_1.enabled = true;
     // //            }
	//	else{
	//	Debug.Log("else");
	//	}

      //  }

	else if(col.gameObject.tag == "Door2")
        {
            if (!keyFound){
		    Door2_Hint_1.enabled = true;
                  }
		else{
		Debug.Log("else");
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

void Test()
    {
        Debug.Log("Funkcja test");
        
    }
}
