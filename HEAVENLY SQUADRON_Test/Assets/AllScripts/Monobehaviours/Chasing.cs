using UnityEngine;
public class Chasing 
{
    public Chasing(float stopDistance, float chaiceDistance)
    {
        _stopDistance = stopDistance;
        _chaiceDistance = chaiceDistance;
    }
    private float _stopDistance;
    private float _chaiceDistance;
    public bool Chaicing { get; private set; }
    public void ChasingTarget(Rigidbody rb, Vector3 targetPosition)
    {
        float distance = Vector3.Distance(rb.position, targetPosition);

        if (distance <= _chaiceDistance && distance >= _stopDistance)
            Chaicing = true;
        else if (distance < _stopDistance)
            Chaicing = false;
    }
}
