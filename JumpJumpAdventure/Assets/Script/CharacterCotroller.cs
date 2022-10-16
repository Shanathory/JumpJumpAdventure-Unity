using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCotroller : MonoBehaviour
{
    private new Rigidbody2D rigidbody;//Instansiamos la variable rigidbody.
    private BoxCollider2D boxCollider;
    private Animator animator;
    
    public LayerMask capaSuelo;
    private bool mirandoDerecha = true;
    public float velocidadMovimiento;
    public float distanciaDelSuelo;
    public float fuerzaSalto;
    public int saltosMaximos;
    private int saltosRestantes;
    
    // Start is called before the first frame update
    void Start()
    {
        /* obtenemos el componente que tiene
         * el objeto, que es el Rigidbody2D.
         */
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
        saltosRestantes = saltosMaximos; //Indicamos que al comienzo del juego, el jugador tiene el maximo de saltos
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
        
        //Para visualizar la distancia del suelo, dibujamos un rayo azul hacia el suelo.
        //Debug.DrawRay(this.transform.position, Vector2.down * distanciaDelSuelo, Color.blue);
    }

    bool EstaEnSuelo()
    {
        /*
         * Es como un Raycast pero en vez de ser un rayo, es una caja.\
         * Physics2D.BoxCast(punto de origeren, tamanio de la caja, angulo en el que queremos que se emita la caja,
         * direccion, distancia de la caja, LayeerMask);
         */
       RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
                                    new Vector2(boxCollider.bounds.size.x/2, 
                                                    boxCollider.bounds.size.y/2 ), 0f,
                                    Vector2.down, distanciaDelSuelo, capaSuelo);
       
       /*
        * Si debuelve null, significa que no esta colisionando con nada, por lo tanto la variable bool EstaEnSuelo
        * devolvera falso.
        */
       return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if (EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }
        
        if (Input.GetButtonDown("Jump") && saltosRestantes > 0)
        {
            saltosRestantes -= 1;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    void ProcesarMovimiento()
    {
        /*
         * Los GetAxis son funciones dentro del InputManager y funcionan con un valo rpositivo (1) y el
         * mismo valor, pero negativo (-1). En caso de este input funciona con las flechitas.
         * Lo utilizaremos para poder mover la personaje.
         */
        float inputMovimiento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(inputMovimiento * velocidadMovimiento, rigidbody.velocity.y); //Mueve al personaje en el eje X.
        
        GestionarOrientacion(inputMovimiento);

        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if ( (mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0) )
        {
            mirandoDerecha = !mirandoDerecha; //Si es true lo coloca a false y si es false lo cambia a true.
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y); //Rota al personaje 180
        }
    }
}
