using PLAYERTWO.PlatformerProject;
using UnityEngine;

public abstract class Base_PlayerUpgradeSO : ScriptableObject
{
    [Header("IMPORTANT, GIVE A UNIQUE ID/NAME TO IT")]
    public string upgradeID = "example_upgrade_id";

    [Header("Upgrade Info")]
    public string upgradeName = "Example Name";
    [TextArea] public string upgradeDescription = "This is an example description";
    [Space]
    public int upgradeCost = 50;

    [Header("Upgrade Visuals")]
    public Sprite upgradeIcon;

    public void ApplyUpgrade(PlayerStats stats)
    {
        if (stats == null)
        {
            Debug.LogError("PlayerStats is null. Cannot apply health upgrade.");
            return;
        }

        Final_ApplyUpgrade(stats);
    }

    protected abstract void Final_ApplyUpgrade(PlayerStats stats);

    private void Reset()
    {
        upgradeID = $"example_upgrade_id_{Random.Range(0, 999)}";
    }
}