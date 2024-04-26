using UnityEngine;
using System;
using System.Collections.Generic;

public class DijkstraAlgorithm : MonoBehaviour
{
    public GameObject[] npcs; 
    public GameObject destination; 

    void Start()
    {
        // Perform Dijkstra's algorithm 
        foreach (GameObject npc in npcs)
        {
            Dijkstra(npc);
        }
    }

    //prints the distance of npc to destination or something
    void PrintSolution(Dictionary<GameObject, float> dist)
    {
        Debug.Log("NPC \t Distance to Destination");
        foreach (GameObject npc in npcs)
        {
            Debug.Log($"{npc.name}\t {dist[npc]}");
        }
    }

    //algo
    void Dijkstra(GameObject src)
    {
        Dictionary<GameObject, float> dist = new Dictionary<GameObject, float>();
        HashSet<GameObject> visited = new HashSet<GameObject>();

        foreach (GameObject npc in npcs)
        {
            dist[npc] = Mathf.Infinity;
        }

        dist[src] = Vector3.Distance(src.transform.position, destination.transform.position);

        for (int count = 0; count < npcs.Length; count++)
        {
            GameObject u = MinDistance(dist, visited);

            visited.Add(u);

            foreach (GameObject npc in npcs)
            {
                if (!visited.Contains(npc))
                {
                    float weight = Vector3.Distance(u.transform.position, npc.transform.position);
                    if (dist[u] != Mathf.Infinity && dist[u] + weight < dist[npc])
                    {
                        dist[npc] = dist[u] + weight;
                    }
                }
            }
        }

        PrintSolution(dist);
    }

    GameObject MinDistance(Dictionary<GameObject, float> dist, HashSet<GameObject> visited)
    {
        float minDist = Mathf.Infinity;
        GameObject minNPC = null;

        foreach (GameObject npc in npcs)
        {
            if (!visited.Contains(npc) && dist[npc] < minDist)
            {
                minDist = dist[npc];
                minNPC = npc;
            }
        }

        return minNPC;
    }
}