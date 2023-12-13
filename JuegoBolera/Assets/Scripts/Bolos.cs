using UnityEngine;

public class BoloController : MonoBehaviour
{
    private Rigidbody rb;
    private bool derribado = false; // Indica si el bolo ha sido derribado.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Detecta colisiones con la bola.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola") && !derribado)
        {
            DerribarBolo();
        }
    }

    void DerribarBolo()
    {
        derribado = true;

        // Desactiva la gravedad y hace que el bolo sea kinem�tico para que no se mueva m�s.
        rb.useGravity = false;
        rb.isKinematic = true;

        // Puedes aplicar otras acciones aqu�, como reproducir una animaci�n o sonido de derribo.

        // Notifica al GameManager (si tienes uno) que un bolo ha sido derribado.
        // GameManager.Instance.BoloDerribado();
    }
}