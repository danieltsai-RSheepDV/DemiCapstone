using UnityEngine;
using UnityEngine.InputSystem;

public class SproutController : MonoBehaviour
{
    public static bool CanMove = true;

    public static void SetCanMove(bool b)
    {
        CanMove = b;
    }
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pointer;
    [SerializeField] private float moveSpeed = 5f;
    
    private Camera cam;
    Rigidbody rb;

    private Vector3 destination;
    private Quaternion lookRotation;

    private bool walking = false;
    
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        lookRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && CanMove)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDirection = hit.point - transform.position;
                targetDirection.y = 0f; // prevent tilting up/down
                lookRotation = Quaternion.LookRotation(targetDirection);
                
                destination = hit.point;
                destination.y = 0f;
                
                pointer.transform.position = destination;
                walking = true;
            }
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
        
        Vector3 direction = (destination - transform.position).normalized;
        direction.y = 0f;

        if (walking)
        {
            Debug.Log("walking");
            rb.linearVelocity = direction * moveSpeed + Vector3.up * rb.linearVelocity.y;
            if (Vector3.Distance(transform.position, destination) < 2f)
            {
                walking = false;
            }
        }

        animator.SetFloat(Speed, Mathf.Abs(rb.linearVelocity.magnitude) / moveSpeed, 0.1f, Time.deltaTime);

        pointer.SetActive(Vector3.Distance(transform.position, destination) > 2f);
    }
}
