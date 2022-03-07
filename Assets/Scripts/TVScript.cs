using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
     public AudioClip tv_sound_1;
     public AudioClip tv_sound_2;   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	void PlaySound()
	{
		GetComponent<AudioSource>().PlayOneShot(tv_sound_1);
		GetComponent<AudioSource>().PlayOneShot(tv_sound_2);
	}
}
