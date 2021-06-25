using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGrafica : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private Text textoPontuacaoRecorde;
    private Pontuacao pontuacao;
    private int recorde;
    [SerializeField]
    private Image posivaoMedalha;
    [SerializeField]
    private Sprite medalhaOuro;
    [SerializeField]
    private Sprite medalhaPrata;
    [SerializeField]
    private Sprite medalhaBronze;

    private void Start()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void MostrarInterface()
    {
        this.AtualizaInterfaceGrafica();
        this.imagemGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        this.imagemGameOver.SetActive(false);
    }

    private void AtualizaInterfaceGrafica()
    {
        recorde = PlayerPrefs.GetInt("recorde");
        this.textoPontuacaoRecorde.text = recorde.ToString();
        this.VerificarCorMedalha();
    }

    private void VerificarCorMedalha()
    {
        if (this.pontuacao.Pontos > this.recorde - 2)
        {
            this.posivaoMedalha.sprite = this.medalhaOuro;
        }
        else if(this.pontuacao.Pontos > this.recorde / 2)
        {
            this.posivaoMedalha.sprite = this.medalhaPrata;
        }
        else
        {
            this.posivaoMedalha.sprite = this.medalhaBronze;
        }
    }
}
