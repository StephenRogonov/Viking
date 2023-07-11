using UnityEngine;

public class RangeAttackDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<HealthCount>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
