using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPPThrowing : MonoBehaviour
{
    public Transform camTPP;

    public Transform attackPointTPP;

    public GameObject throwing;

    public float CD;

    public float throwForce;
    public float maxThrowForce;
    public float upwardThrowForce;

    //bool readytoThrow;


    void Start()
    {
        //readytoThrow = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.rightTrigger.isPressed)
        {
            throwForce += 20 * Time.deltaTime;
            if (throwForce > maxThrowForce)
            {
                throwForce = maxThrowForce;
            }


        }
        if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
        {
            Throw();
            throwForce = 1;
            //if (Input.GetKey(KeyCode.Mouse0))
            //{

            //    throwForce++;
            //    if (throwForce > maxThrowForce)
            //    {
            //        throwForce = maxThrowForce;
            //    }

            //}
            //else
            //{
            //    throwForce--;
            //    if (throwForce < 0)
            //    {
            //        throwForce = 1;
            //    }

            //}

            //if (Input.GetKeyUp(KeyCode.Mouse0) && readytoThrow)
            //{
            //    Throw();

            //}
        }
    }

    private void Throw()
    {
        //readytoThrow = false;

        GameObject projectile = Instantiate(throwing, attackPointTPP.position, camTPP.rotation);

        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = camTPP.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(camTPP.position, camTPP.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPointTPP.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * upwardThrowForce;

        projectilerb.AddForce(forceToAdd, ForceMode.Impulse);

        Invoke(nameof(Cooldown), CD);
    }



    private void Cooldown()
    {
        //readytoThrow = true;
    }

}
