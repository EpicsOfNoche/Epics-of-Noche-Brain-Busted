using PLAYERTWO.PlatformerProject;
using UnityEngine;

[RequireComponent(typeof(Collectable))]
public class Coin : MonoBehaviour
{
    public string ID { get; private set; }
    private Collectable collectable;

    private void Awake()
    {
        collectable = GetComponent<Collectable>();
    }

    private void Start()
    {
        ID = GenerateID();
        if (Game.instance.ToData().levels[Game.instance.GetCurrentLevelIndex()].collectedCoins.Contains(ID)) CollectCoin();
    }

    private string GenerateID()
    {
        var pos = transform.position;
        return $"{gameObject.name}_{pos.x:F2}_{pos.y:F2}_{pos.z:F2}";
    }

    //CALLED BY COLLECTABLE EVENT, DO NOT CALL DIRECTLY
    public void Collect(int coinAmount)
    {
        var collectedCoinList = Game.instance.GetCurrentLevel().collectedCoins;
        if (!collectedCoinList.Contains(ID)) collectedCoinList.Add(ID);
    }

    private void CollectCoin()
    {
        gameObject.SetActive(false);
        //collectable.Collect(FindAnyObjectByType<Player>(), true);
    }
}