using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamaraController : MonoBehaviour
{
    public Transform personaje; // Esto es para asignar al gameObjet personaje en el motor.
    private float tamanioCamara;
    private float alturaPantalla;
    
    // Start is called before the first frame update
    void Start()
    {
        tamanioCamara = Camera.main.orthographicSize; //Obtenemos el tamanio de la camara.
        alturaPantalla = tamanioCamara * 2; // De esta manera, obtenemos el tamanio de toda la pantalla que se mostrara en juego.
    }

    // Update is called once per frame
    void Update()
    {
        CalcularPosicionCamara();
    }

    void CalcularPosicionCamara()
    {
        /*
         * Calculamos la posicion del personaje, para poder hacer el cambio de camara en el momento que el personaje
         * pase la frontera de la camara.
         */
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamanioCamara;
        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}
