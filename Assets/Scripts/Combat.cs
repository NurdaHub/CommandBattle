using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private UnitMovement unitMovement;
    public CollisionDetector collisionDetector;

    private Health targetHealth;
    private float damageRepeatTime = 1;
    
    public void DealDamage(GameObject target)
    {
        if (target.activeInHierarchy)
        {
            targetHealth = target.GetComponent<Health>();
            InvokeRepeating("DoHit", 0, damageRepeatTime);
        }
    }

    private void DoHit()
    {
        if (targetHealth.isActiveAndEnabled)
            targetHealth.OnHit(damage);
        else
        {
            CancelInvoke();
            collisionDetector.gameObject.SetActive(true);
            unitMovement.FindTargetAndMove();
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
