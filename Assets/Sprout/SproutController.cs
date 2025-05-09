using UnityEngine;
using UnityEngine.InputSystem;

public class SproutController : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float moveSpeed = 5f;
    
    private Camera cam;
    Rigidbody rb;

    private Vector3 destination;
    
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDirection = hit.point - transform.position;
                targetDirection.y = 0f; // prevent tilting up/down
                Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = lookRotation;
                
                destination = hit.point;
                destination.y = 0f;
                
                pointer.transform.position = destination;
            }
        }
        
        Vector3 direction = (destination - transform.position).normalized;
        direction.y = 0f;
        rb.linearVelocity = direction * moveSpeed;

        pointer.SetActive(Vector3.Distance(transform.position, destination) > 1f);
    }
}
