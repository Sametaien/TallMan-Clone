#region

using System;
using TMPro;
using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xAxisSpeed;
    public float playerHealth;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal") * xAxisSpeed * Time.deltaTime;
        transform.Translate(x, 0, speed * Time.deltaTime);
        //Debug.Log(playerHealth);
    }

    private void FixedUpdate()
    {
        healthText.text = playerHealth+ " HP";
    }

    public void Health(float hp)
    {
        playerHealth += hp;
    }
}