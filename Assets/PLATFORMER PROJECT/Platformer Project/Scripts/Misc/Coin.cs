using PLAYERTWO.PlatformerProject;
using UnityEngine;

[RequireComponent(typeof(Collectable))]
public class Coin : MonoBehaviour
{
    public string ID { get; private set; }

    public Game m_game => Game.instance;

    private void Start()
    {
        ID = GenerateID();
        if (m_game.GetCurrentLevel().collectedCoins.Contains(ID)) CollectCoin();
    }

    private string GenerateID()
    {
        var pos = transform.position;
        return $"{gameObject.name}_{m_game.GetCurrentLevel().name}_{pos.x:F2}_{pos.y:F2}_{pos.z:F2}";
    }

    //CALLED BY COLLECTABLE EVENT, DO NOT CALL DIRECTLY
    public void Collect()
    {
        var collectedCoinList = m_game.GetCurrentLevel().collectedCoins;
        if (!collectedCoinList.Contains(ID)) collectedCoinList.Add(ID);
    }

    private void CollectCoin()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}