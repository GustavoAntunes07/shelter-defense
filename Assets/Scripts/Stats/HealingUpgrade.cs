using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class HealingUpgrade : MonoBehaviour, IUpgradeProvider
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
        if (upgrade.type == UpgradeTypeEnum.Cura)
        {
            currentUpgrade = upgrade;
            hp.SetHealingMulti(currentUpgrade.multi);
        }
    }

    public UpgradeSO GetCurrentUpgrade() => currentUpgrade;
}