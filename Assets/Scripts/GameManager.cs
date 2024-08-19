using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;// variable que marca si el juego est� iniciado o no
    public int puntuaje; //Esta variable va a almacenar un valor en el m�todo AumentarPuntuaje autoincrementandose (puntuaje++)
    public Text textoPuntuaje; // variable que mostrar� el puntaje actual en la interfaz del usuario.
    public Text puntuajeMaximoTexto;//variable de texto que mostrar� el puntaje m�ximo alcanzado en la interfaz del usuario.

    private void Awake()//Awake Se utiliza para inicializar variables antes de que comience la ejecuci�n del juego.
    {
        puntuajeMaximoTexto.text = "Mejor: " + ObtenerPuntuajeMaximo().ToString(); //Establece el texto del puntaje m�ximo
                                                                                   //(puntuajeMaximoTexto) con el valor recuperado
                                                                                   //de ObtenerPuntuajeMaximo().
    }

    public void IniciarJuego()
    {
        juegoIniciado = true;//Establece juegoIniciado como verdadero.
        FindObjectOfType<Ruta>().IniciarConstruccion();//llama al m�todo IniciarConstruccion() del objeto Ruta,
                                                       //que es el responsable de iniciar la construcci�n de la ruta en el juego.
    }

    public void FinalizarJuego()
    {
        //Este m�todo es llamado por la clase ControlPersonaje(Update)
        //Dentro de el m�todo FinalizarJuego llamamos a un sceneManager.LoadScene que se u utiliza para cargar el numero de
        //�ndice de una escena,al tener una sola escena usamos el 0, se carga en los built setting y se indexa con ese numero
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntuaje()
    {
        puntuaje++;//Incrementa el puntaje (puntuaje++).
        textoPuntuaje.text = puntuaje.ToString();
        //Actualiza el texto del puntaje(textoPuntuaje.text) con el valor actualizado del puntaje.

        if (puntuaje > ObtenerPuntuajeMaximo())//Verifica si el puntaje actual es mayor que el puntaje m�ximo almacenado.Si es as�:
        {    
            PlayerPrefs.SetInt("PuntuajeMaximo",puntuaje);//Almacena el nuevo puntaje m�ximo en PlayerPrefs con la clave "PuntuajeMaximo".
            puntuajeMaximoTexto.text = "Mejor: " + puntuaje.ToString();//Actualiza el texto del puntaje m�ximo (puntuajeMaximoTexto.text)
                                                                       //con el nuevo valor del puntaje m�ximo.
        }
    }

    //El m�todo ObtenerPuntuajeMaximo Recupera el puntaje m�ximo almacenado en PlayerPrefs con la clave "PuntuajeMaximo" y lo devuelve.
    public int ObtenerPuntuajeMaximo()
    {
        int i = PlayerPrefs.GetInt("PuntuajeMaximo");
        return i;
    }
}