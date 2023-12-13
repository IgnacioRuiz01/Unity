using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public float fuerzaLanzamiento = 20f;
    public float velocidad = 5f;
    
    float zInput;
    private Rigidbody bola;
    Vector3 posicionInicial;

    public float tiempoParaReiniciar = 10f;
    private bool juegoReiniciado = false;


    // Start is called before the first frame update
    void Start()
    {
        bola = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Toma de inputs 

        
        zInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarBola();
        }
        if (!juegoReiniciado && Time.timeSinceLevelLoad > tiempoParaReiniciar)
        {
            ReiniciarJuego();
        }
    }

    private void FixedUpdate()
    {
        // Fisicas
        Vector3 input = new Vector3(0f, 0f, zInput);
        bola.AddForce(input * velocidad);




    }

    void LanzarBola()
    {
        if (bola != null)
        {
            bola.AddForce(transform.forward * fuerzaLanzamiento * 5, ForceMode.Impulse);
        } else
        {
            Debug.Log("No se encontro un rigidbody adjunto a ese objeto");
        }
    }

    void ReiniciarJuego()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        juegoReiniciado = true;
    }
}