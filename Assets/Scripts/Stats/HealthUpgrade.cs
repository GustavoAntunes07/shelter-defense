using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class HealthUpgrade : MonoBehaviour, IUpgradeProvider
{
    [SerializeField] UpgradeSO currentUpgrade;
    HealthSystem hp;

    private void Start()
    {
        hp = GetComponent<HealthSystem>();

        if (currentUpgrade != null)
            SetUpgrade(currentUpgrade);
    }

    public void SetUpgrade(UpgradeSO upgrade)
    {
        if (upgrade.type == UpgradeTypeEnum.Vida)
        {
            currentUpgrade = upgrade;
            hp.SetHealthMulti(currentUpgrade.multi);
        }
    }

    public UpgradeSO GetCurrentUpgrade() => currentUpgrade;
}
