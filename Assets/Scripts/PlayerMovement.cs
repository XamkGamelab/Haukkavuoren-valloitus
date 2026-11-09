using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [Range(1f, 20f)]
    public float moveSpeed = 10f;
    [Range(1f, 20f)]
    public float jumpStrength = 8f;

    [Header("Player Images")]
    [Tooltip("The sprite shown when the player is on the ground.")]
    public Sprite playerImage;
    [Tooltip("The sprite shown while the player is jumping.")]
    public Sprite jumpImage;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float moveInput;
    private bool isGrounded;

    public float groundCheckDistance = 0.6f;
    public float groundCheckWidth = 0.8f;
    public float groundCheckOffsetX = 0f;

    [Header("What Is Ground")]
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Update()
    {
        //isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer).collider != null;

        //isGrounded = Physics2D.OverlapBox(transform.position + Vector3.down * groundCheckDistance,new Vector2(groundCheckWidth, 0.2f),0f,groundLayer);

        isGrounded = Physics2D.OverlapBox(
        transform.position + new Vector3(groundCheckOffsetX, -groundCheckDistance, 0f),
        new Vector2(groundCheckWidth, 0.2f),
        0f,
        groundLayer
        );

        if (isGrounded)
        {
            if(playerImage)
                spriteRenderer.sprite = playerImage;
        }
        //else
        //{
        //    if(jumpImage)
        //        spriteRenderer.sprite = jumpImage;
        //}
    }

    private void Jump()
    {
        if (isGrounded)
        {
            AudioManager.Instance.PlayJumpSound();
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }

    public void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Jump();
            Debug.Log("Jump pressed");
        }
    }

    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>().x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(
        transform.position + new Vector3(groundCheckOffsetX, -groundCheckDistance, 0f),
        new Vector3(groundCheckWidth, 0.2f, 0f)
        );
    }
}
