using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask whatIsWall;
    public PlayerMovementTutorial pm;

    [Header("ClimbJumping")]
    public float climbJumpUpForce;
    public float climbJumpBackForce;
    
    public KeyCode jumpkey = KeyCode.Space;
    public int climbJumps;
    private int climbJumpCount;


    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;

    private bool climbing;

    [Header("Dectection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float WallLookAngle;

    private Transform lastWall;
    private Vector3 lastWallNormal;
    public float minWallNormalAngleChange;

    [Header("Exiting")]
    public bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;

    private RaycastHit frontWallHit;
    private bool wallFront;

    private void Update()
    {
        WallCheck();
        StateMachine();

        if (climbing && !exitingWall) ClimbingMovement(); 
    }

    private void StateMachine()
    {
        if(wallFront && Input.GetKey(KeyCode.W) && WallLookAngle < maxWallLookAngle && !exitingWall)
        {
            if(!climbing && climbTimer > 0) StartClimbing();
            if(climbTimer > 0) climbTimer -= Time.deltaTime;
            if(climbTimer < 0) StopClimbing();
        }
        else if (exitingWall)
        {
            if (climbing) StopClimbing();

            if(exitWallTimer > 0) exitWallTimer -= Time.deltaTime;
            if(exitWallTimer < 0) exitingWall = false;
        }
        else
        {
            if (climbing) StopClimbing() ;
        }
        if(wallFront && Input.GetKeyDown(jumpkey) && climbJumpCount > 0) ClimbJump();


    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out  frontWallHit, detectionLength, whatIsWall);
        WallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        bool newWall = frontWallHit.transform != lastWall|| Mathf.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) > minWallNormalAngleChange;

        if ((wallFront && newWall) || pm.grounded)
        {
            climbTimer = maxClimbTime;
            climbJumpCount = climbJumps;
        }
    }
    private void StartClimbing()
    {
        climbing = true;
        lastWall = frontWallHit.transform;
        lastWallNormal = frontWallHit.normal;
    }
    private void StopClimbing()
    {
        climbing = false;
    }
    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.y);
    }
    private void ClimbJump()
    {
        exitingWall = true;
        exitWallTimer = exitWallTime;
        Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);

        climbJumpCount--;
    }
}
