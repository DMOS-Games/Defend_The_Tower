using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int Money;

    public float MoneyMultiplier;

    public int BonusMoney;

    public TextMeshProUGUI MoneyTXT;

    public Transform EnemyParent;

    public GameObject ShopUI;

    public static GameManager manager;
    WaveSpawner spawner;

    void Awake()
    {
        if (manager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
            spawner = GetComponent<WaveSpawner>();
        }
    }

    public void Update()
    {
        MoneyTXT.text = Money.ToString() + " $";
    }

    public void AddMoney(int m)
    {
        Money += Mathf.FloorToInt(m * MoneyMultiplier);
    }

    public void IncreaseMultiplier()
    {
        MoneyMultiplier *= 1.15f;
    }

    public void SpawnButton()
    {

        if(EnemyParent.childCount != 0)
        {
            AddMoney(Mathf.FloorToInt(BonusMoney * MoneyMultiplier));
        }

        spawner.CallSpawnWave();
    }

    public void ShopButton()
    {
        if(ShopUI.activeSelf)
        {
            ShopUI.SetActive(false);
        }
        else
        {
            ShopUI.SetActive(true);
        }
    }

}
