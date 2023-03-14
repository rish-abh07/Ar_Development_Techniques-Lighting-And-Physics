using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArObjectPlacement : MonoBehaviour
{
    public ARSessionOrigin ar_session_origin;
    public List<ARRaycastHit> raycastHits= new List<ARRaycastHit>();
    public GameObject cube;
    private GameObject _instantiatedCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect the user touch
        if(Input.GetMouseButton(0)) {
          bool collsion = ar_session_origin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
          if (collsion)
            {
                if (_instantiatedCube = null)
                {
                    _instantiatedCube = Instantiate(cube);
                    foreach(var plane in ar_session_origin.GetComponent<ARPlaneManager>().trackables)
                    {
                        plane.gameObject.SetActive(false);  
                    }
                    ar_session_origin.GetComponent<ARPlaneManager>().enabled = false;
                }
               _instantiatedCube.transform.position = raycastHits[0].pose.position;            } 
        }
        //Project Ray Cast 
        //Instatiate a virtual cube at the point where we touch 
    }
}
