using UnityEngine;

[CreateAssetMenu(menuName = "Player Data/Helath")]
public  class DataScriptableObject : ScriptableObject
{
    public int _score;
    public int _health;
    public float _time;
    public string _name;

}
