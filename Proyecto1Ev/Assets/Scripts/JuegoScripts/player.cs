using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public float velocidad = 10;
    public float fuerzaSalto = 5f;
    public bool haSaltado = false;
    float xInput;
    float zInput;
    private Rigidbody playerRB;
    private int vidas = 3;
    public Text contadorVidas;
    public GameObject grupoDerrota;
    public GameObject grupoVictoria;
    Vector3 posicionInicial;

    private AudioSource audioSource; // Agregado para el sonido de colisión
    public AudioClip sonidoColision; // Asigna el sonido desde el Inspector

    private AudioSource audioSourceVictoria;
    public AudioClip victoria;






    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

        audioSource = GetComponent<AudioSource>(); // Agregado para el sonido de colisión
        audioSource.clip = sonidoColision; // Agregado para el sonido de colisión

        audioSourceVictoria = GetComponent<AudioSource>();
        audioSourceVictoria.clip = victoria;


    }

    // Update is called once per frame
    void Update()
    {
        // Toma de inputs 

        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && haSaltado == false)
        {
            playerRB.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            haSaltado = true;

            
                audioSource.PlayOneShot(sonidoColision);
            
        }

        if(vidas <= 0)
        {
            Time.timeScale = 0;

            grupoDerrota.SetActive(true);


        }
    }

    private void FixedUpdate()
    {

        Vector3 movimiento = new Vector3(xInput, 0f, zInput);
        transform.Translate(movimiento * velocidad * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision collision)
    {
        haSaltado = false;
        if (collision.gameObject.CompareTag("Respawn"))
        {
            vidas--;
            playerRB.MovePosition(posicionInicial);
            contadorVidas.text = "Vidas: " + vidas;
        }

        if (collision.gameObject.CompareTag("Killer"))
        {

            Debug.Log("Has muerto ");
            transform.position = posicionInicial;
            vidas--;
            contadorVidas.text = "Vidas: " + vidas;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            posicionInicial = transform.position;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0;

            grupoVictoria.SetActive(true);

            audioSourceVictoria.PlayOneShot(victoria);
        }
    }

  
   
}

