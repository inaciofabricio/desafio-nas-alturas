using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeclaPrecionada : MonoBehaviour
{
    [SerializeField]
    private KeyCode tecla;
    [SerializeField]
    private UnityEvent aoPrecionarTecla;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(this.tecla))
        {
            this.aoPrecionarTecla.Invoke();
        }
    }
}
