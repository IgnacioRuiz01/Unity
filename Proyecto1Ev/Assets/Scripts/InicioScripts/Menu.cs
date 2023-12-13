using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public void comenzar(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }



   public void salir()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
}
