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
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
        private void FixedUpdate()
    {
        // mouvement horizontal
        rb.linearVelocity = new Vector2(moveInputX.x * moveSpeed, moveInputY.y * moveSpeed).normalized;
    }
}
