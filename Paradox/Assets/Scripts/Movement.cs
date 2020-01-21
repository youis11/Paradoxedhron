using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class Movement : MonoBehaviour
{
    public float movementVelocity = 0;
    public float rotationVelocity = 0;

    public int camXBlockMax = 0;
    public int camXBlockMin = 0;

    private float playerRotationX = 0f;

    public PlayerIndex playerIndex;
    GamePadState state;

    public Transform cameraTransform = null;

    Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        state = GamePad.GetState(playerIndex);

        Vector3 rotation = new Vector3(-state.ThumbSticks.Right.Y, state.ThumbSticks.Right.X, 0f);

        if (rotation.y != 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotation.y * rotationVelocity * Time.deltaTime, transform.localRotation.eulerAngles.z);
        }

        if (rotation.x != 0)
        {
            playerRotationX += rotation.x * rotationVelocity * Time.deltaTime;
            if (playerRotationX > camXBlockMax)
            {
                playerRotationX = camXBlockMax;
            }
            if (playerRotationX < camXBlockMin)
            {
                playerRotationX = camXBlockMin;
            }
            cameraTransform.localRotation = Quaternion.Euler(playerRotationX, cameraTransform.localRotation.eulerAngles.y, cameraTransform.localRotation.eulerAngles.z);
        }

        Vector3 movement = Vector3.zero;
        movement += transform.right * state.ThumbSticks.Left.X;
        movement += transform.forward * state.ThumbSticks.Left.Y;
        rigidbody.velocity = movement * movementVelocity;   
    }
}
