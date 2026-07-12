using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string _name;
    public int _amount;
    public string _description;
    public enum ItemType { consumable, equippable};
    public ItemType _type;
    public Sprite _icon;
}
