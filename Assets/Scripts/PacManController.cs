using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManController : MonoBehaviour
{

    Rigidbody2D rb;

    

    Vector2 PosicionActual;
    Vector2 PosicionFinal;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;

    





    public GameObject Proyectil;
    public Transform Generador;

    public float fuerzaProyectil = 5f;

    public float retraso = 1f;
    float tiempoUltimoDisparo = -1f;


    bool enMovimiento = false;

    Quaternion quaternion;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        VectorDerecha = new Vector2(0.1f, 0);
        VectorIzquierda = -VectorDerecha;


        quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);


        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //---------------------------------COSAS DEL MOVIMIENTO

        PosicionActual = rb.position;
        



        //---------------------------------COSAS DEL DISPARO

        
        

    }


    //--------------------------------------------------------- COSAS DEL MOVIMIENTO

    public void MueveDerecha()
    {


        PosicionFinal = PosicionActual + VectorDerecha;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        quaternion = Quaternion.Euler(new Vector3(0f, 0f, -180f));
        transform.rotation = quaternion;

        Invoke("Falsear", 0.2f);
    }

    public void MueveIzquierda()
    {
        PosicionFinal = PosicionActual + VectorIzquierda;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        quaternion = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        transform.rotation = quaternion;

        Invoke("Falsear", 0.2f);

    }


    //--------------------------------------------------------- COSAS DEL DISPARO


    public void Disparar()
    {
        if ((!enMovimiento) && (Time.time >= tiempoUltimoDisparo + retraso))
        {
            
            tiempoUltimoDisparo = Time.time;
            quaternion = Quaternion.Euler(new Vector3(0f, 0f, -90f));
            transform.rotation = quaternion;
            Invoke("Bala", 0.2f);
        }
        

        
        
    }

    void Bala()
    {
        Instantiate(Proyectil, Generador.position, Quaternion.identity);
    }


    void Falsear()
    {
        enMovimiento = false;
    }

}
