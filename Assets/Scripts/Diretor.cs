using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    
    private ControlaAviao controlaAviao;
    private Pontuacao pontuacao;
    private InterfaceGrafica interfaceGrafica;

    private void Start()
    {
        this.controlaAviao = GameObject.FindObjectOfType<ControlaAviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGrafica = GameObject.FindObjectOfType<InterfaceGrafica>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.pontuacao.SalvarPontuacao();
        this.interfaceGrafica.MostrarInterface();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        this.interfaceGrafica.EsconderInterface();
        this.controlaAviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();
    }

    private void DestruirObstaculos()
    {
        ControlaObstaculo[] obstaculos = GameObject.FindObjectsOfType<ControlaObstaculo>();
        foreach (ControlaObstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
