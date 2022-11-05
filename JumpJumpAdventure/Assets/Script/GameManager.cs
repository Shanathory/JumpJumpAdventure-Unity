using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * Creamos unapropiedad que logre obtener (get) o modificar (set) a la variable privada puntos totales.
     * El crear esta propiedad, se puede acceder a la variable como si fuera publica, pero sin que esta lo sea.
     * Porque? porque si fuera publica, podriamos terminar modificandola en el engine.
     */
    public int propiedadPuntosTotales // Propiedad de solo lectura.
    {
        get { return puntosTotales; } 
    }
    private int puntosTotales;
    public static GameManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
       Debug.Log(puntosTotales);
    }
    
}
