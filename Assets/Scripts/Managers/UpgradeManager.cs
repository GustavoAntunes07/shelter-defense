using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CurrencyManager))]
public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeSO> upgrades;
    public UpgradeItemUI upItem;
    public string upgradesTag = "Upgrades";
    public SpeedUpgrade speed;
    public DamageUpgrade damage;
    public HealingUpgrade heal;
    public HealthUpgrade hp;
    public ProfitUpgrade p;

    CurrencyManager currency;
    GameObject upgradesUiObj;

    IUpgradeProvider[] provs;

    private void Start()
    {
        currency = GetComponent<CurrencyManager>();

        if (speed == null)
            speed = FindObjectOfType<SpeedUpgrade>().GetComponent<SpeedUpgrade>();

        if (damage == null)
            damage = FindObjectOfType<DamageUpgrade>().GetComponent<DamageUpgrade>();

        if (heal == null)
            heal = FindObjectOfType<HealingUpgrade>().GetComponent<HealingUpgrade>();

        if (hp == null)
            hp = FindObjectOfType<HealthUpgrade>().GetComponent<HealthUpgrade>();

        if (p == null)
            p = FindObjectOfType<ProfitUpgrade>().GetComponent<ProfitUpgrade>();

        upgradesUiObj = GameObject.FindGameObjectWithTag(upgradesTag);

        provs = new IUpgradeProvider[] { speed, damage, heal, hp, p };

        Populate();
    }

    public void Populate()
    {
        foreach (Transform child in upgradesUiObj.transform)
            Destroy(child.gameObject);

        foreach (var prov in provs)
        {
            var up = GetNextUpgrade(prov);
            if (up != null)
                Instantiate(upItem, upgradesUiObj.transform)
                    .SetConfig(new UpgradeItemUIConfig(up, prov.GetCurrentUpgrade().multi));
        }
    }

    public UpgradeSO GetNextUpgrade(IUpgradeProvider provider)
    {
        return upgrades.FirstOrDefault(
            item => item.multi > provider.GetCurrentUpgrade().multi && item.type == provider.GetCurrentUpgrade().type
        );
    }

    public void Buy(UpgradeSO up)
    {
        if (currency.SpendCoins(up.price) == "success")
        {
            foreach (var prov in provs)
                if (prov.GetCurrentUpgrade().type == up.type)
                    prov.SetUpgrade(up);

            Populate();
        }
    }
}

public enum UpgradeTypeEnum
{
    Velocidade,
    Dano,
    Vida,
    Cura,
    Lucro,
}

public interface IUpgradeProvider
{
    public void SetUpgrade(UpgradeSO upgrade);
    public UpgradeSO GetCurrentUpgrade();
}