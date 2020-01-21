using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class Movement : MonoBehaviour
{
    public float movementVelocity = 0;
    public float rotationVelocity = 0;

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

        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);

        if (movement != Vector3.zero)
        {
            rigidbody.velocity = movement * movementVelocity * Time.deltaTime;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

        Vector3 rotation = new Vector3(-state.ThumbSticks.Right.Y, state.ThumbSticks.Right.X, 0f);

        if (rotation != Vector3.zero)
        {
            cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localRotation.eulerAngles.x + rotation.x * rotationVelocity * Time.deltaTime, cameraTransform.localRotation.eulerAngles.y + rotation.y * rotationVelocity * Time.deltaTime, cameraTransform.localRotation.eulerAngles.z);
        }
    }
}
