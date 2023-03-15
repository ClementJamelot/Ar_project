using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject component;
    [SerializeField] private ARPlaneManager aRPlaneManager;
    public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPostion;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake() {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager=GetComponent<ARPlaneManager>();

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {//cette fonction permet de détecter lorsque l'utilisateur touche l'écran 
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(index : 0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) return;
        if(_arRaycastManager.Raycast(touchPosition,hits,trackableTypes:TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(spawnedObject == null)
            {
                Debug.Log(hitPose.rotation.y); 
                hitPose.rotation.y=180;
                spawnedObject = Instantiate(gameObjectToInstantiate,hitPose.position,hitPose.rotation);
                Destroy(component.GetComponent<ARRaycastManager>());
                Destroy(component.GetComponent<ARTapToPlaceObject>());
                DisplayAllARPlanes();

            }
            else
            {
                spawnedObject.transform.position=hitPose.position;
            }
        }
    }

    private void DisplayAllARPlanes()
    {
        foreach(var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
