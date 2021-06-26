using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerMovement PM;
    private float posY;
    private void Start()
    {
        posY = PM.transform.position.y;

    }
    private void Update()
    {
        if(posY > 0.124)
        {

            transform.position = new Vector3(PM.transform.position.x, transform.position.y, PM.transform.position.z);

            transform.rotation = Quaternion.Lerp(transform.rotation, PM.transform.rotation, 5f);

            posY = PM.transform.position.y;
        }    

    }
}
