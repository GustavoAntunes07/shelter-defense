using UnityEngine;

[RequireComponent(typeof(ProjectileShooter))]
public class DamageUpgrade : MonoBehaviour, IUpgradeProvider
{
    [SerializeField] UpgradeSO current;
    ProjectileShooter shooter;

    private void Start()
    {
        shooter = GetComponent<ProjectileShooter>();
        if (current != null)
            SetUpgrade(current);
    }

    public void SetUpgrade(UpgradeSO upgrade)
    {
        if (upgrade.type == UpgradeTypeEnum.Dano)
        {
            current = upgrade;
            shooter.SetDamageMultiplier(current.multi);
        }
        else
        {
            Debug.LogError($"Upgrade type must be Dano. Got {upgrade.type} instead.");
        }
    }

    public UpgradeSO GetCurrentUpgrade() => current;
}