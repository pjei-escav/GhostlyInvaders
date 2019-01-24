using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFantasmas : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 PosicionActual;
    Vector2 PosicionFinal;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;
    Vector2 VectorAbajo;

    bool moviendoDerecha = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        VectorDerecha = new Vector2(0.1f, 0f);
        VectorIzquierda = -VectorDerecha;
        VectorAbajo = new Vector2(0f, -1f);

        
    }

    // Update is called once per frame
    void Update()
    {
        PosicionActual = rb.position;

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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimiteIzquierda"))
        {
            

            moviendoDerecha = true;

            PosicionFinal = PosicionActual + VectorAbajo;
            rb.transform.position = PosicionFinal;

            Debug.Log(PosicionFinal.y);

        }
        if (collision.gameObject.CompareTag("LimiteDerecha"))
        {
            

            moviendoDerecha = false;

            PosicionFinal = PosicionActual + VectorAbajo;
            rb.transform.position = PosicionFinal;
        }
    }

}
