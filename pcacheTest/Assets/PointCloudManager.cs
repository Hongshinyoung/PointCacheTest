using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCloudManager : MonoBehaviour
{
    public GameObject emptyObject;
    public string pointCloudFilePath = "Assets\\test.pcache";

    void Start()
    {
        // Load the point cloud data from the file
        List<string> pointCloudData = new List<string>();
        using (System.IO.StreamReader file = new System.IO.StreamReader(pointCloudFilePath))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                pointCloudData.Add(line);
            }
        }

        // Divide the point cloud data into chunks of 10000 points and add to the empty object
        List<string> chunk = new List<string>();
        int i = 0;
        foreach (string line in pointCloudData)
        {
            if (i < 1000)
            {
                chunk.Add(line);
                i++;
            }
            else
            {
                AddChunkToEmptyObject(chunk);
                chunk = new List<string>();
                i = 0;
            }
        }
        if (chunk.Count > 0)
        {
            AddChunkToEmptyObject(chunk);
        }
    }

    void AddChunkToEmptyObject(List<string> chunk)
    {
        GameObject chunkObject = new GameObject("Chunk");
        chunkObject.transform.parent = this.transform; // 부모 변경 대신, 인스턴스화된 오브젝트의 Transform을 조작

        Mesh mesh = new Mesh();
        MeshFilter meshFilter = chunkObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        float floatValue;


        List<Vector3> vertices = new List<Vector3>();
        foreach (string vertexLine in chunk)
        {
            string[] vertexComponents = vertexLine.Split(' ');
            Vector3 vertex = new Vector3();

            if (vertexComponents.Length >= 3 && float.TryParse(vertexComponents[0], out floatValue) && float.TryParse(vertexComponents[1], out floatValue) && float.TryParse(vertexComponents[2], out floatValue))
            {
                vertex.x = float.Parse(vertexComponents[0]);
                vertex.y = float.Parse(vertexComponents[1]);
                vertex.z = float.Parse(vertexComponents[2]);
                vertices.Add(vertex);
            }
        }

        mesh.SetVertices(vertices);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        MeshRenderer meshRenderer = chunkObject.AddComponent<MeshRenderer>();
    }
}
