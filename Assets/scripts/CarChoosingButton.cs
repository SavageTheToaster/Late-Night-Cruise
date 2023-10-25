using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarChoosingButton : MonoBehaviour
{
    [SerializeField] private string CarChoosingScene = "CarChoosing";

    public void CarChoosing()
    {
        SceneManager.LoadScene(CarChoosingScene);
    }
}