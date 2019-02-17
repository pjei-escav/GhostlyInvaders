using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDisparo : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Limites"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fantasma"))
        {
            Destroy(gameObject);
        }
    }






}
