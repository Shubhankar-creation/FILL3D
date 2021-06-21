using UnityEngine;

public class SpawnerDetection : MonoBehaviour
{
    public bool canInstantiate;
    public GameObject Ground;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("FrontSpawn"))
        {
            canInstantiate = true;
            Debug.Log("COllided");
            GameObject floor = Instantiate(Ground, new Vector3(Ground.transform.position.x, 0f, Ground.transform.position.z + 60), Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("BackSpawn"))
        {
            canInstantiate = true;
            GameObject floor = Instantiate(Ground, new Vector3(Ground.transform.position.x, 0f, Ground.transform.position.z - 60), Quaternion.identity);
        }
        if (other.gameObject.CompareTag("RightSpawn"))
        {
            canInstantiate = true;
            GameObject floor = Instantiate(Ground, new Vector3(Ground.transform.position.x + 60, 0f, Ground.transform.position.z), Quaternion.identity);
        }
        if (other.gameObject.CompareTag("LeftSpawn"))
        {
            canInstantiate = true;
            GameObject floor = Instantiate(Ground, new Vector3(Ground.transform.position.x - 60, 0f, Ground.transform.position.z), Quaternion.identity);
        }
        canInstantiate = false;
    }
}
