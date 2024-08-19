
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform comienzoRayo; //Variable que indica el punto de origen
                                   //del rayo de la  c�mara, se usa para seguir con la
                                   //camara al personaje

    public GameObject efectoCristal; //Objeto de efecto de part�culas que
                                     //se generar� al recoger un cristal

    private Animator animator; //Referencia al componente Animator
    private Rigidbody rb; //referencia al componente Rigidbody 

    private bool caminarDerecha = true; //Un booleano que indica si el
                                        //personaje est� caminando hacia la derecha

    private GameManager gameManager; // referencia a un objeto GameManager
                                     // que gestiona el estado del juego.


    //M�todo Awake en este caso se utiliza para inicializar las variables
    //rb, animator, y gameManager al comienzo de la ejecuci�n del script.
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>(); 
        gameManager = FindObjectOfType<GameManager>();        
    } 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Comprueba si se presion� la tecla 'Espacio'
                                            //y llama al m�todo CambiarDireccion() en respuesta.
        {
            CambiarDireccion();
        }

        RaycastHit contacto;


        //if (!Physics.Raycast(comienzoRayo.position, -transform.up, out contacto, Mathf.Infinity))
        if (transform.position.y < 0)
        {
            animator.SetTrigger("Cayendo");//Utiliza un raycast para verificar
                                           //si hay algo debajo del personaje.Si no hay nada,
                                           //activa una animaci�n "cayendo".
        }
        if (transform.position.y < -3)
        
        {
            gameManager.FinalizarJuego();//Verifica si el personaje ha ca�do
                                         //por debajo de cierta altura y llama
                                         //al m�todo FinalizarJuego() del gameManager
                                         //en caso afirmativo.
            }
        }
        //M�todo FixedUpdate se ejecuta en intervalos de tiempo fijos y se utiliza para realizar operaciones f�sicas.
        private void FixedUpdate()
    {
        if (!gameManager.juegoIniciado)
        {
            return; //no devuelve nada
        }
        else
        {
            animator.SetTrigger("ComienzoJuego");//Si el juego est� iniciado, activa una animaci�n de comienzo de juego que, en este caso,comienza a correr
            }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;//Actualiza la posici�n del objeto rb(Rigidbody)
                                                                                            //multiplicando la velocidad(transform.forward* 2)
                                                                                            //por el tiempo transcurrido desde el �ltimo fotograma(Time.deltaTime).
        }       
        private void CambiarDireccion()
    {
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        caminarDerecha = !caminarDerecha;//Invierte el valor de caminarDerecha.

            if (caminarDerecha)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);//Si caminarDerecha es verdadero, rota el objeto hacia la derecha;
            }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);//de lo contrario, lo rota hacia la izquierda.

            }
        }
        //OnTriggerEnter Se ejecuta cuando el objeto colisiona con otro objeto con un Collider adjunto.
        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cristal")
        {
            Destroy(other.gameObject);//Si el objeto con el que colisiona tiene la etiqueta "Cristal", destruye ese objeto,
                gameManager.AumentarPuntuaje(); //aumenta el puntaje llamando al m�todo AumentarPuntuaje() del gameManager
                                                //y genera un efecto de part�culas en la posici�n del cristal destruido.
                GameObject g = Instantiate(efectoCristal, comienzoRayo.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        } 

        }

   
 }

