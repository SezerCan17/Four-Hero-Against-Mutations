using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public GameObject objects;
    private Animator myAnims;
    public int counter=0;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Sp_Attack();
        }
    }

    private void Sp_Attack()
    {
        if(counter == 3) 
        {
            myAnims.SetTrigger("Sp_Attack");
            counter= 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objects"))
        {
            if (counter <= 2)
            {
                counter++;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objects"))
        {
            gameObject.SetActive(false);
        }
    }
}
