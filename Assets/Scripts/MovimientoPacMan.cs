using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPacMan : MonoBehaviour
{

    Vector2 PosicionActual;
    Vector2 PosicionFinal;
    Rigidbody2D rb;

    Vector2 VectorDerecha;
    Vector2 VectorIzquierda;

    SpriteRenderer sprite;

    bool miraIzquierda = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        VectorDerecha = new Vector2(0.1f, 0);
        VectorIzquierda = -VectorDerecha;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PosicionActual = rb.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MueveIzquierda();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MueveDerecha();
        }
    }

    void MueveDerecha()
    {
        PosicionFinal = PosicionActual + VectorDerecha;
        rb.transform.position = PosicionFinal;

        if (miraIzquierda)
        {
            sprite.flipX=true;
            miraIzquierda = false;
        }
    }

    void MueveIzquierda()
    {
        PosicionFinal = PosicionActual + VectorIzquierda;
        rb.transform.position = PosicionFinal;

        if (!miraIzquierda)
        {
            sprite.flipX = false;
            miraIzquierda = true;
        }
    }


}
