using UnityEngine;

public class DestroyImmediately : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject);
    }
}
