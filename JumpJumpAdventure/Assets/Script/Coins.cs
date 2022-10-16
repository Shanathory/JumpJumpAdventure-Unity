using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int valor = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) // Si el que colisiona es el player, se ejecuta. Evita que "enemigo" la agarre sin querer.
        {
            GameManager.sharedInstance.SumarPuntos(valor);
            Destroy(this.gameObject);            
        }
    }
}
