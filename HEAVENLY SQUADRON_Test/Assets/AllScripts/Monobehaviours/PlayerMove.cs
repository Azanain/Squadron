using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Player player;
    private Move move;

    [Header("Move")]
    private Rigidbody _rb;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedManeuver;
    [SerializeField] private float _speedRotate;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        move = new Move();
        player = GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = player.playerInput.Player.Move.ReadValue<Vector3>();
        move.MovingRb(_rb, moveDirection, _speedMove, _speedRotate);

        move.RotateTo(_rb, moveDirection, _speedRotate);
    }
}
