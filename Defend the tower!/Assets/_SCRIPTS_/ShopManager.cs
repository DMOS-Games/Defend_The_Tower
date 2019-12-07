using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot P_S;

    public GameObject WeaponHolder;

    public GameObject WeaponPanel;

    public Transform WeaponShop;

    public void WeaponsButton()
    {
        WeaponPanel.SetActive(true);
        GetWeapons();
    }

    public void Back()
    {

        for (int i = 0; i < WeaponShop.childCount; i++)
        {
            WeaponShop.GetChild(i).GetComponent<WeaponHolder>().Destruct();
        }

        WeaponPanel.SetActive(false);

    }

    void GetWeapons()
    {
        foreach (Weapon weapon in P_S.allWeapons)
        {
            WeaponHolder WH = Instantiate(WeaponHolder, WeaponShop).GetComponent<WeaponHolder>();
            WH.WeaponImage.sprite = weapon.sprite;
            WH.WeaponName.text = weapon.name;
            WH.WeaponDamage.fillAmount = weapon.Damage/100;
            WH.WeaponAmmo.text = weapon.CurrentAmmo + " / " + weapon.MaxAmmo;
            WH.WeaponCost.text = weapon.cost.ToString();
        }
    }

}
