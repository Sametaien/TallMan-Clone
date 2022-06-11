using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject boss;
    public int bossHP = 0;
    public int playerHeight;
    public GameObject losePanel;
    public GameObject winPanel;
    public bool bossMove = false;
    


    private void Update()
    {
        if (bossMove)
        {
            transform.Translate(-Vector3.forward* Time.deltaTime);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossMove = false;
            if (playerHeight <= bossHP)
            {
                LoseGame(other.gameObject);
            }
            else if (playerHeight > bossHP)
            {
                WinGame(other.gameObject);
            }
        }
    }

    private void WinGame(GameObject player)
    {
        Destroy(boss);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void LoseGame(GameObject player)
    {
        Destroy(player);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
