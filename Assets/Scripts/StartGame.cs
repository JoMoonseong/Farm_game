using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource source;

    
    void Start()
    {
        source.Play();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);

        source.Stop();
    }

}
