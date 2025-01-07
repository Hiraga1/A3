using Cinemachine;
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


    [Header("Aiming")]
    public CinemachineVirtualCamera cam;
    public float aimFov = 40;
    public float firstFov = 10;
    public Cinemachine3rdPersonFollow smallCam;
    public Vector3 firstPos;
    public Vector3 aimPos = new Vector3(-0.4f, 0.5f, 0f);
    [HideInInspector] public float currentFov;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        firstFov = 60;
        smallCam = cam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        firstPos = smallCam.ShoulderOffset;

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
            /*camTPP.SetActive(false);
            camFPP.SetActive(true);
            TPPshooting.enabled = false;
            FPPshooting.enabled = true;
            camTPPVCam.SetActive(false);
            GrapplingSphereTPP.SetActive(false);
            GrapplingSphereFPP.SetActive(true);*/
            cam.m_Lens.FieldOfView = aimFov;
            smallCam.ShoulderOffset = firstPos + aimPos;
        }
        if (Gamepad.current.leftTrigger.isPressed)
        {
            /*camTPP.SetActive(false);
            camFPP.SetActive(true);
            TPPshooting.enabled = false;
            FPPshooting.enabled = true;
            camTPPVCam.SetActive(false);
            GrapplingSphereTPP.SetActive(false);
            GrapplingSphereFPP.SetActive(true);*/
            cam.m_Lens.FieldOfView = aimFov;
            smallCam.ShoulderOffset = firstPos + aimPos;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            /*camTPP.SetActive(true);
            camFPP.SetActive(false);
            FPPshooting.enabled = false;
            TPPshooting.enabled = true;
            camTPPVCam.SetActive(true);
            GrapplingSphereTPP.SetActive(true);
            GrapplingSphereFPP.SetActive(false);*/
            cam.m_Lens.FieldOfView = firstFov;
            smallCam.ShoulderOffset = firstPos;
        }
        if (Gamepad.current.leftTrigger.wasReleasedThisFrame)
        {
            /*camTPP.SetActive(true);
            camFPP.SetActive(false);
            FPPshooting.enabled = false;
            TPPshooting.enabled = true;
            camTPPVCam.SetActive(true);
            GrapplingSphereTPP.SetActive(true);
            GrapplingSphereFPP.SetActive(false);*/
            cam.m_Lens.FieldOfView = firstFov;
            smallCam.ShoulderOffset = firstPos;
        }
    }
    
}
