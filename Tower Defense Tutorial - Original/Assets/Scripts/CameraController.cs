using UnityEngine;


public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float testNum = 5.0f;
	
	
	
    void Update () {

       
        // If the user presses escape then the navigation buttons stop working
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if(!doMovement)
        {
            return;
        }
        
        // Enables the user to pan by pressing and holding the scroll wheel
        if (Input.GetKey("mouse 2"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * testNum) / (Screen.width * testNum),Space.World);
            //Debug.Log(Input.mousePosition.x);

            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * testNum) / (Screen.width * testNum), Space.World);
           // Debug.Log(Input.mousePosition.y);
        }
        else
        {

            // Set of statments to take  wasd input and mouse position to let the user control the camera
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }

        // holds a reference that represents the mouse scroll
      float scroll = Input.GetAxis("Mouse ScrollWheel");

        // the cameras current position
         Vector3 pos = transform.position;

        // adjusts the y axis of our current position using the scroll wheel
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // Enures that we can only zoom in or out between the minY and maxY
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // sets the transfroms with the adjusted y axis
        transform.position = pos;

        // SHOULD ADD MATHF.CLAMP TO THE LEFT AND RIGHT SCROLLING AS WELL


    }
}
