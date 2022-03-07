using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class HitPlayer : MonoBehaviour
{
	public AudioClip zombieHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision theObject)
    {
	Debug.Log("hit player1");
        if (theObject.gameObject.name == "kunai")
        {
		GetComponent<AudioSource>().PlayOneShot(zombieHit);
			Debug.Log("hit player2");
            //GetComponent<Animator>().SetTrigger("hitPlayer");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			 Debug.Log("triger enter hit player");
            //SceneManager.LoadScene("Menu");

        }
    }
}

