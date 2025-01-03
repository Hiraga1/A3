using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get mouse position on screen
        Vector2 mousePositionOnScreen = Input.mousePosition;

        //Convert that to position in world
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        //Move myself to that position
        transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0);
    }
}
