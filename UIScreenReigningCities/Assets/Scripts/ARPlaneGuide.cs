using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneGuide : MonoBehaviour
{
    
    [SerializeField] public GameObject pleaseWait;
    private ARRaycastManager rayCastManager;
    private ARPlaneManager planeManager;
    private Camera camera;

    private List<ARRaycastHit> hits;
    private ARPlane hitplane;

    // Start is called before the first frame update
    void Start()
    {

        rayCastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        hits = new List<ARRaycastHit>();
        camera = FindObjectOfType<Camera>();
        pleaseWait = Instantiate(pleaseWait);
        pleaseWait.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        hits.Clear();
        rayCastManager.Raycast(
            camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)),
            hits,
            UnityEngine.XR.ARSubsystems.TrackableType.Planes
            );

        if(hits.Count > 0)
        {
            // show marker
            pleaseWait.SetActive(false);
            /*
            marker.SetActive(true);
            marker.transform.SetPositionAndRotation(hits[hits.Count - 1].pose.position, hits[hits.Count - 1].pose.rotation);
            marker.transform.Rotate(Vector3.up , 10*Time.deltaTime);
            */
        }
        else
        {
            //show please wait
            pleaseWait.SetActive(true);
           
        }
    }
}
