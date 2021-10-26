using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public bool puerta1 = false;
    public bool puerta2 = false;
    public bool puerta3 = false;
    public GameObject puer1, puer2, puer3, Jugador;
    public GameObject Sonido1, sonido2, sonido3, sonido4;
    public ControlGiro controlGiro;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(Sonido1, Jugador.transform);
        controlGiro = FindObjectOfType<ControlGiro>();
    }

    // Update is called once per frame
    void Update()
    {
        abrirpuerta();
    }
    void abrirpuerta()
    {
        if (puerta1) 
        {
            Destroy(puer1);
            Instantiate(sonido2,Jugador.transform);
            puerta1 = false;
        }
     if (puerta2)
        {
            Destroy(puer2);
            Instantiate(sonido3, Jugador.transform);
            puerta2 = false;
            controlGiro.Paso = true;
            
        }
        if (puerta3)
        {
            Destroy(puer3);
            Instantiate(sonido4, Jugador.transform);
            puerta3 = false;
        }
    }
}
