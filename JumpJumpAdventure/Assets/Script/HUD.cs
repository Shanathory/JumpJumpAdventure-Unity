using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManager.propiedadPuntosTotales.ToString();
    }
}
