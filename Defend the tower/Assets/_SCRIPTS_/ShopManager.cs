using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot P_S;

    public GameObject WeaponHolder;

    public GameObject WeaponPanel;

    public List<GameObject> WeaponShops = new List<GameObject>();

    public Transform WeaponShop;

    public static ShopManager manager;

    private void Start()
    {
        if(manager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
        }
    }

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
        foreach (Weapon weapon in P_S.ToBuyWeapons)
        {
            WeaponShops.Add(Instantiate(WeaponHolder, WeaponShop).GetComponent<WeaponHolder>().Instantiate(weapon));
        }
    }

    public void BuyWeapon(Weapon weapon, GameObject go)
    {
        if(GameManager.manager.Money >= weapon.cost)
        {
            GameManager.manager.Money -= weapon.cost;
            P_S.ToBuyWeapons.Remove(weapon);
            P_S.MyWeapons.Add(weapon);
            WeaponShops.Remove(go);
            go.GetComponent<WeaponHolder>().Destruct();
        }
    }

}
