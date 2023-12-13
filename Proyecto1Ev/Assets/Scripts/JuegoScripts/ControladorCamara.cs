using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{

    public GameObject jugador;
    public float sensibilidadRaton = 2f; // Ajusta la sensibilidad del rat�n seg�n tus preferencias
    Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position- jugador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadRaton;

        // Aplica la rotaci�n al jugador y a la c�mara solo en el eje Y
        jugador.transform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.up * mouseX); // Solo rota lateralmente
    }


    private void LateUpdate()
    {

        Vector3 nuevaPosicion = new Vector3(
        jugador.transform.position.x + distancia.x,
        transform.position.y, // Mantener la posici�n actual en el eje Y
        jugador.transform.position.z + distancia.z);

        transform.position = nuevaPosicion;
    }
}
