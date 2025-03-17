using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tiempoAntesDeSalir;

    [SerializeField] private sceneController controller;

    public void muereJugador()
    {
        Invoke(nameof (vueltaMenu) , tiempoAntesDeSalir);
    }

    private void vueltaMenu()
    {
        controller.loadScene("Menu");

    }
}
