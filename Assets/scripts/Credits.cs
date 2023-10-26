using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private string CreditsChoosingScene = "Credits";

    public void CreditsChoosing()
    {
        SceneManager.LoadScene(CreditsChoosingScene);
    }
}