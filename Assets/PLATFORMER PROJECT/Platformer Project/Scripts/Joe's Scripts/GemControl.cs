using UnityEngine;

public class GemControl : MonoBehaviour
{
    [SerializeField] int rotateSpeed = 2;
    [SerializeField] AudioSource gemCollect;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        gemCollect.Play();
        Destroy(gameObject);
    }
}
