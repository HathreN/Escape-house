using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
	public AudioClip endGame;
	public RawImage YouWon;
	float timer = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (YouWon.enabled) {
			timer += Time.deltaTime;
			if(timer >=5.5){
				YouWon.enabled = false;
				timer = 0.0f;
				SceneManager.LoadScene("Menu");
			}
		}
    }

void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
		
            GetComponent<AudioSource>().PlayOneShot(endGame);
		YouWon.enabled = true;
		
            
        }
    }

void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("spaceship exit");

        }
    }
}
