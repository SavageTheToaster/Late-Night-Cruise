using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Youbad : MonoBehaviour
{
    public string CarChoosingoi;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            // Call the method to change the scene after reloading
            ChangeScene();
        }
    }

    // Call this method to change the scene
    void ChangeScene()
    {
        try
        {
            SceneManager.LoadScene(CarChoosingoi);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error changing scene: " + e.Message);
        }
    }
}