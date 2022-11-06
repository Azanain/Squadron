using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private FindNearestTarget findNearestTarget;
    private Pool pool;
    private Player player;
    [SerializeField] private UICoordinats uICoordinats;

    [Header("Find nearest targets")]
    [Range(0, 1)] [SerializeField] private float _timeCheckingNearestTargets;
    [SerializeField] private float _radiusSphereCheaking;
    [SerializeField] private LayerMask layers;
    [SerializeField] private float _speedRotateGun;
    [SerializeField] private Transform _gun;

    [Header("DealDamage")]
    [SerializeField] private Transform _firePosition;
    [SerializeField] private float _timeReloadShoot;

    [HideInInspector] public Vector3 _cursorDirection;

    private void Start()
    {
        player = GetComponent<Player>();
        player.playerInput.Player.Shoot.performed += context => Shoot();
        pool = GetComponent<Pool>();
        findNearestTarget = new FindNearestTarget();
        StartCoroutine(CheckNearestTarget());
    }
    private IEnumerator CheckNearestTarget()
    {
        findNearestTarget.Find(_gun.transform, _radiusSphereCheaking, layers);
        yield return new WaitForSeconds(_timeCheckingNearestTargets);

        if (findNearestTarget.TargetIsFinded)
            RotateGunToTarget();
        else
            RotateToCursor();

        StartCoroutine(CheckNearestTarget());
    }
    private void RotateGunToTarget()
    {
        Vector3 direction = findNearestTarget.NearestTarget.position - _gun.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _gun.transform.rotation = Quaternion.Lerp(_gun.transform.rotation, rotation, _speedRotateGun * Time.deltaTime);
    }
    public void RotateToCursor()
    {
        Vector3 direction = _cursorDirection - _gun.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _gun.transform.rotation = Quaternion.Lerp(_gun.transform.rotation, rotation, _speedRotateGun * Time.deltaTime);
    }
    private void Shoot()
    {     
        pool.GetFreeElement(_firePosition.position, _firePosition.rotation);
        uICoordinats.UpdateTextShoots();
    }
}
