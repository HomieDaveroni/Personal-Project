using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite icon;

    public string ItemName => itemName;
    public Sprite Icon => icon;
}