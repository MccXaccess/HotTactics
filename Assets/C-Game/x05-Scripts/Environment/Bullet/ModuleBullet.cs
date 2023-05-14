using UnityEngine;

public class ModuleBullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce = 50f;
    [SerializeField] private float _bulletLifeTime = 5f;

    private void Update()
    {
        if (_bulletLifeTime <= 0.0f) { Destroy(gameObject); }
        else { _bulletLifeTime -= Time.deltaTime; transform.Translate(transform.up * _bulletForce * Time.deltaTime, Space.World); }
    }
}