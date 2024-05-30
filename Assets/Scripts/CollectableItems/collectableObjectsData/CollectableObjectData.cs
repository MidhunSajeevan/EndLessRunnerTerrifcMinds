using UnityEngine;


[CreateAssetMenu(menuName = "CollectableObjects/Item")]
public class CollectableObjectData : ScriptableObject
{
    public int amount;
    public string ItemName;
}
