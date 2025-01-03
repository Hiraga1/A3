using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    private bool didCollideThisFrame;

    private Rigidbody rb;
    private Rigidbody2D rb2D;

    private HingeJoint hj;
    private HingeJoint2D hj2D;

    private JointMotor motor;
    private JointMotor2D motor2D;


    // Start is called before the first frame update
    void Start()
    {
        //Getting my rigidbody & hingejoints
        rb = GetComponent<Rigidbody>();
        rb2D = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint>();
        hj2D = GetComponent<HingeJoint2D>();


        //Checking if I'm in 3D or 2D, then learning my motor
        if (rb!=null)
        {
            motor = hj.motor;
        } 
        else 
        {
            motor2D = hj2D.motor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if 3D
        if (rb!=null)
        {
            //when getting Space down
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("pressing space");

                //Adding motorspeed to my motor
                motor.targetVelocity = 500f;
            } 
            else 
            {
                motor.targetVelocity = -500f;
            }

            //MAKE SURE YOU FEED MOTOR DATA INTO THE HINGEJOINT'S MOTOR ("HingeJoint.motor")
            hj.motor = motor;
        }
        
        if (rb2D != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("pressing space");
                motor2D.motorSpeed = 500f;
            } 
            else 
            {
                motor2D.motorSpeed = -500f;
            }

            hj2D.motor = motor2D;
        }

    }
    //collision code
    private void OnCollisionEnter2D(Collision2D other) {



        //if you did collide with this, get out
        if (didCollideThisFrame) return;


        //checking that the tag is "edible"
        if (other.gameObject.CompareTag("Edible")){
            //Up score, destroy other
            Debug.Log("This is edible!");
            score++;
            Destroy(other.gameObject);

            //now I DID collide with this
            didCollideThisFrame = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (didCollideThisFrame) return;

        if (other.gameObject.CompareTag("Edible")){
            score++;
            Destroy(other.gameObject);
            didCollideThisFrame = true;
        }


    }
}
