using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject crank;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player_1") || other.CompareTag("player_2"))
        {
            //Debug.Log(ReturnDirection(other.gameObject, this.gameObject));

            //if (ReturnDirection(other.gameObject, gameObject) == HitDirection.Right)
            //{
            Debug.Log("right");
            transform.Rotate(new Vector3(0f, 0f, 500f * Time.fixedDeltaTime));
            //}

            //if (ReturnDirection(other.gameObject, gameObject) == HitDirection.Left)
            //{
            //    Debug.Log("left");
            //    transform.Rotate(new Vector3(0f, 0f, -500f * Time.fixedDeltaTime));
            //}

            if (other.transform.position.x > crank.transform.position.x)
            {
                transform.Rotate(new Vector3(0f, 0f, 500f * Time.fixedDeltaTime));
            }
            if (other.transform.position.x < crank.transform.position.x)
            {
                transform.Rotate(new Vector3(0f, 0f, -500f * Time.fixedDeltaTime));
            }
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
