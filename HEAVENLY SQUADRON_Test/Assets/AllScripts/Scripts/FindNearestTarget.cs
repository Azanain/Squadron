using UnityEngine;

public class FindNearestTarget
{
    public Transform NearestTarget { get; private set; }
    public bool TargetIsFinded { get; private set; }
    public void Find(Transform transform, float radiusSphere, LayerMask layers)
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radiusSphere, layers);
        if (colls.Length > 0)
        {
            TargetIsFinded = true;
            float dist = Mathf.Infinity;
            NearestTarget = colls[0].transform;
            foreach (var foe in colls)
            {
                Vector3 range = foe.transform.position - transform.position;
                float curDistance = range.sqrMagnitude;
                if (curDistance < dist)
                {
                    NearestTarget = foe.transform;
                    dist = curDistance;
                }
            }
        }
        else
            TargetIsFinded = false;
    }
}
