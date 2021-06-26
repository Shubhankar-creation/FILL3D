using System.Collections;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    public PolygonCollider2D Hole2dCollider;
    public PolygonCollider2D Ground2dCollider;
    public MeshCollider GeneratedMeshCollider;
    float initalScale = 1f;
    Mesh GenerateMesh;

    private GameObject childHoleCol;
    private SpawnDetection shapeSpawn;

    private void Start()
    {
        childHoleCol = this.transform.GetChild(0).gameObject;
        shapeSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnDetection>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
    private void FixedUpdate()
    {

        if (transform.hasChanged == true)
        {

            setChildPos();
            transform.hasChanged = false;
            Hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            Hole2dCollider.transform.localScale = transform.localScale * initalScale;
            Make2dHole(int.Parse(Hole2dCollider.name));
            Make3dMeshCollider();
        }
    }


    void setChildPos()
    {
        childHoleCol.transform.position = Vector3.Lerp(childHoleCol.transform.position, 
            new Vector3(Ground2dCollider.transform.position.x - 4f, Ground2dCollider.transform.position.y, Ground2dCollider.transform.position.z - 5f), 
            0.01f);

    }
    void Make2dHole(int index)
    {
        Vector2[] pointPosition = Hole2dCollider.GetPath(0);

        for (int i = 0; i < pointPosition.Length; i++)
        {
            pointPosition[i] = Hole2dCollider.transform.TransformPoint(pointPosition[i]);
        }

        Ground2dCollider.pathCount = 3;
        Ground2dCollider.SetPath(index + 1, pointPosition);
    }

    void Make3dMeshCollider()
    {
        if (GenerateMesh != null) Destroy(GenerateMesh);
        GenerateMesh = Ground2dCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GenerateMesh;
    }

}