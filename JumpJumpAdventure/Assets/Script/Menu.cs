using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void Salir()
    {
        Debug.Log("ByeBye");
        Application.Quit();
    }
}
