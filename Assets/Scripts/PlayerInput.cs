using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 moveInput;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetMoveInput() => moveInput;
}
