using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int Pontos{get; private set; }
    [SerializeField]
    private Text textoPontuacao;
    private AudioSource audioPontuacao;

    private void Awake()
    {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    public void AdicionarPontos()
    {
        this.Pontos++;
        this.textoPontuacao.text = this.Pontos.ToString();
        this.audioPontuacao.Play();
    }

    public void Reiniciar()
    {
        this.Pontos = 0;
        this.textoPontuacao.text = this.Pontos.ToString();
    }

    public void SalvarPontuacao()
    {
        if(this.Pontos > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", this.Pontos);
        }
    }
}
