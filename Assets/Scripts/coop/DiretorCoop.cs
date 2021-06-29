using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiretorCoop : MonoBehaviour
{
    [SerializeField]
    private int pontosParaReviver;
    //private ControlaAviaoCoop controlaAviao;
    private Pontuacao pontuacao;
    private ControleDeDificuldade controleDeDificuldade;
    private InterfaceGrafica interfaceGrafica;
    private bool alguemMorto = false;
    private int pontosDesdeAMorte = 0;
    private Jogador[] jogadores;
    private InterfaceCanvasInativo interfaceInativo;
    [SerializeField]

    private void Start() // protected override void Start() //No caso de Herança
    {
        //base.Start(); //No caso de Herança
        
        //this.controlaAviao = GameObject.FindObjectOfType<ControlaAviaoCoop>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGrafica = GameObject.FindObjectOfType<InterfaceGrafica>();
        this.interfaceInativo = GameObject.FindObjectOfType<InterfaceCanvasInativo>();
        this.jogadores = GameObject.FindObjectsOfType<Jogador>();
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    public void FinalizarJogo()
    {
        this.pontuacao.SalvarPontuacao();
        this.interfaceGrafica.MostrarInterface();
    }

    public void ReiniciarJogo()
    {
        StartCoroutine(ResetaCena());
    }

    IEnumerator ResetaCena()
    {
        //Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        this.interfaceGrafica.EsconderInterface();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();
        //Time.timeScale = 1;
        this.ReviverJogadores();
        this.controleDeDificuldade.ResetaTempo();
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

    private void ReviverJogadores()
    {
        this.alguemMorto = false;
        foreach (var jogador in this.jogadores)
        {
            jogador.Ativar();
        }
    }

    public void AvisaQueAlguemMorreu(Camera camera)
    {
        if (this.alguemMorto)
        {
            this.interfaceInativo.Sumir();
            this.FinalizarJogo();
        }
        else
        {
            this.alguemMorto = true;
            this.pontosDesdeAMorte = 0;
            this.interfaceInativo.Mostrar(camera);
            this.interfaceInativo.AtualizarTexto(pontosParaReviver);
        }
    }

    public void ReviverSePrecisar()
    {
        if (this.alguemMorto)
        {
            this.pontosDesdeAMorte++;
            this.interfaceInativo.AtualizarTexto(pontosParaReviver - pontosDesdeAMorte);
            if (this.pontosDesdeAMorte >= pontosParaReviver)
            {
                this.interfaceInativo.Sumir();
                this.ReviverJogadores();
            }
        }
    }
}
