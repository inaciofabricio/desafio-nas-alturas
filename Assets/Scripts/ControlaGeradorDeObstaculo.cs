using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaGeradorDeObstaculo : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    private float cronometro;
    [SerializeField]
    private GameObject obstaculo;
    private ControleDeDificuldade controleDeDificuldade;
    private bool parado = false;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
        GerarObstaculo();
    }

    private void Start()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.parado)
        {
            this.cronometro -= Time.deltaTime;
            if (this.cronometro < 0)
            {
                GerarObstaculo();
                this.cronometro = Mathf.Lerp(this.tempoParaGerarFacil, this.tempoParaGerarDificil, this.controleDeDificuldade.Dificuldade);
            }
        }
    }

    void GerarObstaculo()
    {
        GameObject.Instantiate(obstaculo, this.transform.position, Quaternion.identity);
    }

    public void Parar()
    {
        this.parado = true;
    }

    public void Recomecar()
    {
        this.parado = false;
    }
}
