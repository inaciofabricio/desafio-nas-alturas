using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaObstaculoCoop : MonoBehaviour
{
    [SerializeField]
    private VariavelCompartilhadaFloat Velocidade;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private bool parado = false;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    void Update()
    {
        if (!this.parado)
        {
            this.transform.Translate(Vector3.left * Velocidade.valor * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barreira"))
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void Parar()
    {
        this.parado = true;
    }
}
