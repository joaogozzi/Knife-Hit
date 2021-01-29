using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudFacaNormal : MonoBehaviour
{
    public GameObject faca;
    public Image faquinha;
    public Sprite faquinhaApagado;
    void Start()
    {
        
    }


    void Update()
    {
        if(faca.GetComponent<Faca>().acertou == true)
        {
            faquinha.sprite = faquinhaApagado;
        } 
    }
}
