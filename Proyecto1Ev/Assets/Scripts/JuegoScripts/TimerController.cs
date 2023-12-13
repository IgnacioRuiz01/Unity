using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;

    private int tiempoMinutos, tiempoSegundos, tiempoDecimasSegundos;
    
    void cronometro()
    {
        tiempo += Time.deltaTime;

        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimasSegundos = Mathf.FloorToInt((tiempo % 1)* 100);

        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundos);

    }

    // Update is called once per frame
    void Update()
    {
        cronometro();
    }
}
