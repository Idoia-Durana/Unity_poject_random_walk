using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; 
    private Vector3 diferencia; //variable tridimensional que almacenará la diferencia entre la posición de
                                //la cámara y la posición del objetivo

    //Metodo Awake Se utiliza para inicializar variables u objetos antes de que comience la ejecución del juego.
    //Calcula la diferencia entre la posición inicial de la cámara y la posición del objetivo.Esta diferencia
    //se calcula restando la posición del objetivo(objetivo.position) de la posición de la cámara(transform.position).
    void Awake()
    {
        //diferencia = posición cámara – posición jugador
        diferencia = transform.position - objetivo.position;
    }    
    private void LateUpdate()
    {
        //la position de la camara va a ser igual a
        //la posición del personaje + diferencia,
        //si no añadiésemos la diferencia la cámara se encontraría dentro del personaje
        transform.position = objetivo.position + diferencia;
    }
}
