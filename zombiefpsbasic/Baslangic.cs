using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baslangic : MonoBehaviour
{
    private Scene _scene;
    void Awake()
    {
        _scene = SceneManager.GetActiveScene(); // aktif sahneyi yakala
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex+1); // sonraki levele geç
    }
}
