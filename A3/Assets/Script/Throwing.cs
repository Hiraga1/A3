using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject throwing;

    public float CD;

    public float throwForce;
    public float maxThrowForce;
    public float upwardThrowForce;

    bool readytoThrow;


    void Start()
    {
        readytoThrow = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            throwForce++;
            if (throwForce > maxThrowForce)
            {
                throwForce = maxThrowForce;
            }
        }
        else
        {
            throwForce--;
            if (throwForce < 0)
            {
                throwForce = 1;
            }

        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0) && readytoThrow)
        {
            Throw();
        }
    }

    private void Throw()
    {
       readytoThrow = false;

        GameObject projectile = Instantiate(throwing, attackPoint.position, cam.rotation);

        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * upwardThrowForce;

        projectilerb.AddForce(forceToAdd, ForceMode.Impulse);

        Invoke(nameof(Cooldown), CD);
    }

    private void Cooldown()
    {
        readytoThrow = true;
    }
   
}
