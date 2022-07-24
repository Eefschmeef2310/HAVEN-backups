using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 5f;
    public Vector2 panlimit;
    Vector3 snapPos;
    public float scrollSpeed;
    public float minY = 20f;
    public float maxY = 120f;
    private bool snapping;
    private bool canvasActive;
    private GameObject snappedObject;
    public Camera cam;
    public TileEditor tileEditor;
    public Pause pauseScreen;
    public EditMode editMode;

    //Rotation
    private float rotateY;
    [SerializeField] private Transform targetTransform;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 vel = cam.velocity;
        Vector3 smoothedPosition;

        //Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.Setup();
        }

        /*//Rotate around the pivot point
        if(Input.GetMouseButton(1))
        {
            //Debug.Log(Input.GetAxis(""));
            rotateY += Input.GetAxis("Mouse X") * 0.5f;
            Vector3 nextRotation = new Vector3(60, rotateY, 0);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, 0.5f);
            transform.localEulerAngles = currentRotation;
            //transform.position = targetTransform.position - transform.forward *4f;
            //transform.position = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z) - transform.forward * 3f;
        }
        */
        

        //Snapping to clicked object when not editing
        if(!editMode.editing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                        
            if (Physics.Raycast(ray, out hit) && (hit.transform.parent.parent.parent.gameObject.layer == 6 || hit.transform.parent.parent.parent.gameObject.layer == 7))
            {       
                if(Input.GetMouseButtonDown(0))
                {
                    snapPos = new Vector3(hit.transform.position.x, 3, hit.transform.position.z - 2);
                    snapping = true;
                    if(snappedObject != null)
                    {
                        snappedObject.transform.GetChild(2).gameObject.SetActive(false);
                    }
                    snappedObject = hit.transform.parent.parent.parent.gameObject;
                    snappedObject.transform.GetChild(2).gameObject.SetActive(true);

                    if(snappedObject.tag == "Amenity")
                    {
                        snappedObject.transform.GetChild(3).gameObject.SetActive(true); //Activates the happiness radius
                    }

                    canvasActive = true;
                }
            }
        }

        if(canvasActive)
        {
            snappedObject.transform.GetChild(2).transform.LookAt(Camera.main.transform); //activates the In-world pop-up
            if((Input.anyKeyDown || editMode.editing) && snappedObject != null)
            {
                if(!Input.GetMouseButton(0))
                {
                    canvasActive = false;
                    snappedObject.transform.GetChild(2).gameObject.SetActive(false);
                    if(snappedObject.tag == "Amenity")
                    {
                        snappedObject.transform.GetChild(3).gameObject.SetActive(false); //Deactivates the happiness radius
                    }
                }
            }
        }

        if(Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            //Debug.Log(scroll * scrollSpeed * Time.deltaTime);
            pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        }

        //Debug.Log(tileEditor.minPosX - 1);

        pos.x = Mathf.Clamp(pos.x, tileEditor.minPosX, tileEditor.maxPosX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, tileEditor.minPosY, tileEditor.maxPosY);

        //Debug.Log("X can be between " + tileEditor.minPosX + "," + tileEditor.maxPosX);
        //Debug.Log("Y can be between " + tileEditor.minPosY + "," + tileEditor.maxPosY);
        
        if(snapping)
        {
            Vector3 velocity = Vector3.zero;
            smoothedPosition = Vector3.Lerp(transform.position, snapPos, 4f*Time.deltaTime);
            //Debug.Log(snapPos);
            transform.position = snapPos;
            if(transform.position == snapPos)
            {
                snapping = false;
            }
        }
        else
        {
            //pos = Vector3.Lerp(transform.position, pos, 1f);
            smoothedPosition = Vector3.SmoothDamp(transform.position, pos, ref vel, 0.5f);
            //Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, pos, 0.5f);
        }
        transform.position = smoothedPosition;
    }
}