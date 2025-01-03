using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody2D rb2D;

    public float amountx;
    public float amounty;
    public float amountz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //2D ROLLING

        //if (rb2D != null)
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        rb2D.AddForce (Vector2.left * amount, ForceMode2D.Force);
        //        rb2D.AddTorque (amount, ForceMode2D.Force);
        //    }
        //    else 
        //    {
        //        rb2D.AddForce (Vector2.right * amount, ForceMode2D.Force);
        //        rb2D.AddTorque (-amount, ForceMode2D.Force);
        //    }
        //}

        //3D ROLLING

        if (rb != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.left * amountx, ForceMode.Force);
                rb.AddTorque(amountx, amounty, amountz, ForceMode.Force);
                Debug.Log("working");
            }
            else
            {
                rb.AddForce(Vector2.right * amountx, ForceMode.Force);
                rb.AddTorque(-amountx, -amounty, -amountz, ForceMode.Force);
            }
        }

    }
}
