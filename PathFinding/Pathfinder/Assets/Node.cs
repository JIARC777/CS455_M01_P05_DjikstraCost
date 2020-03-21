using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public CostFactors environmentFactor;
    public Node[] ConnectsTo;

    
    private void OnDrawGizmos()
    {
       foreach (Node n in ConnectsTo)
       {
           Gizmos.color = Color.red;
           //Gizmos.DrawLine(transform.position, n.transform.position);
           Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
       }
    }

    // Store a cost factor that gets considered in the final path cost based on environmental factors
    public float GetCostFactor()
    {
        switch (environmentFactor)
        {
            case CostFactors.muddy:
                return 10f;
            case CostFactors.enemyHideOut:
                return 20f;
            case CostFactors.water:
                return 15f;
            default:
                return 0f;
        }
    }
}

public enum CostFactors
{
    none,
    muddy,
    enemyHideOut,
    water
}