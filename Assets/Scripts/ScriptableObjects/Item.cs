using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Idle/Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public bool AutoClick;
    public int UpgradePower;
    public TypeOfUpgrade UpgradeType;
    public string Description;
    public int Price;
    public TypeOfResource ResourceType;
}
