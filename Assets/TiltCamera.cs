using UnityEngine;
using UnityEngine.InputSystem;

public class TiltCamera : MonoBehaviour
{
    [SerializeField] private float maxTiltAngleVertical;
    [SerializeField] private float maxTiltAngleHorizontal;
    
    private float tiltAngleVertical;
    private float tiltAngleHorizontal;
    private float defaultAngleVertical;
    private float defaultAngleHorizontal;

    private InputAction mousePositionAction;
    
    void Start()
    {
        defaultAngleHorizontal = transform.eulerAngles.y;
        defaultAngleVertical = transform.eulerAngles.x;
        
        mousePositionAction = InputSystem.actions.FindAction("MousePosition");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = mousePositionAction.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
        mousePosition -= new Vector2(0.5f, 0.5f);
        
        tiltAngleVertical = mousePosition.y * maxTiltAngleVertical;
        tiltAngleHorizontal = mousePosition.x * maxTiltAngleHorizontal;
        
        var angles = transform.eulerAngles;
        
        angles.x = defaultAngleVertical - tiltAngleVertical;
        angles.y = defaultAngleHorizontal + tiltAngleHorizontal;
        
        transform.eulerAngles = angles;
    }
}
