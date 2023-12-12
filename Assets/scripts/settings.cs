using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject canvasToActivate;
    public GameObject canvasToDeactivate;

    public void OnButtonClicked()
    {
        canvasToActivate.SetActive(true);

        if (canvasToDeactivate != null)
        {
            canvasToDeactivate.SetActive(false);
        }
    }
}