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
        
        // r2d.velocity = new Vector2(speed, 0f); // charpos transform ile yazýlan kodun altenatifi 
        // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f); // bu kod fixed update de 
        //  yazýlýrsa gecikme olur late updatede yazýlmalý
        sayi = 2;
    }


    void Update() // update fonksiyonu her karede çaðýrýlan bir fonksyion. per frame(saniye/frame baþýna)
    {
      
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos; // hesapladýðým pozisyon karakterime iþlensin
        if (Input.GetAxis("Horizontal") == 0.0f) // yatayda bir giriþ yoksa 
        {
            _animator.SetFloat("speed", 0.0f); // karakter harektetsiz
        }
        else
        {
            _animator.SetFloat("speed", speed); // girdi varsa hareketli
        }
        if (Input.GetAxis("Horizontal") > 0.01f) // karakterin yönü pozitifse
        {
            _spriteRenderer.flipX = false; // saða dön
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;   // negatifse sola dön
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
