using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public UpgradeItemUIConfig config;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI currentMultiText;
    public TextMeshProUGUI nextMultiText;
    public TextMeshProUGUI priceText;
    public Button buyBtn;

    private void Start()
    {
        buyBtn.onClick?.AddListener(Buy);
    }

    public void SetConfig(UpgradeItemUIConfig c)
    {
        config = c;
        titleText.SetText(config.upgradeRef.type.ToString());
        currentMultiText.SetText($"ATUAL: {config.currentMulti:F2}");
        nextMultiText.SetText($"PROXIMO: {config.upgradeRef.multi:F2}");
        priceText.SetText($"{config.upgradeRef.price} MOEDAS");
    }

    public void Buy()
    {
        FindObjectOfType<UpgradeManager>().Buy(config.upgradeRef);
    }
}

[System.Serializable]
public class UpgradeItemUIConfig
{
    public UpgradeSO upgradeRef;
    public float currentMulti;

    public UpgradeItemUIConfig(UpgradeSO up, float m)
    {
        upgradeRef = up;
        currentMulti = m;
    }
}