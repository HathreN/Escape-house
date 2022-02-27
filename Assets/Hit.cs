using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    public Text textHints;

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
        if (theObject.gameObject.name == "coconut")
        {
            GetComponent<Animator>().SetTrigger("hit");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            textHints.SendMessage("ShowHint", "Niestety zosta³eœ zagryziony przez wilka!");
            SceneManager.LoadScene("Menu");

        }
    }
}
