using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Idle/Resource")]
public class Resource : ScriptableObject
{
    public string resourceName;
    public int amount;
    public int resourceHP;
}
