using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject crank;
    private float currRotation = 0f;
    private float rotateVelocity = 50f;

    private float maxRotation = 50f;
    private float minRotation = -50f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player_1") || other.CompareTag("player_2") || other.CompareTag("GrabTag"))
        {
            if (other.transform.position.x > crank.transform.position.x)
            {
                currRotation += rotateVelocity * Time.fixedDeltaTime;
                if (currRotation > maxRotation)
                {
                    currRotation = maxRotation;
                    //TODO: Call function
                }
            }
            if (other.transform.position.x < crank.transform.position.x)
            {
                currRotation -= rotateVelocity * Time.fixedDeltaTime;
                if (currRotation < minRotation)
                {
                    currRotation = minRotation;
                    //TODO: Call function
                }
            }
            transform.rotation = Quaternion.Euler(0f, 0f, currRotation);
        }
    }

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private HitDirection ReturnDirection(GameObject Object, GameObject lever)
    {
        HitDirection hitDirection = HitDirection.None;
        RaycastHit MyRayHit;
        Vector3 direction = (lever.transform.position - Object.transform.position).normalized;
        Ray MyRay = new Ray(Object.transform.position, direction);
        Debug.Log("shout");
        Debug.DrawRay(Object.transform.position, direction, Color.green);
        if (Physics.Raycast(MyRay, out MyRayHit))
        {

            if (MyRayHit.collider != null)
            {
                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up) { hitDirection = HitDirection.Top; }
                if (MyNormal == -MyRayHit.transform.up) { hitDirection = HitDirection.Bottom; }
                if (MyNormal == MyRayHit.transform.forward) { hitDirection = HitDirection.Forward; }
                if (MyNormal == -MyRayHit.transform.forward) { hitDirection = HitDirection.Back; }
                if (MyNormal == MyRayHit.transform.right) { hitDirection = HitDirection.Right; }
                if (MyNormal == -MyRayHit.transform.right) { hitDirection = HitDirection.Left; }
            }
        }
        return hitDirection;
    }
}
