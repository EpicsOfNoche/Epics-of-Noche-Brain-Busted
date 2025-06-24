using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public string ID { get; private set; }

    private void Start()
    {
        ID = GenerateID();
        if (Game.instance.ToData().levels[Game.instance.GetCurrentLevelIndex()].collectedCoins.Contains(ID))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private string GenerateID()
    {
        var pos = transform.position;
        return $"{gameObject.scene.name}_{pos.x:F2}_{pos.y:F2}_{pos.z:F2}";
    }

    public void Collect()
    {
        Game.instance.ToData().levels[Game.instance.GetCurrentLevelIndex()].collectedCoins.Add(ID);
    }
}