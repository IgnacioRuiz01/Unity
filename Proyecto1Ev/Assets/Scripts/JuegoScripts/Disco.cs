using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public float velocidadGiro = 200f;
    Transform movimientoOriginal; // Movimiento inicial del jugador


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * velocidadGiro * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision) // Se ejecuta cuando se produce el contacto
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Almacena la transformada padre del jugador (movimiento original)
            movimientoOriginal = collision.transform.parent;
            // Establece este objeto como el nuevo padre del jugador
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit(Collision collision) // Se ejecuta cuando se deja de estar en contacto
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Restaura el padre original del jugador
            collision.transform.SetParent(movimientoOriginal);
        }
    }
}
