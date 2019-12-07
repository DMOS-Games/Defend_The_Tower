using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Camera MainCamera;

    public Weapon[] weapons;
    public Weapon[] allWeapons;

    Weapon CurrentWeapon;

    int CurrentMaxAmmo;
    int CurrentAmmo;

    float CurrentDamage;

    Transform target;

    void Start()
    {

        CurrentWeapon = weapons[0];

        CurrentMaxAmmo = CurrentWeapon.MaxAmmo;
        CurrentAmmo = CurrentWeapon.CurrentAmmo;
        CurrentDamage = CurrentWeapon.Damage;
    }

    void Update()
    {

        #region Input

#if UNITY_ANDROID || UNITY_IOS
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Vector3 TouchPos = MainCamera.ScreenToWorldPoint(touch.position);
                Vector2 TouchPos2D = new Vector2(TouchPos.x, TouchPos.y);

                RaycastHit2D hit = Physics2D.Raycast(TouchPos2D, Vector3.zero);

                if(hit.transform != null)
                {
                    target = hit.transform;
                    Shoot();
                }
            }
        }
#else
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(MousePos.x, MousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(MousePos2D, Vector3.zero);

            if (hit.transform != null)
            {
                target = hit.transform;
                Shoot();
            }
        }
#endif

        #endregion

    }

    void Shoot()
    {

        if (target.transform != null)
        {
            if (target.tag == "Enemy")
            {
                target.GetComponent<Enemy>().TakeDamage(CurrentDamage);
            }
        }

    }

}
