using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private Animator myanims;
    Bow bow;

    [SerializeField]
    private float speed;
    private bool rlook;
    [SerializeField]
    private Transform[] ContactPoint;
    public float ContactDimater;
    public LayerMask whichGround;

    private bool inGround;
    private bool jump;
    private bool doubleJump;
    [SerializeField]
    private bool AirControll;
    public float JumpPower;

    private bool attack1;
    private bool attack2;
    private bool attack3;
    private bool roll;
    private bool dash;
    private bool defend;

    void Start()
    {
        dash= false;
        rlook= true;
        rb2D= GetComponent<Rigidbody2D>();
        myanims= GetComponent<Animator>();
        
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
        if(attack1 && !this.myanims.GetCurrentAnimatorStateInfo(0).IsTag("Attack1"))
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
}
