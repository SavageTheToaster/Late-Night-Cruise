using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        SceneManager.activeSceneChanged += RestartScenes;
    }

    private void RestartScenes(Scene previousScene, Scene newScene)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene != newScene)
            {
                SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
            }
        }
    }
}