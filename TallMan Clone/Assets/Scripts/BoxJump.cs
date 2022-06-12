#region

using DG.Tweening;
using UnityEngine;

#endregion

public class BoxJump : MonoBehaviour
{
    public Transform jumpTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) other.transform.DOJump(jumpTarget.position, 7, 1, 5f);
    }
}