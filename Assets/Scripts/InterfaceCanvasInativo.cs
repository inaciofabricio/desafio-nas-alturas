using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceCanvasInativo : MonoBehaviour
{
    [SerializeField]
    private GameObject fundo;
    private Canvas canvas;
    [SerializeField]
    private Text textPontosParaReviver;

    private void Awake()
    {
        this.canvas = this.GetComponent<Canvas>();
    }

    public void Mostrar(Camera camera)
    {
        this.fundo.SetActive(true);
        this.canvas.worldCamera = camera;
    }

    public void AtualizarTexto(int pontosParaReviver)
    {
        this.textPontosParaReviver.text = pontosParaReviver.ToString();
    }

    internal void Sumir()
    {
        this.fundo.SetActive(false);
    }
}
