using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    public Rigidbody rb;
    private bool isFalling;
    public PlayerStatus status;
    
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().isKinematic = true;
        isFalling = false;
        
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Was hit");
            
            isFalling = true;
            rb.isKinematic = false;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (isFalling && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stunned");
            status.Stun();
            Destroy(gameObject);
        }
    }
}

            

    

        
    
