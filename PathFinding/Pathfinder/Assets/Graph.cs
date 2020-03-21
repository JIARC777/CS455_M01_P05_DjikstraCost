using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build()
    {
        // find all nodes in scene
        // iterate over the nodes
        //   create connection objects,
        //   stuff them in mConnections
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                Connection c = new Connection(cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }
}

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;
    // This variable determines how much the costs of the individual nodes based on environment are weighted over shortest distance paths
    float environmentAffectFactor = 0.75f;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost(bool isTactical)
    {
        float environmentAffectFactor = 0.75f;
        float distanceFactor = (toNode.transform.position - fromNode.transform.position).magnitude;
        if (isTactical)
        {
            float toNodeCost = toNode.GetCostFactor();
            float fromNodeCost = fromNode.GetCostFactor();
            return (toNodeCost + fromNodeCost) * environmentAffectFactor + distanceFactor;
        }
        else
            return distanceFactor;

    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}

