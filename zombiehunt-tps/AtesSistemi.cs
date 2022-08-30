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
        kamera = Camera.main;   // maincameray� kameraya e�itler
        hpKontrol = this.gameObject.GetComponent<KarakterKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpKontrol.YasiyorMu()== true)   // karakter ya��yorsa
        {
            if (Input.GetMouseButtonDown(0))    // ve sol tu�a bas�yorsa
            {
                AtesEtme();     // ate� etme fonksiyonu �al��s�n
            }
        }
        
       
    }
    private void AtesEtme()
    {
        muzzleFlash.Play();             
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));    // ekran�n ortas�n� se�
        RaycastHit hit;     // vurma i�in
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiKatman)) // zombikatmana vur 
        {
            hit.collider.gameObject.GetComponent<Zombi>().HasarAl();    // �arp��ma olursa zombi hasar als�n
        }

    }
}
