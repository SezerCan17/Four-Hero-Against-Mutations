using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnims;

   
    [SerializeField]
    Transform GroundControlPoint;

    public float speed;
    private bool rlook;
    
    public bool roll_;
    
    

    public float JumpPower;
    public bool InGround;
    private bool doubleJump;
    

    public LayerMask GroundMask;

    

    void Start()
    {
        rlook= true;
        roll_= false;
        rb2D= GetComponent<Rigidbody2D>();
        myAnims= GetComponent<Animator>();
    }

   
    void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        BasicMove(hori);
        ChangeDirection(hori);
        Controllerr();
        Jump();
        Down();
        
    }

    private void Controllerr()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            roll_= true;
        }
    }


    private void BasicMove(float hori)
    {
       if(!myAnims.GetBool("Roll"))
        {
            rb2D.velocity = new Vector2(speed * hori, rb2D.velocity.y);

        }
       if(roll_ && !this.myAnims.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            myAnims.SetBool("Roll", true);

        }
       else if(!this.myAnims.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            myAnims.SetBool("Roll", false);
        }
        myAnims.SetFloat("Speed",Mathf.Abs(hori)); 

            
    }

    private void ChangeDirection(float hori)
    {
        if(rlook && hori<0 || !rlook && hori > 0)
        {
            rlook=!rlook;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;

            roll_ = false;
            myAnims.SetBool("Roll",false);
        }
    }

    private void Jump()
    {
        InGround= Physics2D.OverlapCircle(GroundControlPoint.position, .2f, GroundMask);

        if(Input.GetButtonDown("Jump")&& (InGround ||doubleJump))
        {
            if(InGround)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, JumpPower);
                doubleJump = true;
                myAnims.SetBool("Jump", true);
                myAnims.SetBool("Down", false);

            }
            else
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, JumpPower);
                myAnims.SetBool("Jump", true);
                myAnims.SetBool("Down", false);
                doubleJump = false;
                
            }
            
            
            
        }
        
    }

    private void Down()
    {
        if (rb2D.velocity.y < 0)
        {
            Debug.Log("GÝRDÝ");
            myAnims.SetBool("Jump", false);
            myAnims.SetBool("Down", true);
        }
        else if( rb2D.velocity.y == 0) 
        {
            myAnims.SetBool("Down", false);
        }
    }
    
    
    

}

