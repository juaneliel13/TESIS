using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    public CharacterController player;
    public float playerSpeed;
    private Vector3 playerInput;
    public Camera mainCamara;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;
        setGravity();

        player.Move(movePlayer * Time.deltaTime);
    }

    void camDirection()
    {

        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;
        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }

    void setGravity()
    {


        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }



    }
}
