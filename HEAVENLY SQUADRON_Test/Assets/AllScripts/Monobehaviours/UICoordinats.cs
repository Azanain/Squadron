using UnityEngine;
using UnityEngine.UI;

public class UICoordinats : MonoBehaviour
{
    [SerializeField] private Text[] _coordinats;
    [SerializeField] private Text _shoots;

    [SerializeField] private Transform _playerTransform;

    private uint _numberShoots;

    public void Update()
    {
        _coordinats[0].text = _playerTransform.position.x.ToString("#.##");
        _coordinats[1].text = _playerTransform.position.y.ToString("#.##");
        _coordinats[2].text = _playerTransform.position.z.ToString("#.##");
    }
    public void UpdateTextShoots()
    {
        _numberShoots++;
        _shoots.text = "shoots:" + "\n"
            +_numberShoots;
    }
}
