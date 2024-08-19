using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public GameObject prefabRuta;// Un GameObject que servir� como la plantilla para crear partes de la ruta
    public Vector3 ultimaPosicion; // La �ltima posici�n en la que se cre� una parte de la ruta
    public float diferencia = 0.7f; //La diferencia en las coordenadas x y z entre las partes de la ruta
    private int cuentaRuta = 0; //Un contador que lleva la cuenta del n�mero de partes de la ruta creadas
    //IniciarConstruccion Invoca repetidamente el m�todo CrearNuevaParteRuta() cada 5 seg, comenzando despu�s de 1 seg
    public void IniciarConstruccion()
    {
        InvokeRepeating("CrearNuevaParteRuta", 1f, 0.5f);
    }   
    public void CrearNuevaParteRuta()
    {
        print("Crear parte ruta nueva");

        Vector3 nuevaPosicion = Vector3.zero;
        float opcion = Random.Range(0, 100);//Genera una posici�n para la nueva parte de la ruta de manera aleatoria

        if (opcion < 50)
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x +
                diferencia, ultimaPosicion.y, ultimaPosicion.z 
                + diferencia);//Si un n�mero aleatorio es menor que 50,
                              //la nueva posici�n se crea desplazando la �ltima posici�n en
                              //las coordenadas x y z positivas
        }
        else
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x - 
                diferencia, ultimaPosicion.y, ultimaPosicion.z 
                + diferencia);//Si el n�mero aleatorio es mayor o igual a 50,
                              //la nueva posici�n se crea desplazando la �ltima posici�n en
                              //las coordenadas x negativas y z positivas

        }
        GameObject g = Instantiate(prefabRuta, nuevaPosicion, Quaternion.Euler(0, 45, 0)); //Instancia un nuevo objeto prefabRuta
                                                                                           //en la nueva posici�n con una rotaci�n
                                                                                           //de 45 grados alrededor del eje Y

        ultimaPosicion = g.transform.position;//Actualiza la variable ultimaPosicion con la posici�n del nuevo objeto.

        cuentaRuta++; //Incrementa el contador cuentaRuta.
        if (cuentaRuta % 5 == 0) //Si el contador es divisible por 5, activa el primer hijo del objeto creado
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    //Verifica si se presion� la tecla Espacio y, en ese caso, llama al m�todo CrearNuevaParteRuta()
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CrearNuevaParteRuta();
        }
    }
}
