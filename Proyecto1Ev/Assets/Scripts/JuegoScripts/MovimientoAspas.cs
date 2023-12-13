using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAspas : MonoBehaviour
{
    public float velocidadGiro = 200f;
    private bool girarEnSentidoHorario = true;

    void Start()
    {
        // Inicia la coroutine para cambiar la dirección cada cierto tiempo
        StartCoroutine(CambiarDireccionGiro());
    }

    void Update()
    {
        // Gira las aspas en la dirección actual
        if (girarEnSentidoHorario)
        {
            transform.Rotate(Vector3.up * velocidadGiro * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.down * velocidadGiro * Time.deltaTime);
        }
    }

    IEnumerator CambiarDireccionGiro()
    {
        while (true)
        {
            // Espera 3 segundos
            yield return new WaitForSeconds(3f);

            // Cambia la dirección de giro
            girarEnSentidoHorario = !girarEnSentidoHorario;
        }
    }

}
