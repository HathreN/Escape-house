using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("CellPickup");
            Destroy(gameObject);
            Debug.Log("Hello: ");
        }
    }
}
