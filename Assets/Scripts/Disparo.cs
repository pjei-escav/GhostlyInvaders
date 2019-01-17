using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public float fuerza = 5f;

    public GameObject Proyectil;
    public  Transform Generador;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Instantiate(Proyectil, Generador.position, Quaternion.identity);
        
    }


}
