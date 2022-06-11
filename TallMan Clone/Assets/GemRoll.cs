#region

using UnityEngine;

#endregion

public class GemRoll : MonoBehaviour
{
    public float speed = 50f;

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}