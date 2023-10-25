using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car3 : MonoBehaviour
{
    [SerializeField] private string Car = "Car3";

    public void CarChoosing()
    {
        SceneManager.LoadScene(Car);
    }
}