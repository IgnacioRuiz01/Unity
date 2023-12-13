using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool pausa =false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausa == false)
            {
                menuPausa.SetActive(true);
                pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }else if (pausa == true)
            {
                reanudar();
            }
        }
    }


    public void reanudar()
    {
        menuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        

    }

    public void irMenuPrincipal(string nombreMenu)
    {
        SceneManager.LoadScene(nombreMenu);
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Se cerro el juego");
    }
}
