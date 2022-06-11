#region

using System.Linq;
using TMPro;
using UnityEngine;

#endregion

public class BossSystem : MonoBehaviour
{
    public Transform[] gates;
    public GameObject portal;
    public GameObject boss;
    public int bossHealth;
    public TextMeshProUGUI bossHealthText;
    public int bossHpCalculatePercentage = 50;
    private BossScript bossScript;

    private void Start()
    {
        bossScript = boss.GetComponent<BossScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bossScript.bossMove = true;
        gates = portal.GetComponentsInChildren<Transform>().Where(x => x.name == "transparent").ToArray();
        
        if (other.CompareTag("Player"))
        {
            foreach (var gate in gates)
            {
                var gateSystem = gate.GetComponent<GateSystem>();
                
                if (gateSystem._type == GateSystem.GateSystemType.Positive)
                {
                    bossHealth += (int)gateSystem.positiveValue;
                }
            }
            bossScript.bossHP = bossHealth * bossHpCalculatePercentage / 100;
            bossScript.playerHeight = (int)other.GetComponent<PlayerMovement>().playerHealth;
            bossHealthText.text = bossScript.bossHP + " HP";
        }
    }
}