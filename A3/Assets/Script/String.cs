using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform centerPoint;

    public LineRenderer slingShotString;
    void Start()
    {
        slingShotString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slingShotString.SetPositions(new Vector3[3] {leftPoint.position, rightPoint.position, centerPoint.position});
    }
}
