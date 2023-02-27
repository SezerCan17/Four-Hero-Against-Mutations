using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Objects : MonoBehaviour
{

    public Player Player;
    public GreenBar greenBar;
    public GameObject Obje;
    public Animator myanims;
    public int maxObjects = 100;
    public int objects;
    public int obj;

    
    void Start()
    {
        objects = 0;
        Player = GetComponent<Player>();
        greenBar.SetMaxHealth(objects);
    }
    public void TakeDamage(int damage)
    {

        objects += 1;
        obj = objects;

        greenBar.SetHealth(obj);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            TakeDamage(obj);
            Obje.SetActive(false);

        }
    }
}
