using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject camTPP;
    public GameObject camFPP;
    public TPPThrowing TPPshooting;
    public Throwing shooting;

   


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camTPP.SetActive(true);
        shooting.enabled = false;
        TPPshooting.enabled = true;
        camFPP.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            camTPP.SetActive(false);
            camFPP.SetActive(true);
            TPPshooting.enabled = false;
            shooting.enabled = true;
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            camTPP.SetActive(true);
            camFPP.SetActive(false);
            shooting.enabled = false;
            TPPshooting.enabled = true;

        }
    }
}
