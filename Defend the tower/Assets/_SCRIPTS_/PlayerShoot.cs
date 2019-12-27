using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{

    public Camera MainCamera;

    public List<Weapon> MyWeapons = new List<Weapon>();
    public List<Weapon> ToBuyWeapons = new List<Weapon>();

    Weapon CurrentWeapon;

    int CurrentMaxAmmo;
    int CurrentAmmo;

    float CurrentDamage;

    Transform target;
    public Transform Gun;

    public AudioClip[] clips;

    public ParticleSystem VFX;

    public GameObject BulletAudioPrefab;

    int idx = 0;

    public static PlayerShoot instance;

    void Start()
    {

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        SetWeapon(0);
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

                Shoot();
                Gun.LookAt(TouchPos2D);

                if (hit.transform != null)
                {
                    target = hit.transform;
                }
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(MousePos.x, MousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(MousePos2D, Vector3.zero);

            Shoot();
            Gun.LookAt(MousePos2D);

            if (hit.transform != null)
            {
                target = hit.transform;
            }
        }
#endif

        #endregion

    }

    void Shoot()
    {

        VFX.Play();
        AudioSource GS = Instantiate(BulletAudioPrefab, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        GS.clip = clips[Random.Range(0, clips.Length)];
        GS.Play();

        if (target != null)
        {
            if (target.tag == "Enemy")
            {
                target.GetComponent<Enemy>().TakeDamage(CurrentDamage);
            }
        }

    }


    public void SwapWeapon()
    {

        idx++;

        if(idx  >= MyWeapons.Count)
        {
            idx = 0;
        }

        SetWeapon(idx);

    }

    void SetWeapon(int i)
    {
        CurrentWeapon = MyWeapons[i];

        CurrentMaxAmmo = CurrentWeapon.MaxAmmo;
        CurrentAmmo = CurrentWeapon.CurrentAmmo;
        CurrentDamage = CurrentWeapon.Damage;
    }

}
