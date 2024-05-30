using UnityEngine;

[CreateAssetMenu(fileName = "Collectable Object")]
public class CollectableItem : ScriptableObject
{
    public string Name;
    public int value;
    public GameObject ObjectPrefab;
}
