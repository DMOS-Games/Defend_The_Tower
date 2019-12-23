using UnityEngine;

public class DestroySelf : MonoBehaviour
{

    public float DestroyTime;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

}
