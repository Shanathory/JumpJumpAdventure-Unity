using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class EnemiController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Animator animator;
    public LayerMask pared;
    private BoxCollider2D boxCollider;
    
    [Header("GameObjet")] //Esto es para separarlo visualmente en el inspector de Unity
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Transform enemigo;
    [Header("")]
    [SerializeField] private float velocidad;
    [Header("Distancias de collision")]
    [SerializeField] private float distanciaSuelo;
    [SerializeField] private float distanciaParedD;
    [SerializeField] private float distanciaParedI;
    [SerializeField] private bool moviendoDerecha;
    private int contTocaParedD = 0;
    private int contTocaParedI = 0;

    private  void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator.SetBool("isRunning", true);
    }
    
    private void FixedUpdate()
    {
        
        /*
         * Toma la posicion del controladorSuelo, y a partir de ese momoento, tira un rayo hacia abajo con una distancia
         * = distanciaSuelo.
         */
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distanciaSuelo);
        rigidbody.velocity = new Vector2(velocidad,rigidbody.velocity.y); // Velocidad del enemigo.

        if (informacionSuelo == false)
        {
            Girar();
            contTocaParedD = 0;
            contTocaParedI = 0;
        }
        
        else if ((TocaParedD() && contTocaParedD == 0))
        {
            contTocaParedD = 1;
            Girar();
            contTocaParedI = 0;
        }

        else if ((TocaParedI() && contTocaParedI == 0))
        {
            contTocaParedI = 1;
            Girar();
            contTocaParedD = 0;
        }


    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha; //Cambiamos el booleano.
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); // Giramos al personaje.
        velocidad *= -1;
    }
    bool TocaParedD()
    {
        /*
         * Es como un Raycast pero en vez de ser un rayo, es una caja.\
         * Physics2D.BoxCast(punto de origeren, tamanio de la caja, angulo en el que queremos que se emita la caja,
         * direccion, distancia de la caja, LayeerMask);
         */
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
                                            new Vector2(boxCollider.bounds.size.x, 
                                              boxCollider.bounds.size.y), 0f,
                                        Vector2.right, distanciaParedD, pared);
       
        /*
         * Si debuelve null, significa que no esta colisionando con nada, por lo tanto la variable bool EstaEnSuelo
         * devolvera falso.
         */
        return raycastHit.collider != null;
    }
    
    bool TocaParedI()
    {
        /*
         * Es como un Raycast pero en vez de ser un rayo, es una caja.\
         * Physics2D.BoxCast(punto de origeren, tamanio de la caja, angulo en el que queremos que se emita la caja,
         * direccion, distancia de la caja, LayeerMask);
         */
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
            new Vector2(boxCollider.bounds.size.x, 
                boxCollider.bounds.size.y), 0f,
            Vector2.left, distanciaParedI, pared);
       
        /*
         * Si debuelve null, significa que no esta colisionando con nada, por lo tanto la variable bool EstaEnSuelo
         * devolvera falso.
         */
        return raycastHit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distanciaSuelo);
        Gizmos.DrawLine(enemigo.transform.position, enemigo.transform.position + Vector3.left * distanciaParedI);
        Gizmos.DrawLine(enemigo.transform.position, enemigo.transform.position + Vector3.right * distanciaParedD);

    }
}
