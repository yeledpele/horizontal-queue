using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC Data", order = 51)]
public class NpcData : ScriptableObject
{
    public Sprite image;
    public Sprite icon;
    public float annoyance;
    public float speed;
    public float strength;
    public bool isPlayer = false;  
}
