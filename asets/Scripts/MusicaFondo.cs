using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instancia;
   
   private void Awake()
    {
        if (instancia ==null)
        {
            instancia = this; 
            
        }
        else if (instancia != this)
        {
            Destroy(gameObject);

        }

        DontDestroyOnLoad(gameObject);

    }
}
