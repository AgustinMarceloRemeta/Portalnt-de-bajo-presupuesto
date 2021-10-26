using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCajita : MonoBehaviour
{
    ControlJugador controlJugador;
    ControlJuego controljuego;
    public GameObject ubi;
    public GameObject ubi2;
    private plataforma Plataforma;
    public bool Rango = false;
   

    void Start()
    {
        controljuego = FindObjectOfType<ControlJuego>();
        controlJugador = FindObjectOfType<ControlJugador>();
        Plataforma = FindObjectOfType<plataforma>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boton"))
        {
            if (!controlJugador.agarra)
            {
                controlJugador.cancela = true;
                transform.position = ubi.transform.position;
                Rango = false;
                controljuego.puerta1 = true;

            }
        }
        if (other.CompareTag("boton2"))
            {
                if (!controlJugador.agarra)
                {
                    controlJugador.cancela2 = true;
                    transform.position = ubi2.transform.position;
                    Rango = false;
                    controljuego.puerta3 = true;

                }

            }
        if (other.CompareTag("plataforma") && !controlJugador.agarra)
        {
            Plataforma.arribaC = true;
        }
        if (other.CompareTag("lava"))
        {
            transform.position = new Vector3(33.07962f, 0.2500015f, 19.47201f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("plataforma"))
        {
            Plataforma.arribaC = false;
        }
    }
}
