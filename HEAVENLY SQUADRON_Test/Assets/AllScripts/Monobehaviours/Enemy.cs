using UnityEngine;
using TMPro;
using System.Collections;
using Zenject;
public class Enemy : MonoBehaviour
{
    private float _hp;
    private int _hits;
    private FindNearestTarget findNearestTarget;
    private Chasing chasing;
    private Move move;
    private Rigidbody _rb;
    [Inject] private Camera _camera;

    [SerializeField] private float _maxHp;
    [SerializeField] private float _moveSpeed;

    [Header("Chasing")]
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _timeCheckingNearestTargets;
    [SerializeField] private LayerMask _layers;
    [SerializeField] private TMP_Text _textMesh;
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _chasingDistance;
    [SerializeField] private float _delayChasing;
    private void Start()
    {
        findNearestTarget = new FindNearestTarget();
        chasing = new Chasing(_stopDistance, _chasingDistance);
        move = new Move();
        _rb = GetComponent<Rigidbody>();
        _textMesh.gameObject.SetActive(false);
        DataUnits.RegisterEnemy(this);
        _hp = _maxHp;
        StartCoroutine(CheckNearestTarget());
    }
    public void TakeDamage(float damage)
    {
        _hp -= damage;
        _textMesh.gameObject.SetActive(true);
        _hits++;
        _textMesh.text = _hits.ToString();

        if (_hp < 0)
            OnDie();
    }
    private IEnumerator DelayChasing()
    {
        yield return new WaitForSeconds(_delayChasing);
        move.MovingRb(_rb, findNearestTarget.NearestTarget.position - transform.position, _moveSpeed, _speedRotate);
        StartCoroutine(DelayChasing());
    }
    private IEnumerator CheckNearestTarget()
    {
        findNearestTarget.Find(transform, _chasingDistance, _layers);
        yield return new WaitForSeconds(_timeCheckingNearestTargets);

        if (findNearestTarget.TargetIsFinded)
            chasing.ChasingTarget(_rb, findNearestTarget.NearestTarget.position);

        StartCoroutine(CheckNearestTarget());
    }
    private void FixedUpdate()
    {
        if (chasing.Chaicing)
            StartCoroutine(DelayChasing());
        else
        {
            move.MovingRb(_rb, transform.position, 0, 0);
            StopCoroutine(DelayChasing());
        }
    }
    private void Update()
    {
        findNearestTarget.Find(transform, _chasingDistance, _layers);
        _textMesh.transform.LookAt(_camera.transform);
    }
    private void OnDie()
    {
        DataUnits.UnRegisterEnemy(name);
    }
}
