using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    public bool arribaP = false;
    public bool arribaC = false;
    public Transform padre;
    public Transform Jugador;
    public Transform Cubo;
    ControlJugador controljugador;

    // Start is called before the first frame update
    void Start()
    {
        controljugador = FindObjectOfType<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arribaP) Jugador.SetParent(padre);
        else Jugador.parent = null;
        if (arribaC && !controljugador.agarra) Cubo.SetParent(padre);
        else Cubo.parent = null;
        if(controljugador.agarra) Cubo.parent = null;
    }
    
}
