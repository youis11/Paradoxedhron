using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    void OnCollision(Collision collision)
    {

        Debug.Log(ReturnDirection(collision.gameObject, this.gameObject));

        //if (ReturnDirection(collision.gameObject, this.gameObject) == HitDirection.Right)
        //{
        //    transform.Rotate(Vector3.forward * 2 * Time.deltaTime);
        //}

        //if (ReturnDirection(collision.gameObject, this.gameObject) == HitDirection.Left)
        //{
        //    transform.Rotate(-Vector3.forward * 2 * Time.deltaTime);
        //}
    }

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private HitDirection ReturnDirection(GameObject Object, GameObject lever)
    {
        HitDirection hitDirection = HitDirection.None;
        RaycastHit MyRayHit;
        Vector3 direction = (lever.transform.position - Object.transform.position).normalized;
        Ray MyRay = new Ray(Object.transform.position, direction);

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
