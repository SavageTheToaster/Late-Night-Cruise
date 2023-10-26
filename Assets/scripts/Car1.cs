using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car1 : MonoBehaviour
{
    [SerializeField] private string Car = "Car1";

    public void CarChoosing()
    {
        SceneManager.LoadScene(Car);
    }
}