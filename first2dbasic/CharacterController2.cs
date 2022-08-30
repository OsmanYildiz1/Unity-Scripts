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

     void Awake()   // Awake starttan �nce �al���r. 
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
        if (_rigidbody2D.velocity != Vector2.zero) // karakterin velocitysi(h�z�) 0 de�ilse- hareket varsa
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
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce); // y ekseninde z�plama kuvveti
            jump = false;
            

        }
    }
    void Update() // Update is called once per frame
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // zemine bas�l�yorsa ve a veya d ye bas�l�yorsa
        {
            if (Input.GetKey(KeyCode.A))
            {                                                     // A'ya bas�l�yorsa sola git
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {                                                      // D'ya bas�l�yorsa sola git// A'ya bas�l�yorsa sola git
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded==true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);                   // hi�bir �eye bas�lm�yorsa hareket etme
        }

        if (grounded== true && Input.GetKey(KeyCode.W))     
        {
            jump = true;
            grounded = false;           // W'ya bas�l�yorsa z�plama animasyonu cal�ss�n
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);     // zemin olarak tan�mlanan yerlere �arp��ma oluyorsa zemin true olsun
            grounded = true;
        }
        
    }

}
