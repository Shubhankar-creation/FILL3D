using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private Touch touch;

    public float forwardSpeed;
    public float Sensitivity;
    public float rotationSensitivity;

    public Material[] playerColor;
    public float changeColorTime;
    private int currInd;

    private void Start()
    {
        currInd = Random.Range(0, playerColor.Length);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = playerColor[currInd];

        //StartCoroutine(waitTOChangeColor());              To change color of playe over time
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        sideWaysMovement();
    }

    void sideWaysMovement()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                // Making player Move sideways on touch
                float xSlide = transform.position.x + touch.deltaPosition.x * Sensitivity;
                transform.position = new Vector3(xSlide, transform.position.y, transform.position.z);

                // Rotating the player based on sidewaysMovement
                transform.Rotate(Vector3.up * touch.deltaPosition.x / ( rotationSensitivity * 10 + 10));
            }
        }
    }

    IEnumerator waitTOChangeColor()
    {
        yield return new WaitForSeconds(changeColorTime);
        changeColor();
        StartCoroutine(waitTOChangeColor());
    }
    void changeColor()
    {
        randomIndex(currInd);
        meshRenderer.material = playerColor[currInd];
    }

    void randomIndex(int i)
    {
        while(i == currInd)
        {
            currInd = Random.Range(0, playerColor.Length);
        }
    }
}
