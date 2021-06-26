using UnityEngine;

public class SpawnDetection : MonoBehaviour
{
    public bool canInstantiate;
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
            Debug.Log("Hole Creation " + canInstantiate);
            posZVal += 30f;
        }
        else if (other.gameObject.CompareTag("LeftSpawn"))
        {
            canInstantiate = true;
            Debug.Log("Hole Creation " + canInstantiate);
            posXVal -= 20f;
        }
        else if (other.gameObject.CompareTag("RightSpawn"))
        {
            canInstantiate = true;
            Debug.Log("Hole Creation " + canInstantiate);
            posXVal += 20f;
        }
    }
}