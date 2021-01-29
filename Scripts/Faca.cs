using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faca : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D facaCol;
    [SerializeField] private Vector2 forca;
    public bool acertou;
    [SerializeField] private GameObject faca;
    [SerializeField] private GameObject contador;
    public ParticleSystem batida;
    private AudioSource som;
    public AudioClip bateuAlvo;
    public AudioClip bateuFaca;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facaCol = GetComponent<BoxCollider2D>();
        som = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(forca, ForceMode2D.Impulse);
        }
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Alvo")
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(col.collider.transform);
            facaCol.offset = new Vector2(0.09f, -3.2f);
            facaCol.size = new Vector2(0.6f, 3.27f);
            faca.SetActive(true);
            contador.GetComponent<Contador>().pontos ++;
            acertou = true;
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


