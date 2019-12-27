using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WeaponHolder:MonoBehaviour
{
    public Image WeaponImage, WeaponDamage;
    public TextMeshProUGUI WeaponName, WeaponAmmo, WeaponCost;

    public Button BuyButton;

    public GameObject Instantiate(Weapon weapon)
    {
        WeaponImage.sprite = weapon.sprite;
        WeaponName.text = weapon.name;
        WeaponDamage.fillAmount = weapon.Damage / 100;
        WeaponAmmo.text = weapon.CurrentAmmo + " / " + weapon.MaxAmmo;
        WeaponCost.text = weapon.cost.ToString();

        BuyButton.onClick.AddListener(() => WButton(weapon));

        return gameObject;

    }

    void WButton(Weapon weapon)
    {
        int indx = PlayerShoot.instance.ToBuyWeapons.IndexOf(weapon);
        ShopManager.manager.BuyWeapon(weapon, ShopManager.manager.WeaponShops[indx]);
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

}
