using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class Movement : MonoBehaviour
{
    public float movementVelocity = 0;
    public float rotationVelocity = 0;
    public float jumpForce = 0;
    public float downJumpForce = 0;
    public int camXBlockMax = 0;
    public int camXBlockMin = 0;

    private float playerRotationX = 0f;

    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public Transform cameraTransform = null;

    Rigidbody rigidbody = null;

    bool jumping = false;
    private bool canJump = false;
    [HideInInspector]
    public bool grabbing = false;

    [HideInInspector]
    public GameObject grabbed = null;

    private float maxY = 0f;

    Animator anim;
    public enum States
    {
        IDLE=0,
        RUNNING,
        JUMPING,
        GRAB_IDLE,
        GRAB_RUN,
    }

    public States movement_state = States.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        prevState = state;
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
        movement *= movementVelocity;
        movement.y = rigidbody.velocity.y;

        if (movement.x == 0 && movement.z == 0 && canJump)
        {
            movement_state = States.IDLE;
        }
        else if(!canJump)
        {
            movement_state = States.JUMPING;
        }
        else
        {
            movement_state = States.RUNNING;
        }

        if(movement_state == States.JUMPING)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 1;
        }

        rigidbody.velocity = movement;
        anim.SetInteger("State", (int)movement_state);
        anim.SetFloat("vel_x", state.ThumbSticks.Left.X);
        anim.SetFloat("vel_y", state.ThumbSticks.Left.Y);
        

        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && canJump)
        {
            canJump = false;
            rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }

        //IF IS NOT TOUCHING THE GROUND
        //RESET WHEN IT TOUCHES THE GROUND  
        if (Physics.OverlapSphere(new Vector3(transform.position.x,transform.position.y - 0.1f,transform.position.z), 0.5f).Length == 1)
        {
            canJump = false;
            if (transform.position.y > maxY)
            {
                maxY = transform.position.y;
            }
            else
            {
                rigidbody.AddForce(Vector3.down * downJumpForce);
            }
        }
        else
        {
            maxY = transform.position.y;
            canJump = true;
        }

        Grab();
    }

    void Grab()
    {
        if (state.Buttons.RightShoulder == ButtonState.Pressed)
        {
            grabbing = true;
        }
        else
        {
            if (grabbed != null)
            {
                grabbed.gameObject.GetComponent<BeGrabbed>().isGrabbed = false;
                grabbed = null;
            }
            grabbing = false;
        }

        if (grabbed != null)
        {
            grabbed.transform.position = cameraTransform.forward * 2 + cameraTransform.position;
            grabbed.transform.forward = transform.forward;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 0.1F, transform.position.z), 0.5F);
    }
}
