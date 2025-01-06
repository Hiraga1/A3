using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "VaultAction / New Vault Action Data")]
public class VaultAction : ScriptableObject
{
    [Header("Infomation")]
    [SerializeField] private string animName;
    [SerializeField] private string obstacleTag;

    [Header("Height Ranges")]
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    [SerializeField] private bool rotateTowardsObstacle;

    [Header("Target Matching")]
    [SerializeField] private bool enableTargetMatching = true;

    [SerializeField] protected AvatarTarget matchBodyPart;

    [SerializeField] private Vector3 matchPosWeight = new Vector3(0.0f, 1.0f, 1.0f);

    [SerializeField] private float matchStartTime;
    [SerializeField] private float matchTargetTime;

    public Quaternion TargetRotation { get; set; }

    public Vector3 MatchPos { get; set; }

    public bool MirrorActionAnimation { get; set; }

    public string AnimName { get {  return animName; } set { animName = value; } }

    public bool RotateTowardsObstacle => rotateTowardsObstacle;

    public bool EnableTargetMatching => enableTargetMatching;

    public AvatarTarget MatchBodyPart => matchBodyPart;

    public Vector3 MatchPosWeight => matchPosWeight;

    public float MatchStartTime { get { return matchStartTime; } set { matchStartTime = value; } }

    public float MatchTargetTime { get { return matchTargetTime; } set { matchTargetTime = value; } }

    public bool CanVault(RaycastHit forwardHitData, RaycastHit heightHitData, Transform playerTransform)
    {
        if (!forwardHitData.transform.CompareTag(obstacleTag))
            return false;

        var height = heightHitData.point.y - playerTransform.position.y;
        if (height < minHeight || height > maxHeight)
            return false;

        if (rotateTowardsObstacle)
            TargetRotation = Quaternion.LookRotation(-forwardHitData.normal);

        if (enableTargetMatching)
            MatchPos = heightHitData.point;

        var hitPoint = forwardHitData.transform.InverseTransformPoint(forwardHitData.point);

        if ((hitPoint.x < 0.0f && hitPoint.x > -0.3f) || (hitPoint.x > 0.0f && hitPoint.x < 0.3f))
        {
            animName = "VaultCenter";
            matchBodyPart = AvatarTarget.RightHand;
            MatchStartTime = 0.37f;
            MatchTargetTime = 0.56f;
        }
        else if ((hitPoint.z < 0.0f && hitPoint.x < -0.3) || (hitPoint.z > 0.0f && hitPoint.z > 0.3f))
        {
            animName = "Vault";
            MirrorActionAnimation = true;
            matchBodyPart = AvatarTarget.RightHand;
            MatchStartTime = 0.12f;
            MatchTargetTime = 0.32f;
        }
        else
        {
            animName = "Vault";
            MirrorActionAnimation = false;
            matchBodyPart = AvatarTarget.LeftHand;
            MatchStartTime = 0.12f;
            MatchTargetTime = 0.32f;
        }
        return true;
        
    }
}
