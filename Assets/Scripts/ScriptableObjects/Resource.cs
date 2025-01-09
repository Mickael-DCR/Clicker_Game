using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Idle/Resource")]
public class Resource : ScriptableObject
{
    public string ResourceName;
    public int AmountOnKill;
    public float ResourceHP;
    public Rarity Rarity;
    public Sprite Sprite;
}
