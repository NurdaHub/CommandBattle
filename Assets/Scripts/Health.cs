using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoint;

    private float minHealth = 0;

    public void OnHit(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= minHealth)
        {
            gameObject.SetActive(false);
            GameManager.Instance.CheckUnits();
        }
    }
}
