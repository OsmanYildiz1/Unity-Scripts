using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    public Camera kamera;
    public LayerMask zombiKatman;
    KarakterKontrol hpKontrol;
    public ParticleSystem muzzleFlash;
    
    void Start()
    {
        kamera = Camera.main;   // maincamerayý kameraya eþitler
        hpKontrol = this.gameObject.GetComponent<KarakterKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpKontrol.YasiyorMu()== true)   // karakter yaþýyorsa
        {
            if (Input.GetMouseButtonDown(0))    // ve sol tuþa basýyorsa
            {
                AtesEtme();     // ateþ etme fonksiyonu çalýþsýn
            }
        }
        
       
    }
    private void AtesEtme()
    {
        muzzleFlash.Play();             
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));    // ekranýn ortasýný seç
        RaycastHit hit;     // vurma için
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiKatman)) // zombikatmana vur 
        {
            hit.collider.gameObject.GetComponent<Zombi>().HasarAl();    // çarpýþma olursa zombi hasar alsýn
        }

    }
}
