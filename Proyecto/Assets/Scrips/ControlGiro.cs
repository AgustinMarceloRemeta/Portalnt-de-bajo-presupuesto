using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGiro : MonoBehaviour
{
    public Transform capsulaarriba;
    private bool puedegirar= true;
    private int cual = 1;
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public MeshRenderer Rayo;
    public bool tadentro, Paso= false;
    private ControlJuego Controljuego;
    public GameObject fiumba;
    // Start is called before the first frame update
    void Start()
    {
        Controljuego = FindObjectOfType<ControlJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedegirar)
        {
            Rayo.enabled = false;
            capsulaarriba.Rotate(0f, 1f, 0);
        }
        if (Physics.Raycast(capsulaarriba.position, capsulaarriba.forward, out RaycastHit Hit))
        {
            if (Hit.collider.gameObject.CompareTag("stop"))
            {
                puedegirar = false;
                Rayo.enabled = true;
                
            }
            else if (Hit.collider.gameObject.CompareTag("Llego"))
            {
                puedegirar = false;
                Rayo.enabled = true;
                if(!Paso) Controljuego.puerta2 = true;                
                Rayo.transform.localScale = new Vector3(0.1f,0.1f,4f);
                Rayo.transform.position = new Vector3(2.279673f, 1.4331f, -15.73752f); 
            }
        }
        else puedegirar = true;
        if(tadentro)
        if(Input.GetKeyDown(KeyCode.E))
            switch (cual)
            {
                case 1:
                    {
                        Destroy(objeto1);
                        cual++;
                        puedegirar = true;
                            Instantiate(fiumba, transform, transform);
                        }
                    break;
                case 2:
                    {
                        Destroy(objeto2);
                        cual++;
                        puedegirar = true;
                            Instantiate(fiumba, transform, transform);
                        }
                    break;
                case 3:
                    {
                        Destroy(objeto3);
                        cual++;
                        puedegirar = true;
                            Instantiate(fiumba, transform, transform);
                        }
                        break;
                default:
                    break;
            }
    }
}
