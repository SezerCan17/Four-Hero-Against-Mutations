/*using System.Collections;
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
    public bool Sp_attack;
    public int obj;

    
    void Start()
    {
        Sp_attack= false;
        objects = 0;
        Player = GetComponent<Player>();
        greenBar.SetMaxObject(objects);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            myanims.SetTrigger("Sp_Attack");
        }
    }

    /*public void Sp_Attack()
    {
        if (obj == 3)
        {
            Sp_attack = true;
        }
        if (Sp_attack)
        {
            myanims.SetTrigger("Sp_Attack");
            Sp_attack = false;
            objects = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        objects += 1;
        obj = objects;
        greenBar.SetObject(obj);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            if (obj <= 2)
            {
                TakeDamage(obj);
                collision.gameObject.SetActive(false);
            }
        }
    }
}*/
