using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public GameObject bola;
    Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position - bola.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bola.transform.position + distancia;
    }
}
