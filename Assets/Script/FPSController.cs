using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float shootPower = 15f;
    public float jumpForce = 7f;
    private int jumpCount = 0;
    private int maxJumps = 1;
    
    [Header("Dash Settings")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    
    [Header("References")]
    public Rigidbody playerRigidbody;
    public Transform cameraTransform;
    public GameObject projectile;
    public Transform shootPoint;
    
    private float xRotation = 0f;
    private bool isDashing;
    private float dashTimeLeft;
    private float dashCooldownTimer;
    private Vector3 dashDirection;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidbody.freezeRotation = true;
    }
    
    void Update()
    {
        if (!isDashing)
        {
            HandleMouseLook();
            Shoot();
            HandleDashInput();
            HandleJump();
        }
        UpdateDash();
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;
    }

    void HandleJump()
    {
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    
    void FixedUpdate()
    {
        if (!isDashing)
        {
            HandleMovementPhysics();
        }
    }
    
    void HandleMovementPhysics()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) movement += transform.forward;
        if (Input.GetKey(KeyCode.S)) movement -= transform.forward;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) movement -= transform.right;
        if (Input.GetKey(KeyCode.D)) movement += transform.right;
    
        movement = movement.normalized * moveSpeed;
        movement.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = movement;
    }
    
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    
    void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0)
        {
            Vector3 dashDir = Vector3.zero;
            
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
                dashDir += transform.forward;
            if (Input.GetKey(KeyCode.S))
                dashDir -= transform.forward;
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
                dashDir -= transform.right;
            if (Input.GetKey(KeyCode.D))
                dashDir += transform.right;
            
            if (dashDir != Vector3.zero)
            {
                StartDash(dashDir.normalized);
            }
        }
    }
    
    void StartDash(Vector3 direction)
    {
        isDashing = true;
        dashTimeLeft = dashDuration;
        dashDirection = direction;
        dashCooldownTimer = dashCooldown;
    }
    
    void UpdateDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                playerRigidbody.velocity = dashDirection * dashSpeed;
                dashTimeLeft -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject balle = Instantiate(projectile, shootPoint.position, projectile.transform.rotation);
            balle.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootPower, ForceMode.Impulse);
        }
    }
}