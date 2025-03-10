using UnityEngine;
using UnityEngine.Events;
public class InputManager : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float dashForce = 10f;
    private bool canDoubleJump;
    private bool canDash;
    private Rigidbody playerRb;

    public UnityEvent OnSettingsMenu = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnSettingsMenu.Invoke();
        }
        HandleMovement();
        HandleJump();
        HandleDash();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            player.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void UpdatePlayerMaxSpeed(float speed){
        moveSpeed = speed;
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, jumpForce, playerRb.linearVelocity.z);
                canDoubleJump = true;
                canDash = true;
            }
            else if (canDoubleJump)
            {
                playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, jumpForce, playerRb.linearVelocity.z);
                canDoubleJump = false;
            }
        }
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Vector3 dashDirection = cameraTransform.forward;
            playerRb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
            canDash = false;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(player.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canDoubleJump = true;
            canDash = true;
        }
    }
}
