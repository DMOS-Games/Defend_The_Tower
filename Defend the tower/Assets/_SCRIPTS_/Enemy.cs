using UnityEngine;

public enum EnemyType { Ranged, Melee }

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    public float Vita;

    public float Speed = 1.2f;

    public float StopDistance = 2.4f;

    public float Damage;

    public float AttackRate;
    float NextTimeToAttack = 0;

    public int Money;

    Rigidbody2D rb;

    bool IsDead;

    float Distance;

    Transform tower;

    Tower torre;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tower = GameObject.FindWithTag("Tower").transform;
        torre = tower.GetComponent<Tower>();

    }

    void Update()
    {

        Distance = Vector3.Distance(transform.position, tower.position);

        //movimento
        if (!IsDead)
        {

            if (Vita <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
                return;
            }

            if (Distance > StopDistance)
            {
                rb.position = transform.position + (Vector3.left * Speed * Time.fixedDeltaTime);
            }
            else
            {
                if(Time.time >= NextTimeToAttack)
                {
                    NextTimeToAttack = Time.time + 1 / AttackRate;
                    Attack();
                }
            }

        }

    }

    public void TakeDamage(float Damage)
    {
        Vita -= Damage;
    }

    void Attack()
    {
        torre.TakeDamage(Damage);
    }

    void Die()
    {
        Destroy(gameObject);
        GameManager.manager.AddMoney(Money);
    }

}
