using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car2 : MonoBehaviour
{
    [SerializeField] private string Car = "Car2";

    public void CarChoosing()
    {
        SceneManager.LoadScene(Car);
    }
}