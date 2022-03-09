using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public TeamManager enemyTeam;

    public Transform[] units;

    public void SetTargetToUnits()
    {
        foreach (var unit in units)
        {
            var unitMovement = unit.GetComponent<UnitMovement>();
            unitMovement.SetTarget(enemyTeam.units);
        }
    }

    public bool HasActiveUnit()
    {
        foreach (var unit in units)
        {
            if (unit.gameObject.activeInHierarchy)
                return true;
        }

        return false;
    }
}
