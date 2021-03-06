#region

using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

#endregion

public class GateSystem : MonoBehaviour
{
    public Transform player;
    public GameObject Player;
    public TMP_Text text;
    public float positiveValue;
    public float negativeValue;
    public SpriteRenderer spriteRenderer;

    public Color PositiveColor = Color.blue;
    public Color NegativeColor = Color.red;
    [FormerlySerializedAs("_state")] public GateSystemState state = GateSystemState.Default;
    [FormerlySerializedAs("_type")] public GateSystemType type = GateSystemType.Positive;
    private PlayerMovement _playerMovement;

    public enum GateSystemState
    {
        Default,
        Taller,
        Shorter,
        Fat
    }

    public enum GateSystemType
    {
        Positive,
        Negative
    }


    private void Start()
    {
        _playerMovement = Player.GetComponent<PlayerMovement>();
        RandomNegativeValue();
        RandomPositiveValue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            switch (state)
            {
                case GateSystemState.Default:
                    state = GateSystemState.Default;
                    break;
                case GateSystemState.Taller:
                    state = GateSystemState.Taller;
                    MakeTaller(positiveValue);
                    _playerMovement.Health(positiveValue);
                    spriteRenderer.color = PositiveColor;
                    Debug.Log("Player is taller");
                    break;
                case GateSystemState.Shorter:
                    state = GateSystemState.Shorter;
                    MakeShorter(negativeValue);
                    _playerMovement.Health(negativeValue);
                    Debug.Log("Player is shorter");
                    break;
                case GateSystemState.Fat:
                    state = GateSystemState.Fat;
                    MakeFat(positiveValue);
                    break;
            }
    }


    private void RandomNegativeValue()
    {
        negativeValue = Random.Range(-1, -5);
        if (GateSystemType.Negative == type)
        {
            text.text = negativeValue.ToString();
            spriteRenderer.color = NegativeColor;
        }
    }

    private void RandomPositiveValue()
    {
        positiveValue = Random.Range(1, 5);
        if (GateSystemType.Positive == type)
        {
            text.text = positiveValue.ToString();
            spriteRenderer.color = PositiveColor;
        }
    }


    private void MakeTaller(float positiveValue)
    {
        player.transform.localScale += new Vector3(0, positiveValue, 0);
    }

    private void MakeShorter(float negativeValue)
    {
        if (player.localScale.y + negativeValue < 1) negativeValue = -player.localScale.y + 1;
        player.transform.localScale += new Vector3(0, negativeValue, 0);
    }

    private void MakeFat(float positiveValue)
    {
        player.transform.localScale += new Vector3(positiveValue, 0, 0);
    }
}