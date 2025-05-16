using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TiltCamera : MonoBehaviour
{
    private bool locked = false;
    
    [SerializeField] private float maxTiltAngleVertical;
    [SerializeField] private float maxTiltAngleHorizontal;
    
    [SerializeField] private GameObject cam;
    [SerializeField] private float slideValue;
    private float cameraSlideTarget;
    
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
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(!locked ? angles : new Vector3(40, -100, 0)), Time.deltaTime * 3f);

        cameraSlideTarget = locked ? slideValue : 0;
        
        var vector3 = cam.transform.localPosition;
        vector3.x = Mathf.Lerp(cam.transform.localPosition.x, cameraSlideTarget, Time.deltaTime * 3f);
        cam.transform.localPosition = vector3;
    }

    public void ToggleSlide(bool b)
    {
        locked = b;
    }
}
