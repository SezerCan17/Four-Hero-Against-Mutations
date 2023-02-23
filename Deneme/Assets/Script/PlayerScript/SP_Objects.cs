using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Objects : MonoBehaviour
{
    private int counterObjects;
    public Player player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            Debug.Log("girdi1");
            if (counterObjects <= 5)
            {
                Debug.Log("girdi2");
                collision.gameObject.SetActive(false);
                counterObjects++;
            }

        }
    }
}
