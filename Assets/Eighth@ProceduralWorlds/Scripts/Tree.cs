using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private GameObject branchPrefab;

    [SerializeField]
    private int totalNodes = 3;

    int currentNode = 0;
    Queue<GameObject> frontier = new Queue<GameObject>();
    Queue<GameObject> newBranches = new Queue<GameObject>();


    private void Start()
    {
        GameObject root = Instantiate(branchPrefab, transform);
        root.name = "Branch [root]";
        frontier.Enqueue(root);
        GenerateTree();
    }

    private void GenerateTree()
    {
        if (currentNode >= totalNodes) return;

        currentNode++;

        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            var leftBranch = CreateBranch(branch, Random.Range(15f, 40f)); // Left
            var rightBranch = CreateBranch(branch, -Random.Range(15f, 40f)); // Right

            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(rightBranch);
        }
        int branches = newBranches.Count;
        for(int i =0; i<branches; i++)
        {
           frontier.Enqueue(newBranches.Dequeue());
        }
        GenerateTree();
        
    }

    private GameObject CreateBranch(GameObject prevBranch, float offsetAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);

        newBranch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        Quaternion rotation = prevBranch.transform.rotation;

        newBranch.transform.rotation = rotation * Quaternion.Euler(0f, 0f, offsetAngle);

        return newBranch;
    }
}
