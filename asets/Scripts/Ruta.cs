using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public GameObject prefabRuta;
    public Vector3 ultimaPosicion; 
    public float diferencia = 0.7f; 
    private int cuentaRuta = 0; 

    
    public void IniciarConstruccion()
    {
        InvokeRepeating("CrearNuevaParteRuta", 1f, 0.5f);
    }   
    public void CrearNuevaParteRuta()
    {
        print("Crear parte ruta nueva");

        Vector3 nuevaPosicion = Vector3.zero;
        float opcion = Random.Range(0, 100);

        if (opcion < 50)
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x +
                diferencia, ultimaPosicion.y, ultimaPosicion.z 
                + diferencia);
        }
        else
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x - 
                diferencia, ultimaPosicion.y, ultimaPosicion.z 
                + diferencia);

        }
        GameObject g = Instantiate(prefabRuta, nuevaPosicion, Quaternion.Euler(0, 45, 0)); 

        ultimaPosicion = g.transform.position;

        cuentaRuta++; //Incrementa el contador cuentaRuta.
        if (cuentaRuta % 5 == 0) 
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CrearNuevaParteRuta();
        }
    }
}
