using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public PlayerInput playerInput;
    public Vector2 moveInput;
    public Button buttonInteract;
    IInteractable interact;
    bool canInteract;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Radar radar;

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
    public void OnInteractButton()
    {
        if(canInteract)
        {
            interact.OnInteract();
        }
        else
        {
            radar.UseRadar();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        interact = collision.GetComponent<IInteractable>();

        if(interact != null)
        {
           canInteract = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        interact = collision.GetComponent<IInteractable>();
        if(interact != null)
        {
           canInteract = false;
        }
    }
}
