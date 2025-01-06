using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaulting : MonoBehaviour
{
    [SerializeField] private Vector3 forwardRayOffset;

    [SerializeField] private float forwardRayLength;
    [SerializeField] private float heightRayLength;

    [SerializeField] private LayerMask obstacleMask;

    private RaycastHit forwardHitData;
    private RaycastHit heightHitData;

    [SerializeField] private PlayerMovementAdvanced pm;
    [SerializeField] private VaultAction vaultAction;

    // Update is called once per frame
    void Update()
    {
        if (!pm.inAction && ObstacleCheck())
        {
            if (vaultAction.CanVault(forwardHitData, heightHitData, transform))
            {
                StartCoroutine(Vault());
            }
        } 
    }

    private IEnumerator Vault()
    {
        pm.enabled = false;

        MatchTargetParameters matchTargetParams = null;
        if (vaultAction.EnableTargetMatching)
        {
            matchTargetParams = new MatchTargetParameters()
            {
                matchPos = vaultAction.MatchPos,
                matchBodyPart = vaultAction.MatchBodyPart,
                matchPosWeight = vaultAction.MatchPosWeight,
                matchStartTime = vaultAction.MatchStartTime,
                matchTargetTime = vaultAction.MatchTargetTime,
            };
        }

        yield return pm.PerformVaulting(vaultAction.AnimName, matchTargetParams, vaultAction.TargetRotation, vaultAction.RotateTowardsObstacle, vaultAction.MirrorActionAnimation);

        pm.enabled = true;
    }

    public bool ObstacleCheck()
    {
        var forwardOrigin = transform.position + forwardRayOffset;

        bool obstacleDectected = Physics.Raycast(forwardOrigin, transform.forward, out forwardHitData, forwardRayLength, obstacleMask);

        Debug.DrawRay(forwardOrigin, transform.forward * forwardRayLength, obstacleDectected ? Color.green : Color.red);
        bool obstacleHeightDetected = false;
        
        if(obstacleDectected)
        {
            var heightOrigin  = forwardHitData.point + Vector3.up * heightRayLength;

            obstacleHeightDetected = Physics.Raycast(heightOrigin, Vector3.down, out heightHitData, heightRayLength, obstacleMask);

            Debug.DrawRay(forwardOrigin, transform.forward * forwardRayLength, obstacleDectected ? Color.green : Color.red);
        }
        return obstacleHeightDetected && obstacleDectected;
    }
}
