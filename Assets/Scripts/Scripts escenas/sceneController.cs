using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    [SerializeField] private float sceneFadeDuracion;

    private sceneFade sceneFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<sceneFade>();
    }

    private IEnumerator Start()
    {
        yield return sceneFade.fadeInCourtine(sceneFadeDuracion);
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCourtine(sceneName));
    }

    private IEnumerator LoadSceneCourtine(string sceneName)
    {
        yield return sceneFade.fadeOutCoroutine(sceneFadeDuracion);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
