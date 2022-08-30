using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
    public float zombiHP = 100;
    bool zombiOlu;
    Animator zombiAnim;
    public float kovalamaMesafesi;
    public float saldirmaMesafesi;
    NavMeshAgent zombiNavMesh;
    GameObject hedefOyuncu;

    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("swat");
        zombiNavMesh = this.GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiHP<=0)
        {
            zombiOlu = true;
        }
        if (zombiOlu==true)
        {
            zombiAnim.SetBool("oldu", true);
            StartCoroutine(YokOl());
        }
        else
        {
           float mesafe =Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamaMesafesi)
            {
                zombiNavMesh.isStopped = false;
                zombiNavMesh.SetDestination(hedefOyuncu.transform.position);
                zombiAnim.SetBool("yuruyor",true);
                zombiAnim.SetBool("saldiriyor", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombiNavMesh.isStopped = true;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldiriyor", false);
            }
            if (mesafe < saldirmaMesafesi )
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombiNavMesh.isStopped = true;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldiriyor", true);
            }
        }
    }
    public void HasarAl()
    {
        zombiHP -=Random.Range(15,25) ;
    }
    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    public void HasarVer()
    {
        hedefOyuncu.GetComponent<KarakterKontrol>().HasarAl();
    }
}
