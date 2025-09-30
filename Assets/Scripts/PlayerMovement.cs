using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput playerInput;

    private Vector3 moveDirection;
    public Vector3 MoveDirection => moveDirection;

    private void Update()
    {
        ReadInput();
        Movement();
        Rotation();
    }

    private void ReadInput() 
    {
        Vector2 input = playerInput.GetMoveInput();
        moveDirection = new Vector3(input.x, 0, input.y);
    }

    private void Movement() 
    {
        if(moveDirection.magnitude > 0.1f) 
        {
            Vector3 move = moveDirection.normalized * moveSpeed * Time.deltaTime;
            characterController.Move(move);
        }
    }

    private void Rotation() 
    {
        if(moveDirection.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
