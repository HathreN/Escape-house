using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class ClosetOpen : MonoBehaviour
{
    public AudioClip throwSound;
    public AudioClip lockedDoor;
    private Animator anim;
    public static bool isOpened = false;
    public static bool isNearDrawer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isNearDrawer)
        {

            Debug.Log("drawer strzal");
            if (isOpened)
            {
                transform.GetComponent<Animation>().Play("Closet_Close");
                isOpened = false;
            }
            else
            {
                Debug.Log("szafka otwarta");
                transform.GetComponent<Animation>().Play("Closet_Open");
                isOpened = true;
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("drawer trigger enter");
        if (col.gameObject.tag == "Player")
        {
            isNearDrawer = true;

        }
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("drawer trigger leave");
        if (col.gameObject.tag == "Player")
        {
            isNearDrawer = false;

        }
    }

}
