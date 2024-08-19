using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instancia;

    //Este método se ejecuta cuando se instancia el objeto que contiene este script.
   
   private void Awake()
    {
        if (instancia ==null)
        {
            instancia = this; //Comprueba si ya existe una instancia de MusicaFondo.Si no hay ninguna instancia,
                              //establece la instancia actual como la única instancia (instancia = this).
        }
        else if (instancia != this)
        {
            Destroy(gameObject);//Si ya hay una instancia, pero no es la misma que la actual(instancia != this),
                                //destruye el objeto actual para evitar la creación de múltiples
                                //instancias de la música de fondo.

        }

        DontDestroyOnLoad(gameObject);//Llama a DontDestroyOnLoad(gameObject) para evitar que el objeto
                                      //(y, por lo tanto,la música de fondo)
                                      //se destruya al cargar una nueva escena.Esto asegura que
                                      //la música de fondo persista durante todo el juego.

    }
}
