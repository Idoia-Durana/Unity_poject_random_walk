
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform comienzoRayo; //Variable que indica el punto de origen
                                   //del rayo de la  cámara, se usa para seguir con la
                                   //camara al personaje

    public GameObject efectoCristal; //Objeto de efecto de partículas que
                                     //se generará al recoger un cristal

    private Animator animator; //Referencia al componente Animator
    private Rigidbody rb; //referencia al componente Rigidbody 

    private bool caminarDerecha = true; //Un booleano que indica si el
                                        //personaje está caminando hacia la derecha

    private GameManager gameManager; // referencia a un objeto GameManager
                                     // que gestiona el estado del juego.


    //Método Awake en este caso se utiliza para inicializar las variables
    //rb, animator, y gameManager al comienzo de la ejecución del script.
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>(); 
        gameManager = FindObjectOfType<GameManager>();        
    } 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Comprueba si se presionó la tecla 'Espacio'
                                            //y llama al método CambiarDireccion() en respuesta.
        {
            CambiarDireccion();
        }

        RaycastHit contacto;


        //if (!Physics.Raycast(comienzoRayo.position, -transform.up, out contacto, Mathf.Infinity))
        if (transform.position.y < 0)
        {
            animator.SetTrigger("Cayendo");//Utiliza un raycast para verificar
                                           //si hay algo debajo del personaje.Si no hay nada,
                                           //activa una animación "cayendo".
        }
        if (transform.position.y < -3)
        
        {
            gameManager.FinalizarJuego();//Verifica si el personaje ha caído
                                         //por debajo de cierta altura y llama
                                         //al método FinalizarJuego() del gameManager
                                         //en caso afirmativo.
            }
        }
        //Método FixedUpdate se ejecuta en intervalos de tiempo fijos y se utiliza para realizar operaciones físicas.
        private void FixedUpdate()
    {
        if (!gameManager.juegoIniciado)
        {
            return; //no devuelve nada
        }
        else
        {
            animator.SetTrigger("ComienzoJuego");//Si el juego está iniciado, activa una animación de comienzo de juego que, en este caso,comienza a correr
            }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;//Actualiza la posición del objeto rb(Rigidbody)
                                                                                            //multiplicando la velocidad(transform.forward* 2)
                                                                                            //por el tiempo transcurrido desde el último fotograma(Time.deltaTime).
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
                gameManager.AumentarPuntuaje(); //aumenta el puntaje llamando al método AumentarPuntuaje() del gameManager
                                                //y genera un efecto de partículas en la posición del cristal destruido.
                GameObject g = Instantiate(efectoCristal, comienzoRayo.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        } 

        }

   
 }

