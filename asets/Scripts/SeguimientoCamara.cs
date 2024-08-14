using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; 
    private Vector3 diferencia; 

    
    void Awake()
    {
        //diferencia = posición cámara – posición jugador
        diferencia = transform.position - objetivo.position;
    }    
    private void LateUpdate()
    {
        transform.position = objetivo.position + diferencia;
    }
}
