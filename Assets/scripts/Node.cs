using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Node : MonoBehaviour {
    public Node[] nextNodes;

    public Node getNextNode()
    {
        return nextNodes[Random.Range(0, nextNodes.Length - 1)];
    }
}
