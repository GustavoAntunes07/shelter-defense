using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitUpgrade : MonoBehaviour, IUpgradeProvider
{
    [SerializeField] UpgradeSO currentUpgrade;
    CurrencyManager c;

    private void Start()
    {
        c = GetComponent<CurrencyManager>();

        if (currentUpgrade != null)
            SetUpgrade(GetCurrentUpgrade());
    }

    public void SetUpgrade(UpgradeSO upgrade)
    {
        if (upgrade.type == UpgradeTypeEnum.Lucro)
        {
            currentUpgrade = upgrade;
            c.SetProfitMulti(currentUpgrade.multi);
        }
    }

    public UpgradeSO GetCurrentUpgrade() => currentUpgrade;
}
