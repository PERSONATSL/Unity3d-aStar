using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public LayerMask unwalkableMask;
    public Vector2 girdWorldSize;
    public float nodeRadius;
    Node[,] gird;

    float nodeDiameter;
    int girdSizeX, girdSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        girdSizeX = Mathf.RoundToInt(girdWorldSize.x / nodeDiameter);
        girdSizeY = Mathf.RoundToInt(girdWorldSize.y / nodeDiameter);
        CreateGird();
    }

    void CreateGird()
    {
        gird = new Node[girdSizeX, girdSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * girdWorldSize.x / 2 - Vector3.forward * girdWorldSize.y / 2;

        for (int x = 0; x < girdSizeX; x++)
            for(int y = 0; y < girdSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !Physics.CheckSphere(worldPoint, nodeRadius,unwalkableMask);
                gird[x, y] = new Node(walkable, worldPoint, x, y);
            }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int chexkX = node.gridX + x;
                int chexkY = node.gridY + y;

                if (chexkX >= 0 && chexkX < girdSizeX && chexkY >= 0 && chexkY < girdSizeY)
                {
                    neighbours.Add(gird[chexkX, chexkY]);
                }
            }
        }
        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + girdWorldSize.x / 2) / girdWorldSize.x;
        float percentY = (worldPosition.z + girdWorldSize.y / 2) / girdWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((girdSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((girdSizeY - 1) * percentY);
        return gird[x, y];
    }

    public List<Node> path;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(girdWorldSize.x, 1, girdWorldSize.y));
        if(gird != null)
        {
            foreach(Node n in gird)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if (path != null)
                    if (path.Contains(n))
                        Gizmos.color = Color.black;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
}
