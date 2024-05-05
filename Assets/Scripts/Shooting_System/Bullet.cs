using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float _force = 70f;
    [SerializeField] private float _damage = 1f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = _force * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IDeadable getDamage))
        {
            getDamage.GetDamage(_damage);
            HitTarget();
            return;
        }
    }

    private void HitTarget()
    {
        Destroy(gameObject);
    }
}
