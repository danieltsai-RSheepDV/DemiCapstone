using UnityEngine;
using UnityEngine.InputSystem;

public class SproutController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveAcceleration = 5f;
    
    private Camera cam;
    Rigidbody rb;
    
    InputAction moveAction;
    
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        
        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        camRight.Normalize();
        
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();
        
        Vector3 newVelocity = camRight * (moveSpeed * moveVector.x) + camForward * (moveVector.y * moveSpeed);
        newVelocity.y = rb.linearVelocity.y;
        
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, newVelocity, Time.deltaTime * moveAcceleration);
    }
}
