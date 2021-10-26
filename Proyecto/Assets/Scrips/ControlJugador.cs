using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public GameObject CubitoPosicion;
    public GameObject Cubito;
    public GameObject cubito2;
    private plataforma Plataforma;
    public bool agarra = false;
    private ControlCajita controlCajita;
    public bool cancela = false;
    public int cubitoAgarrado = 0;
    public bool cancela2 = false;
    private ControlGiro controlgiro;
    private ControlJuego Controljuego;
    void Start()
    {
        Plataforma = FindObjectOfType<plataforma>();
        controlCajita = FindObjectOfType<ControlCajita>();
        controlgiro = FindObjectOfType<ControlGiro>();
        Controljuego = FindObjectOfType<ControlJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlCajita.Rango) AgarrarCubito();
    }

    void AgarrarCubito()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!agarra) agarra = true;
            else agarra = false;
        }
        if (agarra)
        {
            switch (cubitoAgarrado)
            {
                case 1: Cubito.transform.position = CubitoPosicion.transform.position;
                    break;
                case 2: cubito2.transform.position = CubitoPosicion.transform.position;
                    break;
                default:
                    break;
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("cubito")&& !cancela)
        {
            controlCajita.Rango = true;
            cubitoAgarrado = 1;
        }
        if (other.CompareTag("cubito2") && !cancela2)
        {
            controlCajita.Rango = true;
            cubitoAgarrado = 2;
        }
        if (other.CompareTag("plataforma"))
        {
            Plataforma.arribaP = true;
        }
        if (other.CompareTag("lava"))
        {
            transform.position = new Vector3(41.17f, 1.57f, 6.11f);
        }
        if(other.CompareTag("Torreta"))
        {
            controlgiro.tadentro= true;
        }
        if(other.CompareTag("Final"))
        {
            Invoke("quitarapp", 10f) ;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cubito"))
        {
            controlCajita.Rango = false;
        }
        if (other.CompareTag("plataforma"))
        {
            Plataforma.arribaP = false;
        }
        if(other.CompareTag("Torreta"))
        {
            controlgiro.tadentro = false;
        }
    }
    public void quitarapp() 
    {
        Application.Quit();
        Debug.Log("chau");
    }
}