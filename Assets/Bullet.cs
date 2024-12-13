using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    public void SetTarget(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * bulletSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

}
