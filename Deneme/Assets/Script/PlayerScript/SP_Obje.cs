using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Obje : MonoBehaviour
{

    Player Player;
    public Animator myanims;
    public int maxObjects = 100;
    public int objects;

    public HealthBar healthBar;
    void Start()
    {
        objects = maxObjects;
        Player = GetComponent<Player>();
        healthBar.SetMaxHealth(maxObjects);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeObjects(1);
        }
    }


    public void TakeObjects(int obj)
    {

        objects += obj;
        if (objects <= 0)
        {
            Player.Death();
        }
        healthBar.SetHealth(objects);
    }
}
