using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        RunAnimation(playerMovement.MoveDirection);
    }

    private void RunAnimation(Vector3 direction) 
    {
        if(direction != Vector3.zero) 
        {
            animator.SetBool("IsRunning", true);
        }
        else 
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
