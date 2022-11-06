using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Move move;
    private PoolObject poolObject;

    [SerializeField] private float _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _numberTargetLayer;
    [SerializeField] private float _lifeTime;
    private float _startLifeTime;

    private void Awake()
    {
        move = new Move();
        poolObject = GetComponent<PoolObject>();
        _startLifeTime = _lifeTime;
    }
    private void OnEnable()
    {
        _lifeTime = _startLifeTime;
    }
    private void Update()
    {
        move.MovingTransform(transform, Vector3.forward, _moveSpeed);

        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
            DestroyBullet();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _numberTargetLayer)
        {
            Enemy enemy = DataUnits.GetEnemy(other.name);
            enemy.TakeDamage(_damage);
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
    }
}
