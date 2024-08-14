
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform comienzoRayo; 

    public GameObject efectoCristal; 

    private Animator animator; 
    private Rigidbody rb; 

    private bool caminarDerecha = true; 

    private GameManager gameManager; 


    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>(); 
        gameManager = FindObjectOfType<GameManager>();        
    } 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        
        {
            CambiarDireccion();
        }

        RaycastHit contacto;


        //if (!Physics.Raycast(comienzoRayo.position, -transform.up, out contacto, Mathf.Infinity))
        if (transform.position.y < 0)
        {
            animator.SetTrigger("Cayendo");
        }
        if (transform.position.y < -3)
        
        {
            gameManager.FinalizarJuego();
            }
        }


        
        private void FixedUpdate()
    {
        if (!gameManager.juegoIniciado)
        {
            return; //no devuelve nada
        }
        else
        {
            animator.SetTrigger("ComienzoJuego");
      }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime; 
        }     

        
        private void CambiarDireccion()
    {
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        caminarDerecha = !caminarDerecha;
            if (caminarDerecha)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
            }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            }
        }

        
        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cristal")
        {
            Destroy(other.gameObject);
                gameManager.AumentarPuntuaje(); 
                
                GameObject g = Instantiate(efectoCristal, comienzoRayo.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        } 
        }  
 }

