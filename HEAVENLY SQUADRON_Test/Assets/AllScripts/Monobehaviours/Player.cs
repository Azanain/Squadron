using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput { get; private set; }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

}
