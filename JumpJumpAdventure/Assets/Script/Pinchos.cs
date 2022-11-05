using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*
             * TomarDanio(danio, posicion)
             */
            other.gameObject.GetComponent<SaludCharacterCotroller>().TomarDanio(100, other.GetContact(0).normal);
        }
    }
}
