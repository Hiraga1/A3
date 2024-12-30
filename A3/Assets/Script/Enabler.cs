using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraView : MonoBehaviour
{
    [Header("Objects")]
    public GameObject camTPP;
    public GameObject camFPP;
    public TPPThrowing TPPshooting;
    public Throwing FPPshooting;
    public GameObject camTPPVCam;
    public GameObject GrapplingSphereFPP;
    public GameObject GrapplingSphereTPP;
   


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        camTPP.SetActive(true);
        camTPPVCam.SetActive(true);
        TPPshooting.enabled = true;
        FPPshooting.enabled = false;
        camFPP.SetActive(false);
        GrapplingSphereFPP.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            camTPP.SetActive(false);
            camFPP.SetActive(true);
            TPPshooting.enabled = false;
            FPPshooting.enabled = true;
            camTPPVCam.SetActive(false);
            GrapplingSphereTPP.SetActive(false);
            GrapplingSphereFPP.SetActive(true);
        }
        if (Gamepad.current.leftTrigger.isPressed)
        {
            camTPP.SetActive(false);
            camFPP.SetActive(true);
            TPPshooting.enabled = false;
            FPPshooting.enabled = true;
            camTPPVCam.SetActive(false);
            GrapplingSphereTPP.SetActive(false);
            GrapplingSphereFPP.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            camTPP.SetActive(true);
            camFPP.SetActive(false);
            FPPshooting.enabled = false;
            TPPshooting.enabled = true;
            camTPPVCam.SetActive(true);
            GrapplingSphereTPP.SetActive(true);
            GrapplingSphereFPP.SetActive(false);
        }
        if (Gamepad.current.leftTrigger.wasReleasedThisFrame)
        {
            camTPP.SetActive(true);
            camFPP.SetActive(false);
            FPPshooting.enabled = false;
            TPPshooting.enabled = true;
            camTPPVCam.SetActive(true);
            GrapplingSphereTPP.SetActive(true);
            GrapplingSphereFPP.SetActive(false);
        }
    }
    
}
