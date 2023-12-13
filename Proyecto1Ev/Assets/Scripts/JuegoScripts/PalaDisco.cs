using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaDisco : MonoBehaviour
{
    public float velocidadGiro = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * velocidadGiro * Time.deltaTime);

    }
}
