using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Controls : MonoBehaviour
{
    private AeroplaneController aircraft;
    private bool stopViewToggle = false;

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
        if (Input.GetAxis("Reset") > 0.0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetAxis("StopView") > 0.0)
        {
            if (!stopViewToggle)
            {
                stopViewToggle = true;
                aircraft.enabled = !aircraft.enabled;
                GetComponent<Rigidbody>().isKinematic = !aircraft.enabled;
            }
        }
        else
            stopViewToggle = false;
        aircraft.Move(roll, pitch, 0, throttle, false);
    }
}
