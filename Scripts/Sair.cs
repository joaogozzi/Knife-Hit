using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair : MonoBehaviour
{
    
    private string cena = "Queijo";
    
    public void Fechar()
    {
        Application.Quit();
    }

    public void Começa()
    {
        SceneManager.LoadScene(cena);
    }

}
