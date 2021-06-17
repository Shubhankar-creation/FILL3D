using UnityEngine;
using UnityEngine.AI;
public class HoleCreation : MonoBehaviour
{
    public PolygonCollider2D ground2dCollider;
    public PolygonCollider2D hole2dCollider;
    public MeshCollider GeneratedMeshCollider;

    private Mesh GenertateMesh;

    private void Start()
    {
        hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
    }
    private void FixedUpdate()
    {
        if(transform.hasChanged == true)
        {
            transform.hasChanged = false;
            hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
        }
        make2dHole();
        make2dTo3dCollider();
    }
    void make2dHole()
    {
        Vector2[] pointPositon = hole2dCollider.GetPath(0);

        for(int i =0; i < pointPositon.Length; i++)
        {
            pointPositon[i] = (Vector2)hole2dCollider.transform.TransformPoint(pointPositon[i]);
        }

        ground2dCollider.pathCount = 2;
        ground2dCollider.SetPath(1, pointPositon);
    }
    void make2dTo3dCollider()
    {
        if (GenertateMesh != null) Destroy(GenertateMesh);
        GenertateMesh = ground2dCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GenertateMesh;

    }
}

