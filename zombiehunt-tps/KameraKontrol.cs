using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;
    [SerializeField]
    private float fareHassasiyeti;
    float fareX;
    float fareY;

    Vector3 objRot;
    public Transform karakterVucut;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // oyundayken imleci kaldırma
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,hedef.position+ hedefMesafe, Time.deltaTime*10); // uygun kamera açısı 
        fareX += Input.GetAxis("Mouse X")*fareHassasiyeti;
        fareY += Input.GetAxis("Mouse Y")*fareHassasiyeti;  // fare hareketini ayarla
        if (fareY>=25)
        {
            fareY = 25;     // karakter 360 dönmesin diye
        }
        if (fareY<=-40)
        {
            fareY = -40;    // karakter 360 dönmesin diye
        }
        this.transform.eulerAngles = new Vector3(-fareY,fareX,0);   // kamera açısını ve yukarı aşağı bakmayı ayarlama
        hedef.transform.eulerAngles= new Vector3(0, fareX,0);

        Vector3 gecici = this.transform.localEulerAngles;
        gecici.z = 0;
        gecici.y = this.transform.localEulerAngles.y;
        gecici.x = this.transform.localEulerAngles.x + 10;
        objRot = gecici;
        karakterVucut.transform.eulerAngles = objRot;
    }
}
