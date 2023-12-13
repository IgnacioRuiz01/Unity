using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lateral_Move : MonoBehaviour
{
    public float distanciaMovimiento = 5f; // Distancia total que la pared se mueve
    public float velocidadMovimiento = 2f; // Velocidad de movimiento de la pared

    private Vector3 posicionInicial;
    private bool moviendoseHaciaDerecha = true;

    void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(MoverPared());
    }

    IEnumerator MoverPared()
    {
        while (true)
        {
            // Mueve la pared hacia la derecha
            while (transform.position.x < posicionInicial.x + distanciaMovimiento)
            {
                transform.Translate(Vector3.right * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Cambia la dirección de movimiento
            moviendoseHaciaDerecha = !moviendoseHaciaDerecha;

            // Mueve la pared hacia la izquierda
            while (transform.position.x > posicionInicial.x)
            {
                transform.Translate(Vector3.left * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Cambia la dirección de movimiento
            moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
        }
    }
}
