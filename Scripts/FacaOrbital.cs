using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacaOrbital : MonoBehaviour
{
    public Transform meio;
    public Vector3 eixo = Vector3.forward;
    public Vector3 posicao;
    public float raio;
    public float raioVel = 0.5f;
    public float velociadeRot;
    private Rigidbody2D rb;
    private BoxCollider2D facaCol;
    public GameObject spawn;
    public GameObject contador;
    public bool acertou;
    public GameObject alvo;
    public float speed;
    public bool podeClick;
    public ParticleSystem batida;
    private AudioSource som;
    public AudioClip bateuAlvo;
    public AudioClip bateuFaca;
 
    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        facaCol = GetComponent<BoxCollider2D>();
        som = GetComponent<AudioSource>();
        podeClick = true;
    }
     
    void Update () {
        if(podeClick == true)
        {
            transform.RotateAround (meio.position, eixo, velociadeRot * Time.deltaTime);
            posicao = (transform.position - meio.position).normalized * raio + meio.position;
            transform.position = Vector3.MoveTowards(transform.position, posicao, Time.deltaTime * raioVel);
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(podeClick == true)
            {
                float passo =  speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, passo);
            }
        }
    }

private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Alvo")
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(col.collider.transform);
            facaCol.offset = new Vector2(0.2f, -0.75f);
            facaCol.size = new Vector2(1, 2.76f);
            spawn.SetActive(true);
            contador.GetComponent<Contador>().pontos ++;
            acertou = true;
            podeClick = false;
            Batida();
            som.PlayOneShot(bateuAlvo);
        }
        if(col.collider.tag == "Faca")
        {
            rb.gravityScale = 1;
            contador.GetComponent<Contador>().gameOver.SetActive(true);
            Time.timeScale = 0;
            som.PlayOneShot(bateuFaca);
        }
    }

   public void Batida()
   {
       batida.Play();
   } 

}
