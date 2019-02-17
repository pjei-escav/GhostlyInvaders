using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCruceta : MonoBehaviour
{

    Image imagenCruzeta;
    public Sprite CruzetaNormal;
    public Sprite CruzetaDerecha;
    public Sprite CruzetaIzquierda;
    public Sprite CruzetaArriba;
    public Sprite CruzetaAbajo;

    // Start is called before the first frame update
    void Start()
    {
        imagenCruzeta = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MueveDerecha()
    {
        imagenCruzeta.sprite = CruzetaDerecha;
        Invoke("CruzetaBase", 0.25f);
    }

    public void MueveIzquierda()
    {
        imagenCruzeta.sprite = CruzetaIzquierda;
        Invoke("CruzetaBase", 0.25f);
    }

    public void MueveArriba()
    {
        imagenCruzeta.sprite = CruzetaArriba;
        Invoke("CruzetaBase", 0.25f);
    }

    public void MueveAbajo()
    {
        imagenCruzeta.sprite = CruzetaAbajo;
        Invoke("CruzetaBase", 0.25f);
    }

    void CruzetaBase()
    {
        imagenCruzeta.sprite = CruzetaNormal;
    }


}
