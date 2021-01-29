using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public int pontos;
    public int objetivo;
    public GameObject win;
    public GameObject gameOver;
    public string proximaFase;
    private bool morreu;
    private AudioSource som;
    public AudioClip nextLevel;
    private bool canPlay;

    
    void Start()
    {
        Time.timeScale = 1;
        som = GetComponent<AudioSource>();
        canPlay = true;
    }


    void Update()
    {
        if(pontos == objetivo)
        {
            win.SetActive(true);
            if(canPlay == true)
            {
                som.PlayOneShot(nextLevel);
                canPlay = false;
            }
        }
    }

    public void Win()
    {
        if(morreu == false)
        {
            SceneManager.LoadScene(proximaFase);
            Time.timeScale = 0;
        }
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        morreu = true;
    }

}
