using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    public PolygonCollider2D Hole2dCollider;
    public PolygonCollider2D Ground2dCollider;
    public MeshCollider GeneratedMeshCollider;
    float initalScale = 0.5f;
    Mesh GenerateMesh;
    private void FixedUpdate()
    {

        if (transform.hasChanged == true)
        {
            transform.hasChanged = false;
            Hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            Hole2dCollider.transform.localScale = transform.localScale * initalScale;
            Make2dHole(int.Parse(Hole2dCollider.name));
        }
        Make3dMeshCollider();

    }

    void Make2dHole(int index)
    {
        Vector2[] pointPosition = Hole2dCollider.GetPath(0);

        for (int i = 0; i < pointPosition.Length; i++)
        {
            pointPosition[i] = Hole2dCollider.transform.TransformPoint(pointPosition[i]);
        }

        Ground2dCollider.pathCount = 5;
        Ground2dCollider.SetPath(index + 1, pointPosition);
    }

    void Make3dMeshCollider()
    {
        if (GenerateMesh != null) Destroy(GenerateMesh);
        GenerateMesh = Ground2dCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GenerateMesh;
    }

}
