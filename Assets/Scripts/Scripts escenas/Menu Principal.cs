using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private sceneController controller;

    public void play()
    {
        controller.loadScene("Juego");
    }

    public void exit()
    {
        Application.Quit();
    }
}
