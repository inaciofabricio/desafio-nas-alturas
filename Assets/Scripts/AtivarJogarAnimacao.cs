using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtivarJogarAnimacao : MonoBehaviour
{
    [SerializeField]
    private UnityEvent aoTerminarAnimacao;
    private Animator animator;

    private void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
    }

    public void AtivarJogador()
    {
        this.aoTerminarAnimacao.Invoke();
    }

    public void ResetarAnimacao()
    {
        this.animator.Rebind();
    }

}
