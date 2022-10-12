using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCotroller : MonoBehaviour
{
    public float velocidadMovimiento;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
       
        /*
         * Los GetAxis son funciones dentro del InputManager y funcionan con un valo rpositivo y el
         * mismo valor, pero negativo. En caso de este input funciona con las flechitas.
         * Lo utilizaremos para poder mover la personaje.
         */
        float inputMovimiento = Input.GetAxis("Horizontal");
    
        /*
         * Instansiamos la variable rigidbody y obtenemos el componente que tiene
         * el objeto, que es el Rigidbody2D.
         */
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(inputMovimiento * velocidadMovimiento, rigidbody.velocity.y); //Mueve al personaje en el eje X.
    }
}
