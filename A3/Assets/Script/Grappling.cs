using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    private PlayerMovementAdvanced pm;
    public Transform cam;
    public Transform gunTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lr;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float overshootYAxis;

    private Vector3 grapplePoint;

    private InputActionAsset inputAsset;
    private InputActionMap inputMap;
    private InputAction action;

    [Header("Cooldown")]
    public float grappleCD;
    private float grappleCDTimer;

    [Header("Input")]
    public KeyCode grappleKey = KeyCode.F;

    private bool grappling;
    void Start()
    {
        pm = GetComponent<PlayerMovementAdvanced>();
    }
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        inputMap.FindAction("Grapple").started += Grapple;
        inputMap = inputAsset.FindActionMap("Player");
    }

    private void Grapple(InputAction.CallbackContext context)
    {
        {
            StartGrapple();
            
        }
        
    }

    private void OnDisable()
    {
        inputMap = inputAsset.FindActionMap("Player");
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void DrawRope()
    {
        if (grappling) lr.SetPosition(0, gunTip.position);
    }

    private void StartGrapple()
    {
        if(grappleCDTimer > 0) return;

        grappling = true;

        pm.freeze = true;
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
            pm.canDoubleJump = true;
        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);
        }
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExecuteGrapple()
    {
        pm.freeze = false;

        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;

        pm.JumpToPosition(grapplePoint, highestPointOnArc);

        Invoke(nameof(StopGrapple), 1f);
    }
    public void StopGrapple()
    {
        pm.freeze = false;

        grappling = false;

        grappleCDTimer = grappleCD;

        lr.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grappleKey))
        {
            StartGrapple();
        }
        if (grappleCDTimer > 0)
        {
            grappleCDTimer -= Time.deltaTime;   
        }
    }
}
