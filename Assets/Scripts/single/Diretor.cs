using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diretor : MonoBehaviour
{
    private ControlaAviao controlaAviao;
    private Pontuacao pontuacao;
    private InterfaceGrafica interfaceGrafica;
    private ControlaGeradorDeObstaculo controlaGeradorDeObstaculo;

    private void Start() // protected virtual void Start() //No caso de Herança
    {
        this.controlaAviao = GameObject.FindObjectOfType<ControlaAviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGrafica = GameObject.FindObjectOfType<InterfaceGrafica>();
        this.controlaGeradorDeObstaculo = GameObject.FindObjectOfType<ControlaGeradorDeObstaculo>();
    }

    public void FinalizarJogo()
    {
        this.pontuacao.SalvarPontuacao();
        this.interfaceGrafica.MostrarInterface();
        this.DestruirObstaculos();
        this.controlaGeradorDeObstaculo.Parar();
    }

    public void ReiniciarJogo()
    {
        this.interfaceGrafica.EsconderInterface();
        this.controlaAviao.Reiniciar();
        this.pontuacao.Reiniciar();
        this.controlaGeradorDeObstaculo.Recomecar();
    }

    public void VoltarParaMenu()
    {
        StartCoroutine(MudarCena("menu"));
    }

    IEnumerator MudarCena(string name)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(name);
    }

    private void DestruirObstaculos()
    {
        ControlaObstaculoCoop[] obstaculos = GameObject.FindObjectsOfType<ControlaObstaculoCoop>();
        foreach (ControlaObstaculoCoop obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
