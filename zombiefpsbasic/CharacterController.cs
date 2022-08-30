using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody rb;
    Transform anaKamera, mermiYeri;
    float mermiHizi = 1000f;
    public float fareHassasiyeti =5f;
    public GameObject mermi;
    float dikey = 0f;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();     // rigidbodyi yakala
        anaKamera = GameObject.FindGameObjectWithTag("MainCamera").transform;  // cameray� yakala
        mermiYeri = GameObject.FindGameObjectWithTag("BulletSpawn").transform;  // mermi spawn noktas�n� yakala
        Cursor.lockState = CursorLockMode.Locked;   // oyun baslay�nca imleci kapat
        Cursor.visible = false;         // g�r�n�rl���n� kapat
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(mermiSure());    // ate� edilirse fonksiyonu �a��r
            //atesEtme();
        }
        fareKontrol();

       
      
        
    }
    void fareKontrol()
    {
        float yatay = Input.GetAxis("Mouse X")* fareHassasiyeti;    // eksenlerde fare hareketi
        dikey += Input.GetAxis("Mouse Y") * fareHassasiyeti;
        dikey = Mathf.Clamp(dikey, -60, 80);                                 // karakterin nisan al�rken ters d�nmemesi i�in
        anaKamera.transform.localRotation = Quaternion.Euler(-dikey, 0f, 0f);
        transform.Rotate(0f, yatay, 0f);            
    }
    IEnumerator mermiSure()
    {
        GameObject mermiOlustu = Instantiate(mermi, mermiYeri.transform.position, mermiYeri.transform.rotation); // objelere g�re mermi olu�tur
        mermiOlustu.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * mermiHizi);   // g�� ekleme 
        yield return new WaitForSeconds(3);     // 3 saniye bekle yok ol
        Destroy(mermiOlustu);           // mermiyi yok et
    }


    /*void atesEtme()   // lazer ile ate� etme kodu
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit , Mathf.Infinity, zombiKatman))
        {
            hit.collider.gameObject.GetComponent<Zombie>().HasarAl();
        }
    */
}
