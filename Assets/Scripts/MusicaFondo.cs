using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instancia;

    //Este m�todo se ejecuta cuando se instancia el objeto que contiene este script.
   
   private void Awake()
    {
        if (instancia ==null)
        {
            instancia = this; //Comprueba si ya existe una instancia de MusicaFondo.Si no hay ninguna instancia,
                              //establece la instancia actual como la �nica instancia (instancia = this).
        }
        else if (instancia != this)
        {
            Destroy(gameObject);//Si ya hay una instancia, pero no es la misma que la actual(instancia != this),
                                //destruye el objeto actual para evitar la creaci�n de m�ltiples
                                //instancias de la m�sica de fondo.

        }

        DontDestroyOnLoad(gameObject);//Llama a DontDestroyOnLoad(gameObject) para evitar que el objeto
                                      //(y, por lo tanto,la m�sica de fondo)
                                      //se destruya al cargar una nueva escena.Esto asegura que
                                      //la m�sica de fondo persista durante todo el juego.

    }
}
