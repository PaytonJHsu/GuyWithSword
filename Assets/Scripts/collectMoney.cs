using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectMoney : MonoBehaviour
{
    bool hasPicked;
    // Update is called once per frame
    void Start()
    {
        hasPicked = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if(!hasPicked)
                collision.GetComponent<CharacterMovement>().IncrementMoney();
            hasPicked = true;
        }
        
    }
}
