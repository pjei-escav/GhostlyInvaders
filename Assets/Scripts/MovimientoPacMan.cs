using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPacMan : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animacion;
    SpriteRenderer sprite;

    Vector2 PosicionActual;
    Vector2 PosicionFinal;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;
    

    bool miraIzquierda = true;


    public GameObject Proyectil;
    public Transform Generador;

    public float fuerzaProyectil = 5f;


    bool enMovimiento = false;
    bool enDisparo = false;



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        VectorDerecha = new Vector2(0.1f, 0);
        VectorIzquierda = -VectorDerecha;
        animacion = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //---------------------------------COSAS DEL MOVIMIENTO

        PosicionActual = rb.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (!enDisparo))
        {
            MueveIzquierda();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (!enDisparo))
        {
            MueveDerecha();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            enMovimiento = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            enMovimiento = false;
        }

        //---------------------------------COSAS DEL DISPARO

        if (Input.GetKey(KeyCode.Space) && (!enMovimiento))
        {
            Disparar();

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Invoke("Retraso", 0.2f);
            
        }

    }


    //--------------------------------------------------------- COSAS DEL MOVIMIENTO

    void MueveDerecha()
    {
        PosicionFinal = PosicionActual + VectorDerecha;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        //if (miraIzquierda)
       // {
           // transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w);
            //miraIzquierda = false;
       // Debug.Log("rotation = " + transform.rotation);
        // }
    }

    void MueveIzquierda()
    {
        PosicionFinal = PosicionActual + VectorIzquierda;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        //if (!miraIzquierda)
        //{

           // transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w);
            //miraIzquierda = true;
       // Debug.Log("rotation = " + new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w));
        //}
    }


    //--------------------------------------------------------- COSAS DEL DISPARO


    void Disparar()
    {
        enDisparo = true;
        Invoke("Bala", 0.2f);
        animacion.SetBool("Disparando", true);
    }

    void Bala()
    {
        Instantiate(Proyectil, Generador.position, Quaternion.identity);
    }

    void Retraso()
    {
        animacion.SetBool("Disparando", false);
        enDisparo = false;
    }


}
