using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
      private Scene _scene; // y�ntem 1 level ge�i�i
    // [SerializeField] private int SceneIndex; // 2. y�ntem level ge�isi

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); // caching 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // e�er obje player ise
        {
              SceneManager.LoadScene(_scene.buildIndex+1); // bir sonraki sahneyi �a��r. y�ntem 1 level ge�i�i
            // SceneManager.LoadScene(SceneIndex); // bu y�ntemle sahnedeki finish i�ine elle ge�ilen sahne indeksi yaz�lmal�
            // 2. y�ntem
        }

    }

    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1); // sahneyi y�kle
    }
}
