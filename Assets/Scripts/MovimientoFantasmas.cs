using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFantasmas : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 PosicionActual;
    Vector2 PosicionFinal;
    Vector2 PosicionFantasmas;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;
    Vector2 VectorAbajo;


    public GameObject ControladorFantasmas;



    bool moviendoDerecha = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        VectorDerecha = new Vector2(0.01f, 0f);
        VectorIzquierda = -VectorDerecha;
        VectorAbajo = new Vector2(0f, -0.2f);

        PosicionActual.y = rb.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PosicionFantasmas = ControladorFantasmas.transform.position;
        
        PosicionActual.x = rb.position.x;

        if (moviendoDerecha == true)
        {
            MovimientoDerecha();
        }
        else
        {
            MovimientoIzquierda();
        }
    }


    void MovimientoIzquierda()
    {
        PosicionFinal = PosicionActual + VectorIzquierda;
        rb.transform.position = PosicionFinal;
    }

    void MovimientoDerecha()
    {
        PosicionFinal = PosicionActual + VectorDerecha;
        rb.transform.position = PosicionFinal;
    }

    void MovimientoAbajo()
    {
        PosicionFinal = PosicionFantasmas + VectorAbajo;
        ControladorFantasmas.transform.position = PosicionFinal;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimiteIzquierda"))
        {
            

            moviendoDerecha = true;

            MovimientoAbajo();
            PosicionActual.y = PosicionActual.y + VectorAbajo.y;
        }
        if (collision.gameObject.CompareTag("LimiteDerecha"))
        {
            

            moviendoDerecha = false;

            MovimientoAbajo();
            PosicionActual.y = PosicionActual.y + VectorAbajo.y;
        }
    }

}
