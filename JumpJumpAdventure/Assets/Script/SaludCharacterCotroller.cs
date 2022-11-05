using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class SaludCharacterCotroller : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private CharacterCotroller movimientoJugador;
    
    [Header("Salud del jugador")]
    [SerializeField] private float vida;

    [Header("Detener al jugador")]
    [SerializeField] private float tiempoPerdidaControl;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        movimientoJugador = GetComponent<CharacterCotroller>();
    }

    public void TomarDanio(float danio, Vector2 posicion)
    {
        vida -= danio;
        if (vida > 0)
        {
            animator.SetTrigger("Golpe"); //Recive golpe
            StartCoroutine(PerderControl());
            StartCoroutine(DesactivarCollision());
            movimientoJugador.ReboteGolpe(posicion);
        }
        else
        {
            PerderControl();
            animator.SetTrigger("Muerte");
            movimientoJugador.sePuedeMover = false;
            Physics2D.IgnoreLayerCollision(6, 3, true);
            rigidbody.velocity = new Vector2(0f, 0f);

        }
    }
    
    /*
     * Creamos unas acorutina
     */
    private IEnumerator PerderControl()
    {
        /*
         * Le indicamos que el jugador no se puede mover, esperamso un tiempo y loego dejamos que el personaje se pueda
         * mover nuevamente.
         */
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

    private IEnumerator DesactivarCollision()
    {
        /*
         * Ignora a las layers que estan dentro ded los parentecis.
         *  6 = Player(Primero el player), 3 = Enemigos y true = ignore.
         */
        Physics2D.IgnoreLayerCollision(6, 3, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 3, false);
    }
}
