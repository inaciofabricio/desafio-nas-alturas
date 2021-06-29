using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{
    [SerializeField]
    private float tempoParaDifculdadeMaxima;
    private float tempoPassadoTotal;
    private float tempoPassado;
    public float Dificuldade { get; private set; }
        
    void Update()
    {
        this.tempoPassado += Time.deltaTime - tempoPassadoTotal;
        this.Dificuldade = this.tempoPassado / this.tempoParaDifculdadeMaxima;
        this.Dificuldade = Mathf.Min(1, this.Dificuldade);
    }

    public void ResetaTempo()
    {
        this.tempoPassadoTotal = Time.deltaTime;
    }
}
