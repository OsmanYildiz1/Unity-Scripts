using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombieHP = 100;
     bool zombiOlu;
    Animator death;
    public LayerMask zombiKatman; // hasar almas� i�in layer ekle



    void Start()
    {
        death = GetComponent<Animator>(); // animatoru yakala
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHP <100)
        {
            zombiOlu = true;
        }
        if (zombiOlu==true)
        {
            death.SetBool("death",true);   // zombi �l�yse �lme animasyonunu baslat
            StartCoroutine(yokOl());      // yok ol fonksiyonunu cag�r
        }
    }

    public void HasarAl()
    {
        zombieHP -= Random.Range(100, 100); // merminin verece�i hasar
    }
    IEnumerator yokOl()
    {
        yield return new WaitForSeconds(5); // 5 saniye bekle
        Destroy(this.gameObject);       // yok ol
    }
     void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("mermi"))   // �arp��an tag mermi ise 
        {
            zombiOlu = true;
            death.SetBool("death", true);   // zombi �ls�n ve �lme animasyonu baslas�n
        }
    }

}
