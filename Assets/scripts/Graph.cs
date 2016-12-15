using UnityEngine;
using System.Collections.Generic;

public class Graph : MonoBehaviour {

    public Node[] allNodes;

    public List<Vector3> getPath()
    {
        List<Node> tempList = new List<Node>();

        //first node will be always Node0
        tempList.Add(allNodes[0]);

        Node nextNode = tempList[0].getNextNode();

        while (nextNode.name != allNodes[allNodes.Length - 1].name)
        {
            nextNode = nextNode.getNextNode();
            tempList.Add(nextNode);
        }

        List<Vector3> returner = new List<Vector3>();

        foreach(Node node in tempList)
        {
            var tempVec = node.transform.position;
            tempVec.y = 0;
            returner.Add(tempVec);
        }

        return returner;
    }
}
