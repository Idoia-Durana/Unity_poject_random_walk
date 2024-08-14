using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;
    public int puntuaje; 
    public Text textoPuntuaje; 
    public Text puntuajeMaximoTexto;

    
    private void Awake()
    {
        puntuajeMaximoTexto.text = "Mejor: " + ObtenerPuntuajeMaximo().ToString(); 
    }


    public void IniciarJuego()
    {
        juegoIniciado = true;
        FindObjectOfType<Ruta>().IniciarConstruccion();
    }

    public void FinalizarJuego()
    {
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntuaje()
    {
        puntuaje++;
        textoPuntuaje.text = puntuaje.ToString();
        

        if (puntuaje > ObtenerPuntuajeMaximo())
        {    
            PlayerPrefs.SetInt("PuntuajeMaximo",puntuaje);
            puntuajeMaximoTexto.text = "Mejor: " + puntuaje.ToString();
        }
    }

    public int ObtenerPuntuajeMaximo()
    {
        int i = PlayerPrefs.GetInt("PuntuajeMaximo");
        return i;
    }
}
