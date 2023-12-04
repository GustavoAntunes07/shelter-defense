using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade1", menuName = "SOs/Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public UpgradeTypeEnum type;
    public int price;
    public float multi;
}
