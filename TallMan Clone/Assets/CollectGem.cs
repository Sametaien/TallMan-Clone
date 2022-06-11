#region

using TMPro;
using UnityEngine;

#endregion

public class CollectGem : MonoBehaviour
{
    public int gemsCollected;
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            gemsCollected = gemsCollected + 1;
            other.gameObject.SetActive(false);
            coinText.text = "Gems: " + gemsCollected;
        }
    }
}