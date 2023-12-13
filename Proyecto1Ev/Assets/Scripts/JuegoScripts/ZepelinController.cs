using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZepelinController : MonoBehaviour
{
    [SerializeField] private GameObject prefabObjeto; // Asigna el prefab desde el Inspector
    public float tiempoEspera = 5f;
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del objeto


    // Start is called before the first frame update
    void Start()
    {

        // Iniciar la corrutina para gestionar la instanciación y desaparición del zepelín
        StartCoroutine(GenerarZepelin());
    }

    private IEnumerator GenerarZepelin()
    {
        while (true)
        {
            // Instancia un nuevo objeto y obtiene una referencia a él
            GameObject nuevoObjeto = Instantiate(prefabObjeto, transform.position, Quaternion.identity);

            // Ajusta la rotación del nuevo objeto para que aparezca correctamente
            nuevoObjeto.transform.rotation = Quaternion.Euler(0f, -90f, 90f);

            // Obtiene el componente Rigidbody del objeto
            Rigidbody rb = nuevoObjeto.GetComponent<Rigidbody>();

            // Si hay un Rigidbody, aplica movimiento hacia adelante
            if (rb != null)
            {
                rb.velocity = -Vector3.right * velocidadMovimiento;
            }

            // Espera 5 segundos antes de destruir el objeto actual
            yield return new WaitForSeconds(tiempoEspera);

            // Destruye el objeto actual
            Destroy(nuevoObjeto);
        }
    }

}
