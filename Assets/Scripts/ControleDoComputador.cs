using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoComputador : MonoBehaviour
{
    [SerializeField]
    private float intervalo = 0.5f;
    private ControlaAviaoCoop aviao;

    // Start is called before the first frame update
    void Start()
    {
        this.aviao = this.GetComponent<ControlaAviaoCoop>();
        StartCoroutine(Impulsionar());
    }

    private IEnumerator Impulsionar()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            this.aviao.DarImpulso();
        }
    }
}
