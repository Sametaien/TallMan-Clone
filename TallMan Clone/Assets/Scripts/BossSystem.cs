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
    private BossScript _bossScript;

    private void Start()
    {
        _bossScript = boss.GetComponent<BossScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _bossScript.bossMove = true;
        gates = portal.GetComponentsInChildren<Transform>().Where(x => x.name == "transparent").ToArray();

        if (other.CompareTag("Player"))
        {
            foreach (var gate in gates)
            {
                var gateSystem = gate.GetComponent<GateSystem>();

                if (gateSystem.type == GateSystem.GateSystemType.Positive)
                    bossHealth += (int) gateSystem.positiveValue;
            }

            _bossScript.bossHp = bossHealth * bossHpCalculatePercentage / 100;
            _bossScript.playerHeight = (int) other.GetComponent<PlayerMovement>().playerHealth;
            bossHealthText.text = _bossScript.bossHp + " HP";
        }
    }
}