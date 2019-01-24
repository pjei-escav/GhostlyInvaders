using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManComtroller : MonoBehaviour
{

    Rigidbody2D rb;

    

    Vector2 PosicionActual;
    Vector2 PosicionFinal;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;
    




    public GameObject Proyectil;
    public Transform Generador;

    public float fuerzaProyectil = 5f;

    public float retraso = 2f;
    public float tiempoUltimoDisparo = 0f;


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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MueveIzquierda();
            Invoke("Falsea", 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MueveDerecha();
            Invoke("Falsea", 0.1f);
        }

        

        //---------------------------------COSAS DEL DISPARO

        if (Input.GetKeyDown(KeyCode.A) && (!enMovimiento) && (tiempoUltimoDisparo + retraso >= Time.time))
        {
            tiempoUltimoDisparo = Time.time;
            Disparar();

        }
        

    }


    //--------------------------------------------------------- COSAS DEL MOVIMIENTO

    void MueveDerecha()
    {
        PosicionFinal = PosicionActual + VectorDerecha;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        quaternion = Quaternion.Euler(new Vector3(0f, 0f, -180f));
        transform.rotation = quaternion;
    }

    void MueveIzquierda()
    {
        PosicionFinal = PosicionActual + VectorIzquierda;
        rb.transform.position = PosicionFinal;
        enMovimiento = true;

        quaternion = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        transform.rotation = quaternion;


    }


    //--------------------------------------------------------- COSAS DEL DISPARO


    void Disparar()
    {

        quaternion = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        transform.rotation = quaternion;
        Invoke("Bala", 0.2f);
        Invoke("Verdadea", 0.01f);
        
        
    }

    void Bala()
    {
        Instantiate(Proyectil, Generador.position, Quaternion.identity);
    }

    //Sirve para hacer bucle     Haber estudiado
    void Falsea()
    {
        enMovimiento = false;
    }

    //Sirve para hacer bucle     Haber estudiado
    void Verdadea()
    {
        enMovimiento = true;
        Invoke("Falsea", 3f);
    }








}
