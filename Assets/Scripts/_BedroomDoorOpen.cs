using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class _BedroomDoorOpen : MonoBehaviour
{
    public AudioClip throwSound;
    public AudioClip lockedDoor;
    private Animator anim;
    public static bool canOpen = true;
    public static bool isNearDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isNearDoor)
        {

            Debug.Log("drzwistrzal");
            if (!canOpen)
            {
                Debug.Log("drzwi nie moga sie otworzyc");
                GetComponent<AudioSource>().PlayOneShot(lockedDoor);
            }
            else
            {
                Debug.Log("drzwi otwarte");
                transform.GetComponent<Animation>().Play("DoorSingle_Open");
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("drzwiopen");
        if (col.gameObject.tag == "Player")
        {
            isNearDoor = true;
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("drzwiclose");
        if (col.gameObject.tag == "Player")
        {
            isNearDoor = false;

        }
    }

}
