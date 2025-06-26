using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class DeleteThis_Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) Game.instance.AddTotalCoins(3);
    }
}