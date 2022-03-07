using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieGameOver : MonoBehaviour
{ 
    GameObject _player;
	public AudioClip endGame;
	public RawImage YouLost;
	float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (YouLost.enabled) {
			timer += Time.deltaTime;
			if(timer >=2){
				YouLost.enabled = false;
				timer = 0.0f;
				SceneManager.LoadScene("Menu");
			}
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            	GetComponent<AudioSource>().PlayOneShot(endGame);
		YouLost.enabled = true;
        }
    }

    
}
