using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private CarrosselCoop[] cenario;
    private ControlaGeradorDeObstaculo geradorObstaculo;
    //private ControlaObstaculoCoop obstaculo;
    private ControlaAviaoCoop aviao;
    private bool estouMorto;
    private AtivarJogarAnimacao animacao;

    void Start()
    {
        this.cenario = this.GetComponentsInChildren<CarrosselCoop>();
        this.geradorObstaculo = this.GetComponentInChildren<ControlaGeradorDeObstaculo>();
        //this.obstaculo = this.GetComponentInChildren<ControlaObstaculoCoop>();
        this.aviao = this.GetComponentInChildren<ControlaAviaoCoop>();
        this.animacao = this.GetComponentInChildren<AtivarJogarAnimacao>();
    }

    public void Desativar()
    {
        this.geradorObstaculo.Parar();
        //this.obstaculo.Parar();
        this.estouMorto = true;
        foreach (var carrossel in this.cenario)
        {
            carrossel.enabled = false;
        }
    }

    public void Ativar()
    {
        if (this.estouMorto)
        {
            this.geradorObstaculo.Recomecar();
            //this.obstaculo.Recomecar();
            foreach (var carrossel in this.cenario)
            {
                carrossel.enabled = true;
            }
            this.animacao.ResetarAnimacao();
            this.aviao.Reiniciar();
        }

        this.estouMorto = false;
    }

}
