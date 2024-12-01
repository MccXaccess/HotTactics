using UnityEngine;

public class ModuleBullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce = 50f;
    [SerializeField] private float _bulletLifeTime = 5f;
    [SerializeField] private float _bulletDamage = 25.0f;
    [SerializeField] private GameObject _bulletEntityParticle;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_bulletLifeTime <= 0.0f) { Destroy(gameObject); }

        rb.velocity = transform.up * _bulletForce;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision != null)
        {
            Debug.Log("HIT");

            if (collision.collider.CompareTag("Enemy"))
            {
                Debug.Log("HIT ENEMY");
                Instantiate(_bulletEntityParticle, transform.position, Quaternion.identity);
                collision.collider.GetComponent<ModuleHealthEnemy>().TakeDamage(_bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}