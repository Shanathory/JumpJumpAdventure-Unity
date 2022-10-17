using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int valor = 1;
    public AudioClip sonidoCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) // Si el que colisiona es el player, se ejecuta. Evita que "enemigo" la agarre sin querer.
        {
            GameManager.sharedInstance.SumarPuntos(valor);
            Destroy(this.gameObject);     
            AudioManager.sharedInstace.ReproducirSonido(sonidoCoin);
        }
    }
}
