using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 finalPosition;
    private float swipeAngle;

    private void OnMouseDown()
    {
        //mendapatkan titik awal sentuhan
        firstPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalPosition.y - firstPosition.y, finalPosition.x - firstPosition.x) * 180 / Mathf.PI;
        MoveTile();
    }

    void MoveTile()
    {
        if(swipeAngle > -45 && swipeAngle <= 45)
        {
            // right swipe
            Debug.Log("Right Swipe");
        }

        else if(swipeAngle > 45 && swipeAngle <= 135)
        {
            //up swipe
            Debug.Log("Up Swipe");
        }

        else if(swipeAngle > 135 || swipeAngle <= -135)
        {
            //Left Swipe
            Debug.Log("Left Swipe");
        }

        else if(swipeAngle < -45 && swipeAngle >= -135)
        {
            //Down Swipe
            Debug.Log("Down Swipe");
        }
    }
  
}
