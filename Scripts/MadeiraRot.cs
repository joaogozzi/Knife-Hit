using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadeiraRot : MonoBehaviour
{

    public GameObject madeira;
    public float rotacao;
    public float velRotacao;



    void Start()
    {
        
    }

    void Update()
    {
        Rotacao();
    }

    private void Rotacao()
    {
        rotacao += Time.deltaTime * velRotacao;
        madeira.transform.rotation = Quaternion.Euler(0f, 0f, rotacao);
    }

}
