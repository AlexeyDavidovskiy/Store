using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    private Vector2 lookInput;
    private Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        ReadTouchInput();
        CameraRotation();
    }

    private void ReadTouchInput()
    {
        lookInput = Vector2.zero;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    lookInput = touch.deltaPosition * sensitivity * Time.deltaTime;
                }
            }
        }
    }

    private void CameraRotation()
    {
        if (lookInput.sqrMagnitude > 0.1f)
        {
            camTransform.Rotate(Vector3.up, lookInput.x, Space.World);
            camTransform.Rotate(Vector3.right, lookInput.y, Space.Self);
        }
    }
}
