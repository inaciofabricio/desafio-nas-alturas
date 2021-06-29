using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void JogarDeUmJogador()
    {
        StartCoroutine(MudarCena("game"));
    }
    
    public void JogarDeDoisJogadores()
    {
        StartCoroutine(MudarCena("gameCoop"));
    }

    IEnumerator MudarCena(string name)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(name);
    }
}
