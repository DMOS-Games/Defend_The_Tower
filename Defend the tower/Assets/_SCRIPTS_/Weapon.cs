using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    public Sprite sprite;

    public int CurrentAmmo;
    public int MaxAmmo;

    public float Damage;
    public float FireRate;

    public int cost;

    public bool IsUnlocked;

}
