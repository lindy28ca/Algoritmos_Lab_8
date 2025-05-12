using System.Collections.Generic;

public class Node<T>
{
    public T Data { get; private set; }
    public List<Node<T>> Neighbors { get; private set; }

    public Node()
    {
        Neighbors = new List<Node<T>>();
    }

    public void AddNeighbor(Node<T> neighbor)
    {
        if (!Neighbors.Contains(neighbor))
        {
            Neighbors.Add(neighbor);
            neighbor.Neighbors.Add(this);
        }
    }
}