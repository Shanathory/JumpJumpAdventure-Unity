using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCotroller : MonoBehaviour
{
    private new Rigidbody2D rigidbody;//Instansiamos la variable rigidbody.
    public float velocidadMovimiento;
    private bool mirandoDerecha = true;
    public float fuerzaSalto;
    
    // Start is called before the first frame update
    void Start()
    {
        /* obtenemos el componente que tiene
         * el objeto, que es el Rigidbody2D.
         */
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
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
