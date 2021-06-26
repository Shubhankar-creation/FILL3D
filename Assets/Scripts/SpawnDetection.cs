using UnityEngine;

public class SpawnDetection : MonoBehaviour
{
    public bool canInstantiate;
    public bool frontSpawn;
    public bool leftSpawan;
    public bool rightSpawn;

    public float posZVal, posXVal;

    private void Start()
    {
        posZVal = 0f;
        posXVal = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FrontSpawn"))
        {
            canInstantiate = true;
            posZVal += 30f;
            frontSpawn = true;
        }
        else if (other.gameObject.CompareTag("LeftSpawn"))
        {
            canInstantiate = true;
            posXVal -= 30f;
            leftSpawan = true;
        }
        else if (other.gameObject.CompareTag("RightSpawn"))
        {
            canInstantiate = true;
            posXVal += 30f;
            rightSpawn = true;
        }
    }
}