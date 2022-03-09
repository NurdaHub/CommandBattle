using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string enemyTag;
    [SerializeField] private Combat combat;
    [SerializeField] private UnitMovement unitMovement;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(enemyTag))
        {
            combat.DealDamage(otherCollider.gameObject);
            unitMovement.MoveState(false);
            gameObject.SetActive(false);
        }
    }
}
