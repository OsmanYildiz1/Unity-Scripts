using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
      private Scene _scene; // yöntem 1 level geçiþi
    // [SerializeField] private int SceneIndex; // 2. yöntem level geçisi

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); // caching 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // eðer obje player ise
        {
              SceneManager.LoadScene(_scene.buildIndex+1); // bir sonraki sahneyi çaðýr. yöntem 1 level geçiþi
            // SceneManager.LoadScene(SceneIndex); // bu yöntemle sahnedeki finish içine elle geçilen sahne indeksi yazýlmalý
            // 2. yöntem
        }

    }

    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1); // sahneyi yükle
    }
}
