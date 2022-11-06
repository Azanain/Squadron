using UnityEngine;

public class PlayerWiev : MonoBehaviour
{
    private Gun gun;

    [SerializeField] private Camera _camera;
    [SerializeField] private float randgeWiev;

    private void Awake()
    {
        gun = GetComponent<Gun>();
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, randgeWiev))
        {
            gun._cursorDirection = hit.point;
        }
    }
}
