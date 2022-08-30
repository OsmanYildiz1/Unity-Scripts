using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpisma : MonoBehaviour
{
    public bool duvaracarpti;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("duvar"))
        {
            duvaracarpti = true;
        }
    }
}
