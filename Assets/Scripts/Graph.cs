using System.Collections.Generic;

public class Graph<TKey, TValue> where TValue : Node<TValue>
{
    protected Dictionary<TKey, TValue> Nodes = new Dictionary<TKey, TValue>();

    public void AddNode(TKey id, TValue node)
    {
        if (!Nodes.ContainsKey(id))
        {
            Nodes.Add(id, node);
        }
    }

    public void AddEdge(TKey id1, TKey id2)
    {
        if (Nodes.ContainsKey(id1) && Nodes.ContainsKey(id2))
        {
            Nodes[id1].AddNeighbor(Nodes[id2]);
        }
    }

    public TValue GetNode(TKey id)
    {
        if (Nodes.ContainsKey(id))
        {
            return Nodes[id];
        }
        return null;
    }
}