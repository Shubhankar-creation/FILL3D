using UnityEngine;
using UnityEngine.AI;

public class HoleCreation : MonoBehaviour
{
    private GameObject HoleParent;
    private GameObject Collider2dTo3d;
    private GameObject ground2D;
    private GameObject Hole2D;
    private GameObject Coll3Dmesh;

    public float xVal, zVal;
    private SpawnDetection respawnColDetect;

    PolygonCollider2D groundCol;
    PolygonCollider2D HoleCol;
    MeshCollider Mesh3DColl;
    private HoleMovement holeMove;


    public GameObject HoleShape;

    private Vector2[] polyPoint = {new Vector2(10f, 15f),
                            new Vector2(-10f, 15f),
                            new Vector2(-10f, -15f),
                            new Vector2(10f, -15f)};
    private void Start()
    {
        respawnColDetect = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnDetection>();

        Ground2dCol();
        Mesh3DCol();
        for (int i = 0; i < 2; i++)
        {
            Instantiate2dGOs(i);
            AddingHoleComponents(i);
        }
    }

    private void Update()
    {

        if (respawnColDetect.canInstantiate)
        {
            setPolyPoints();
            Ground2dCol();
            Mesh3DCol();
            for (int i = 0; i < 2; i++)
            {
                Instantiate2dGOs(i);
                AddingHoleComponents(i);
            }
            respawnColDetect.canInstantiate = false;

        }

    }

    void setPolyPoints()
    {
        polyPoint[2] = polyPoint[1];
        polyPoint[3] = polyPoint[0];
        polyPoint[0] = new Vector2(respawnColDetect.posXVal + 10f, respawnColDetect.posZVal + 15f);
        polyPoint[1] = new Vector2(-(respawnColDetect.posXVal + 10f), respawnColDetect.posZVal + 15f);
    }
    void Ground2dCol()
    {
        ground2D = new GameObject("Ground2D");
        ground2D.tag = "Ground2D";
        groundCol = ground2D.AddComponent<PolygonCollider2D>();
        ground2D.transform.position = new Vector3(respawnColDetect.posXVal, 0f, respawnColDetect.posZVal);
        groundPolySet(groundCol);

        // creating GO for detection
        GameObject groundCol3d = new GameObject();
        groundCol3d.transform.parent = ground2D.transform;
        groundCol3d.transform.position = ground2D.transform.position;
        groundCol3d.AddComponent<BoxCollider>().isTrigger = true;
    }
    void groundPolySet(PolygonCollider2D ground2dCol)
    {
        ground2dCol.SetPath(0, polyPoint);
    }
    void Mesh3DCol()
    {
        Coll3Dmesh = new GameObject("3dMeshColl");
        Coll3Dmesh.tag = "Mesh3D";
        Mesh3DColl = Coll3Dmesh.AddComponent<MeshCollider>();

        Coll3Dmesh.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        // creating GO for detection

        GameObject mesh3D = new GameObject();
        mesh3D.transform.parent = Coll3Dmesh.transform;
        mesh3D.transform.position = ground2D.transform.position;
        mesh3D.AddComponent<BoxCollider>().isTrigger = true;
    }
    private void Instantiate2dGOs(int index)
    {
        Collider2dTo3d = new GameObject("Collider2dTo3d");
        Collider2dTo3d.transform.position = new Vector3(respawnColDetect.posXVal, 0f, respawnColDetect.posZVal);

        Collider2dTo3d.transform.parent = transform;
        Collider2dTo3d.tag = "Coll2dTo3d";


        // creating GO for detection

        GameObject Col3dDetect = new GameObject();
        Col3dDetect.transform.parent = Collider2dTo3d.transform;
        Col3dDetect.transform.position = Collider2dTo3d.transform.position;

        Col3dDetect.AddComponent<BoxCollider>().isTrigger = true;

        Hole2dCol(index);

    }
    void Hole2dCol(int index)
    {
        Hole2D = new GameObject();
        Hole2D.name = "" + index; Hole2D.tag = "Hole2d";
        HoleCol = Hole2D.AddComponent<PolygonCollider2D>();
        Hole2D.transform.parent = Collider2dTo3d.transform;
    }
    private void AddingHoleComponents(int index)
    {
        HoleParent = new GameObject("HoleParent");
        HoleParent.transform.parent = transform; HoleParent.tag = "HoleParent";

        randomPos();
        HoleParent.transform.position = new Vector3(xVal, 0f, zVal);

        Debug.Log("Hole Parent LocalPositon val is  " + HoleParent.transform.localPosition);
        Debug.Log("Hole Parent Positon val is  " + HoleParent.transform.position);

        // creating GO for detection

        GameObject hole3dparent = new GameObject("HoleDeactivate");
        hole3dparent.tag = "HoleDelete";
        hole3dparent.transform.position = ground2D.transform.position;

        hole3dparent.transform.parent = HoleParent.transform;
        hole3dparent.AddComponent<BoxCollider>().isTrigger = true;

        MovementHoleComponent();

        GameObject newHole = Instantiate(HoleShape, HoleParent.transform.position, Quaternion.identity) as GameObject;
        newHole.transform.parent = HoleParent.transform;
    }

    void randomPos()
    {

        
        if(xVal < 0)
        {
            xVal = Random.Range(respawnColDetect.posXVal, respawnColDetect.posXVal + 7.5f);
            zVal = Random.Range(respawnColDetect.posZVal, respawnColDetect.posZVal + 7.5f);
        }
        else
        {
            xVal = respawnColDetect.posXVal - Random.Range(0f, 7.5f);
            zVal = respawnColDetect.posZVal - Random.Range(0f, 7.5f);
        }

    }

    void MovementHoleComponent()
    {
        holeMove = HoleParent.AddComponent<HoleMovement>();
        HoleParent.AddComponent<EnemyFollow>();
        HoleParent.AddComponent<NavMeshAgent>();


        holeMove.Hole2dCollider = HoleCol;
        holeMove.Ground2dCollider = groundCol;
        holeMove.GeneratedMeshCollider = Mesh3DColl;
    }  
}

