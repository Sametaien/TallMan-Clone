#region

using UnityEngine;
using UnityEngine.Serialization;

#endregion

public class BossScript : MonoBehaviour
{
    public GameObject boss;
    [FormerlySerializedAs("bossHP")] public int bossHp;
    public int playerHeight;
    public GameObject losePanel;
    public GameObject winPanel;
    public bool bossMove;


    private void Update()
    {
        if (bossMove) transform.Translate(-Vector3.forward * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossMove = false;
            if (playerHeight <= bossHp)
                LoseGame(other.gameObject);
            else if (playerHeight > bossHp) WinGame(other.gameObject);
        }
    }

    private void WinGame(GameObject player)
    {
        boss.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void LoseGame(GameObject player)
    {
        player.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}