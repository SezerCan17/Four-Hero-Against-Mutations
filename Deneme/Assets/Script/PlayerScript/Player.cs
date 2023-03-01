using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private Animator myanims;
    PlayerHealth ph;
    GreenBar greenbar;
    

    [SerializeField]
    private float speed;
    private bool rlook;
    [SerializeField]
    private Transform[] ContactPoint;
    public float ContactDimater;
    public LayerMask whichGround;
    public Image[] hearths;
    private int hearth_=3;

    private bool inGround;
    private bool jump;
    private bool doubleJump;
    [SerializeField]
    private bool AirControll;
    public float JumpPower;

    private bool attack1;
    private bool attack2;
    private bool attack3;
    private bool Sp_attack;
    private bool roll;
    private bool dash;
    private bool defend;

    public GreenBar greenBar;
    public GameObject Obje;
    public int maxObjects = 100;
    public int objects;
    public int obj;


    public GameObject objects_;
    public int counterObjects = 0;
    

	void Start()
    {
        dash= false;
        rlook= true;
        rb2D= GetComponent<Rigidbody2D>();
        myanims= GetComponent<Animator>();
        ph = GetComponent<PlayerHealth>();
        greenbar = GetComponent<GreenBar>();
        Sp_attack = false;
        objects= 0;
        greenBar.SetMaxObject(objects);

	}

    private void Update()
    {
        Controller();
    }

    private void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        inGround = atGround();
        BasicMovement(hori);
        ChangeDirection(hori);
        AttackMovement();
        Reset_();
        
    }

    private void BasicMovement(float hori)
    {
        
        if(rb2D.velocity.y<0)
        {
            myanims.SetBool("Down", true);
            rb2D.velocity = new Vector2(hori * speed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(hori * speed, rb2D.velocity.y);
        }
        if(!dash && !myanims.GetBool("Roll") && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack1") && (inGround ||AirControll))
        {
            rb2D.velocity = new Vector2(hori * speed, rb2D.velocity.y);
        }
        else if(!dash && !myanims.GetBool("Roll") && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack2") && (inGround || AirControll))
        {
            rb2D.velocity = new Vector2(hori * speed, rb2D.velocity.y);
        }
        else if (!dash && !myanims.GetBool("Roll") && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack3") && (inGround || AirControll))
        {
            rb2D.velocity = new Vector2(hori * speed, rb2D.velocity.y);
        }

        if ((inGround || doubleJump) && jump )
        {
            if(inGround)
            {
                rb2D.AddForce(new Vector2(0, JumpPower));
                doubleJump = true;
            }
            else
            {
                rb2D.AddForce(new Vector2(0, JumpPower/1.2f));
                doubleJump =false; 
            }
            inGround= false;
            myanims.SetTrigger("Jump");
        }
        

        if (roll && !this.myanims.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            myanims.SetTrigger("Roll2");
            roll = false;
        }
       
        myanims.SetFloat("Speed",Mathf.Abs(hori));
    }

    

    private void AttackMovement()
    {
            if (attack1 && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack1"))
            {
                myanims.SetTrigger("Attack1");
                rb2D.velocity = Vector2.zero;
            }
            else if (attack2 && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
            {
                myanims.SetTrigger("Attack2");
                rb2D.velocity = Vector2.zero;
            }
            else if (attack3 && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack3"))
            {
                myanims.SetTrigger("Attack3");
                rb2D.velocity = Vector2.zero;
            }
    }

    

    public void Death()
    {
        myanims.SetTrigger("Death");
        hearth_ -= 1;

        if (hearth_ >= 0)
        {
            hearths[hearth_].gameObject.SetActive(false);
            ph.health = 100;
        }
        /*else if(hearth_<= -1)
        {

        }*/
        
    }

    public void SP_attack()
    {
        if (objects == 3)
        {
            Sp_attack = true;
        }
        if (Sp_attack)
        {
            myanims.SetTrigger("Sp_Attack");
            greenbar.greenSlider.value = 0;
            Sp_attack = false;
            objects = 0;
        }
    }

    private void Controller()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            attack1= true;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            attack2 = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            attack3 = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
                roll = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump= true;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
                defend = true;
                myanims.SetTrigger("Defend");
                rb2D.velocity = Vector2.zero;
        }
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            myanims.SetTrigger("JumpAttack");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            SP_attack();
        }
       
    }

    
    private void ChangeDirection(float hori)
    {
        if(hori>0 && !rlook || hori<0 && rlook)
        {
            rlook = !rlook;
            transform.Rotate(0, 180, 0);
        }
    }

    private void Reset_()
    {
        attack1= false;
        attack2= false;
        attack3 = false;
        roll = false;
        jump= false;
        dash= false;
    }

    private bool atGround()
    {
        if(rb2D.velocity.y<=0)
        {
            foreach(Transform nokta in ContactPoint)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(nokta.position, ContactDimater, whichGround);

                for(int i=0;i<colliders.Length;i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myanims.ResetTrigger("Jump");
                        myanims.SetBool("Down", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void TakeObject(int objects)
    {
        this.objects += 1;
        greenBar.SetObject(this.objects);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            if (objects <= 2)
            {
                Sp_attack= true; 
                TakeObject(objects);
                collision.gameObject.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            myanims.SetTrigger("Take_Hit");
            if (rlook == true)
                rb2D.AddForce(new Vector2(-2500, 10));
            else if (rlook == false)
                rb2D.AddForce(new Vector2(2500, 10));
        }
    }
}
