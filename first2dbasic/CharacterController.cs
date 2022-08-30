using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    private int sayi;
    


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // caching
        r2d = GetComponent<Rigidbody2D>(); // caching r2d
        _animator = GetComponent<Animator>(); //  caching anim
        charPos = transform.position;
        sayi = 1;


    }  
    void FixedUpdate() // 50 fps
    {
        
        // r2d.velocity = new Vector2(speed, 0f); // charpos transform ile yaz�lan kodun altenatifi 
        // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f); // bu kod fixed update de 
        //  yaz�l�rsa gecikme olur late updatede yaz�lmal�
        sayi = 2;
    }


    void Update() // update fonksiyonu her karede �a��r�lan bir fonksyion. per frame(saniye/frame ba��na)
    {
      
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos; // hesaplad���m pozisyon karakterime i�lensin
        if (Input.GetAxis("Horizontal") == 0.0f) // yatayda bir giri� yoksa 
        {
            _animator.SetFloat("speed", 0.0f); // karakter harektetsiz
        }
        else
        {
            _animator.SetFloat("speed", speed); // girdi varsa hareketli
        }
        if (Input.GetAxis("Horizontal") > 0.01f) // karakterin y�n� pozitifse
        {
            _spriteRenderer.flipX = false; // sa�a d�n
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;   // negatifse sola d�n
        }
        

        sayi = 3;
        Debug.Log("Update" + sayi);
    }

    private void LateUpdate()
    {
        // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z-1.0f); // karakterin kamera takibi
        sayi = 4;
    }
}
