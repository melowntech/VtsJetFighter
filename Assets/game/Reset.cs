using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Reset : MonoBehaviour
{
    private AeroplaneController aircraft;
    private bool stopViewToggle = false;

    private Vector3 initPos;
    private Quaternion initRot;

    private double initVtsX = 14.412332;
    private double initVtsY = 50.04945;
    private double initVtsZ = 1000;

    void Start()
    {
        aircraft = GetComponent<AeroplaneController>();
        initPos = transform.position;
        initRot = transform.rotation;
        Restart();
    }

    void Restart()
    {
        var map = FindObjectOfType<VtsMap>().gameObject;
        var m = map.AddComponent<VtsMapMakeLocal>();
        m.singleUse = true;
        m.x = initVtsX;
        m.y = initVtsY;
        m.z = initVtsZ;
        map.AddComponent<VtsRigidBodyActivate>().map = map;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Reset") > 0.0)
        {
            transform.position = initPos;
            transform.rotation = initRot;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            var a = gameObject.AddComponent<VtsRigidBodyActivate>();
            a.map = FindObjectOfType<VtsMap>().gameObject;
            Restart();
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
    }
}
