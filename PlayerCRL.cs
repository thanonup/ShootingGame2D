using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCRL : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public int Pspeed;
    public int Jspeed;
    public bool checkGround = false;
    public GameObject Shoot;
    public bool checkFlip = true;
    public bool test;
    public bool Notshoot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        moveHorizontal *= Pspeed;
        if(moveHorizontal == 0 && moveVertical == 0)
        {
            Notshoot = true;
        }
        else
        {
            Notshoot = false;
        }
        if(moveHorizontal != 0) { moveplayer(moveHorizontal); }
        else { moveplayerstop(); }

        if(moveVertical > 0 && !checkGround) { jumpUP(moveVertical); }
        else { Jumpstop(); }

        if (moveVertical < 0) { Crouch(moveVertical); }
        else { Crouchstop(); }

    }
    public void moveplayer(float playermove1)
    {
        rb.velocity = new Vector2(playermove1, rb.velocity.y);
        if(playermove1 > 0 && !checkFlip) 
        {
            flip();
            
        }
        else if(playermove1 < 0 && checkFlip) 
        {
            flip();
        }
        
        anim.SetBool("Run", true);
    }
    public void moveplayerstop()
    {
        anim.SetBool("Run", false);
    }
    public void jumpUP(float jump)
    {
        rb.velocity = new Vector2(rb.velocity.x, jump*Jspeed);
        anim.SetBool("Jump", true);
    }
    public void Jumpstop()
    {
        anim.SetBool("Jump", false);
    }
    public void Crouch(float jump)
    {
        anim.SetBool("Crouch", true);
    }
    public void Crouchstop()
    {
        anim.SetBool("Crouch", false);
    }
    public void flip()
    {
        checkFlip = !checkFlip;
        

        transform.Rotate(0f, 180f, 0f);
    }
    public void Shoota()
    {
        anim.SetBool("Fire", true);
    }
    public void Shootstop()
    {
        anim.SetBool("Fire", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") { checkGround = false; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") { checkGround = true; }
    }
}
