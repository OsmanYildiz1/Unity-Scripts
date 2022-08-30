using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce =5.0f;
    public float speed =2.0f;
    public float moveDirection;


    private bool moving;
    private bool grounded = true;
    private bool jump;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;

     void Awake()   // Awake starttan önce çalýþýr. 
    {
        anim = GetComponent<Animator>(); // caching
    }
    void Start()   // Start is called before the first frame update
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // caching
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


     void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero) // karakterin velocitysi(hýzý) 0 deðilse- hareket varsa
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y); // velocity ile hareket
        if (jump==true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce); // y ekseninde zýplama kuvveti
            jump = false;
            

        }
    }
    void Update() // Update is called once per frame
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // zemine basýlýyorsa ve a veya d ye basýlýyorsa
        {
            if (Input.GetKey(KeyCode.A))
            {                                                     // A'ya basýlýyorsa sola git
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {                                                      // D'ya basýlýyorsa sola git// A'ya basýlýyorsa sola git
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded==true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);                   // hiçbir þeye basýlmýyorsa hareket etme
        }

        if (grounded== true && Input.GetKey(KeyCode.W))     
        {
            jump = true;
            grounded = false;           // W'ya basýlýyorsa zýplama animasyonu calýssýn
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);     // zemin olarak tanýmlanan yerlere çarpýþma oluyorsa zemin true olsun
            grounded = true;
        }
        
    }

}
