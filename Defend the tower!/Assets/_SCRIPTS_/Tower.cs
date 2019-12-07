using UnityEngine.UI;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public Image HealthBar;

    public float Health;
    public float MaxHealth = 300;

    float fa;

    void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {
        fa = Health / MaxHealth;
        HealthBar.fillAmount = fa;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

}
