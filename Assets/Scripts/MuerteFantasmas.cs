using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteFantasmas : MonoBehaviour
{

    Animator animacion;
    Collider2D col;


    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DisparoPacMan"))
        {
            animacion.SetBool("muerto", true);
            Destroy(col);
        }
    }


   
}
