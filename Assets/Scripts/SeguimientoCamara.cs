using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; 
    private Vector3 diferencia; //variable tridimensional que almacenar� la diferencia entre la posici�n de
                                //la c�mara y la posici�n del objetivo

    //Metodo Awake Se utiliza para inicializar variables u objetos antes de que comience la ejecuci�n del juego.
    //Calcula la diferencia entre la posici�n inicial de la c�mara y la posici�n del objetivo.Esta diferencia
    //se calcula restando la posici�n del objetivo(objetivo.position) de la posici�n de la c�mara(transform.position).
    void Awake()
    {
        //diferencia = posici�n c�mara � posici�n jugador
        diferencia = transform.position - objetivo.position;
    }    
    private void LateUpdate()
    {
        //la position de la camara va a ser igual a
        //la posici�n del personaje + diferencia,
        //si no a�adi�semos la diferencia la c�mara se encontrar�a dentro del personaje
        transform.position = objetivo.position + diferencia;
    }
}
