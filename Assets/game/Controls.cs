using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Controls : MonoBehaviour
{
    private AeroplaneController aircraft;

    public float mouseSensitivity = 3;
    public float throttle = 1;
    
    void Start()
    {
        aircraft = GetComponent<AeroplaneController>();
    }

    void FixedUpdate()
    {
        float roll = 0;
        float pitch = 0;
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        throttle += Input.GetAxis("Mouse ScrollWheel") * 100;
        throttle = Mathf.Clamp(throttle, -1, 1);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            roll = Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        else
        {
            roll = Input.GetAxis("Horizontal");
            pitch = Input.GetAxis("Vertical");
        }
        aircraft.Move(roll, pitch, 0, throttle, false);
    }
}
