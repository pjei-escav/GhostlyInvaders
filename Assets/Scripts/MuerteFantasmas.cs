using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteFantasmas : MonoBehaviour
{

    Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
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
            Invoke("Muerte", 1);
        }
    }


    void Muerte()
    {
        Destroy(gameObject);
    }

}
