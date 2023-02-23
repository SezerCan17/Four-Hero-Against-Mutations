using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Obje : MonoBehaviour
{

    Player Player;
    public Animator myanims;
    public int maxObjects = 5;
    public int objects=0;

    public HealthBar GreenBar2;
    void Start()
    {
        Player = GetComponent<Player>();
        GreenBar2.SetMaxHealth(maxObjects);
        //healthBar2.SetMaxObjects(maxObjects);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            Debug.Log("girdi1");
            if (objects <= 2)
            {
                Debug.Log("girdi2");
                collision.gameObject.SetActive(false);
                objects++;
            }

        }
    }

    public void TakeObjects(int obj)
    {
        objects += obj;
        GreenBar2.SetHealth(objects);
    }
}
