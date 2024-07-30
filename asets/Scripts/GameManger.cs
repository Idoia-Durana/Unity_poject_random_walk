using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;// variable que marca si el juego está iniciado o no
    public int puntuaje; //Esta variable va a almacenar un valor en el método AumentarPuntuaje autoincrementandose (puntuaje++)
    public Text textoPuntuaje; // variable que mostrará el puntaje actual en la interfaz del usuario.
    public Text puntuajeMaximoTexto;//variable de texto que mostrará el puntaje máximo alcanzado en la interfaz del usuario.

    private void Awake()//Awake Se utiliza para inicializar variables antes de que comience la ejecución del juego.
    {
        puntuajeMaximoTexto.text = "Mejor: " + ObtenerPuntuajeMaximo().ToString(); //Establece el texto del puntaje máximo
                                                                                   //(puntuajeMaximoTexto) con el valor recuperado
                                                                                   //de ObtenerPuntuajeMaximo().
    }

    public void IniciarJuego()
    {
        juegoIniciado = true;//Establece juegoIniciado como verdadero.
        FindObjectOfType<Ruta>().IniciarConstruccion();//llama al método IniciarConstruccion() del objeto Ruta,
                                                       //que es el responsable de iniciar la construcción de la ruta en el juego.
    }

    public void FinalizarJuego()
    {
        //Este método es llamado por la clase ControlPersonaje(Update)
        //Dentro de el método FinalizarJuego llamamos a un sceneManager.LoadScene que se u utiliza para cargar el numero de
        //índice de una escena,al tener una sola escena usamos el 0, se carga en los built setting y se indexa con ese numero
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntuaje()
    {
        puntuaje++;//Incrementa el puntaje (puntuaje++).
        textoPuntuaje.text = puntuaje.ToString();
        //Actualiza el texto del puntaje(textoPuntuaje.text) con el valor actualizado del puntaje.

        if (puntuaje > ObtenerPuntuajeMaximo())//Verifica si el puntaje actual es mayor que el puntaje máximo almacenado.Si es así:
        {    
            PlayerPrefs.SetInt("PuntuajeMaximo",puntuaje);//Almacena el nuevo puntaje máximo en PlayerPrefs con la clave "PuntuajeMaximo".
            puntuajeMaximoTexto.text = "Mejor: " + puntuaje.ToString();//Actualiza el texto del puntaje máximo (puntuajeMaximoTexto.text)
                                                                       //con el nuevo valor del puntaje máximo.
        }
    }

    //El método ObtenerPuntuajeMaximo Recupera el puntaje máximo almacenado en PlayerPrefs con la clave "PuntuajeMaximo" y lo devuelve.
    public int ObtenerPuntuajeMaximo()
    {
        int i = PlayerPrefs.GetInt("PuntuajeMaximo");
        return i;
    }
}
