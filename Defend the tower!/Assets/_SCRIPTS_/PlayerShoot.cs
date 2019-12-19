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
    public Transform Gun;

    public AudioClip[] clips;

    public ParticleSystem VFX;

    public GameObject BulletAudioPrefab;

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

       //VFX.Stop();

    }

}
