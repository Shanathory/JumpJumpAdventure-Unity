using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RecibirDanioEnemi : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject efectoMuerte;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) //Para saber si se paro el jugador arriba
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*
             * Recorre los puntos de contactos como si fuera una matriz, para saber en donde toco el jugador.
             */
            foreach (ContactPoint2D punto in other.contacts) 
            {
                /*
                 * si el punto de contacto es -1, significa que le toco la caveza.
                 */
                if (other.GetContact(0).normal.y <=-0.9)
                {
                    animator.SetTrigger("Golpe");
                    other.gameObject.GetComponent<CharacterCotroller>().Rebote();
                }
            }
        }
    }

    public void Rebentar()
    {
        Instantiate(efectoMuerte, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
