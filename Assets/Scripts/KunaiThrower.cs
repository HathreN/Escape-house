using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KunaiThrower : MonoBehaviour
{
    public AudioClip throwSound;
    public Rigidbody kunaiPrefab;
    public float throwSpeed = 30.0f;
    public static bool canThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") && canThrow)
        {
            {
                GetComponent<AudioSource>().PlayOneShot(throwSound);
                Rigidbody newKunai = Instantiate(kunaiPrefab, transform.position, transform.rotation) as Rigidbody;
                newKunai.velocity = transform.forward * throwSpeed;
                newKunai.name = "kunai";
		GameObject.Find("FPSController").SendMessage("KunaiThrown");
            }
        }
    }
}
