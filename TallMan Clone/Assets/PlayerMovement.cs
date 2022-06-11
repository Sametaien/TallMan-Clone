#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xAxisSpeed;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal") * xAxisSpeed * Time.deltaTime;
        transform.Translate(x, 0, speed * Time.deltaTime);
    }
}