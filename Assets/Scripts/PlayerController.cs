using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public PlayerInput playerInput;

    [Header("Interaction Settings")]
    public Button radarButton;
    public Vector2 moveInputX;
    public Vector2 moveInputY;
    public Vector2 moveInput;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
        private void FixedUpdate()
    {
        // mouvement horizontal
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed).normalized;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (context.canceled)
            moveInput = Vector2.zero;
    }

}
