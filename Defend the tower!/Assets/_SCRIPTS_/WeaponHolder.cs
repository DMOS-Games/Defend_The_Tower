using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WeaponHolder:MonoBehaviour
{
    public Image WeaponImage, WeaponDamage;
    public TextMeshProUGUI WeaponName, WeaponAmmo, WeaponCost;

    public void Destruct()
    {
        Destroy(gameObject);
    }

}
