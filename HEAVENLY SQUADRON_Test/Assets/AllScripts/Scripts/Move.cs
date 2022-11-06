using UnityEngine;

public class Move
{
    public void MovingRb(Rigidbody rb, Vector3 direction, float moveSpeed, float speedRotate)
    {
        rb.AddForce(direction * moveSpeed);
        if(speedRotate > 0)
            rb.rotation *= Quaternion.Euler(0, direction.x, 0);
    }
    public void MovingTransform(Transform tran, Vector3 direction, float speed)
    {
        tran.transform.Translate(direction * speed * Time.deltaTime);
    }
    public void RotateTo(Rigidbody rb, Vector3 direction, float speedRotate)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.transform.rotation = Quaternion.Lerp(rb.transform.rotation, rotation, speedRotate * Time.deltaTime);
    }
}

