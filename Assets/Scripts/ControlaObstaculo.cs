using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaObstaculo : MonoBehaviour
{
    [SerializeField]
    private VariavelCompartilhadaFloat Velocidade;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private Vector3 posicaoDoAviao;
    private Pontuacao pontuacao;
    private bool pontuei;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Start()
    {
        this.posicaoDoAviao = GameObject.FindObjectOfType<ControlaAviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * Velocidade.valor * Time.deltaTime);

        if (!this.pontuei && this.transform.position.x < this.posicaoDoAviao.x)
        {
            this.pontuei = true;
            this.pontuacao.AdicionarPontos();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
