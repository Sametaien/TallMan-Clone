#region

using UnityEngine;

#endregion

public class CameraFollow : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject target;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime);
    }
}