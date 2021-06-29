using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaAviaoCoop : MonoBehaviour
{
    Rigidbody2D fisica;
    [SerializeField]
    private float forca = 10;
    private Vector3 posicaoInicial;
    private bool deveImpusionar;
    private Animator animacao;
    private AtivarJogarAnimacao ativa;
    [SerializeField]
    private UnityEvent aoBater;
    [SerializeField]
    private UnityEvent aoPassarPeloObstaculo;
    [SerializeField]
    

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        this.animacao = this.GetComponent<Animator>();
        this.ativa = this.GetComponentInChildren<AtivarJogarAnimacao>();
        
    }

    void Update()
    {
        this.animacao.SetFloat("VelocidadeY", this.fisica.velocity.y);
    }

    private void FixedUpdate()
    {
        if (this.deveImpusionar)
        {
            this.Impulsionar();
        }
    }

    public void DarImpulso()
    {
        this.deveImpusionar = true;
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
        this.aoBater.Invoke();
    }

    public void Reiniciar()
    {
        this.transform.position = posicaoInicial;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.aoPassarPeloObstaculo.Invoke();
    }
}
