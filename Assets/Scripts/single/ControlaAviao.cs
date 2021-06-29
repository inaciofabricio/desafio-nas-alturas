using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaAviao : MonoBehaviour
{
    Rigidbody2D fisica;
    [SerializeField]
    private float forca = 10;
    private Diretor diretor;
    private Vector3 posicaoInicial;
    private bool deveImpusionar;
    private Animator animacao;
    [SerializeField]
    private UnityEvent aoPassarPeloObstaculo;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        this.animacao = this.GetComponent<Animator>();
    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.deveImpusionar = true;
        }
        
        this.animacao.SetFloat("VelocidadeY", this.fisica.velocity.y);
    }

    private void FixedUpdate()
    {
        if (this.deveImpusionar)
        {
            this.Impulsionar();
        }        
    }

    void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpusionar = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.fisica.simulated = false;
        this.diretor.FinalizarJogo();
    }

    public void Reiniciar()
    {
        StartCoroutine(RetomarFisica());
        this.transform.position = posicaoInicial;
    }

    IEnumerator RetomarFisica()
    {
        yield return new WaitForSeconds(0.3f);
        this.fisica.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.aoPassarPeloObstaculo.Invoke();
    }
}
