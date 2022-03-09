using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    private Transform[] targets;
    private Transform closestTarget;
    private bool canMove;


    private void Update()
    {
        if (canMove)
            MoveTowardTarget();
    }

    public void SetTarget(Transform[] _targets)
    {
        targets = _targets;
        FindTargetAndMove();
    }

    public void FindTargetAndMove()
    {
        FindClosestTarget();
        MoveState(true);
    }

    public void MoveState(bool _canMove)
    {
        canMove = _canMove;
    }

    private void MoveTowardTarget()
    {
        if (closestTarget == null || !closestTarget.gameObject.activeInHierarchy)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, closestTarget.position, moveSpeed);
    }

    private void FindClosestTarget()
    {
        float closestTargetDistance = float.MaxValue;
        
        foreach (var target in targets)
        {
            if (target == null || !target.gameObject.activeInHierarchy)
                continue;
            
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < closestTargetDistance)
            {
                closestTargetDistance = distance;
                closestTarget = target;
            }
        }
    }
}
