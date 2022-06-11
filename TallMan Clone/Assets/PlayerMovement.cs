#region

using System;
using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xAxisSpeed;
    public float playerHealth = 0;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal") * xAxisSpeed * Time.deltaTime;
        transform.Translate(x, 0, speed * Time.deltaTime);
        //Debug.Log(playerHealth);
    }
    
    public void Health(float hp)
    {
        playerHealth += hp;
    }
    
}