using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scenetogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            SceneManager.LoadScene(scenetogo);
            DontDestroyOnLoad(collision.gameObject);
        }
    }
}
