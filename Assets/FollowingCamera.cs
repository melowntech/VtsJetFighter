using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject target;

    public Vector3 targetOffset;

    private void Start()
    {
        transform.position = target.transform.position + transform.rotation * targetOffset;
        transform.rotation = target.transform.rotation;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + transform.rotation * targetOffset, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.1f);
    }
}
