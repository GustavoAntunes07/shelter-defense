using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class SpeedUpgrade : MonoBehaviour, IUpgradeProvider
{
    [SerializeField] UpgradeSO currentUpgrade;
    Move m;

    private void Start()
    {
        m = GetComponent<Move>();
        if (currentUpgrade != null)
            SetUpgrade(currentUpgrade);
    }

    public void SetUpgrade(UpgradeSO upgrade)
    {
        if (upgrade.type == UpgradeTypeEnum.Velocidade)
        {
            currentUpgrade = upgrade;
            m.SetSpeedMultiplier(currentUpgrade.multi);
        }
        else
        {
            Debug.LogError($"Upgrade type must be Velocidade. Got {upgrade.type} instead.");
        }
    }

    public UpgradeSO GetCurrentUpgrade() => currentUpgrade;
}
