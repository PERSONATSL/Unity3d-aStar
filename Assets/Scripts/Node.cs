using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public bool walkable;
    public Vector3 worldPosition;
    public int gridX, gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    public int fCost { get { return gCost + hCost; } }

    public Node(bool _walkable, Vector3 _worldPod, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPod;
        gridX = _gridX;
        gridY = _gridY;
    }
}
