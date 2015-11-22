using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {
    #region Declaration Variables
    public float verticalAngle=40f;
    public float fluiditéCamera=5f;    
    public float maxZoomDistance = 30;
    public float minZoomDistance = 5f;
    public float ZoomSpeed = 5f;
    public float mouvementSpeed=5f;
    public float fluiditéZoom=5f;
    public Transform cible { get; private set; }

    private Camera cam;
    private float distance;
    private Vector2 axeSouris;
    private float mouseWheel;
    private float vitesseMouvCamera;
    private float vitesseMouvCameraTemp;
    private Transform tr;


    public float distanceDefault {get; private set;}
    #endregion
    #region Initialisation
    // Use this for initialization
    void Start () {
        Init();

	}
    private void Init()
    {
        cam = GetComponent<Camera>();
        cam.transform.eulerAngles = new Vector3(verticalAngle, 0, 0);
        tr = GetComponent<Transform>();
        RaycastHit hit;
        if (Physics.Raycast(tr.position, tr.forward, out hit))
        {
            distance = hit.distance;
            distanceDefault = distance;
        }
        else
        {
            throw new Exception("ALERT");
            //distanceDefault = tr.position.y;
            //distance = distanceDefault;
        }
    }
    #endregion
    // Update is called once per frame
    void LateUpdate()
    {
        GetInputs();
        MoveCamera();
    }
    

  /// <summary>
  /// recupére les actions envoyé par les périphériques
  /// </summary>
    private void GetInputs()
    {
        vitesseMouvCameraTemp = vitesseMouvCamera;
        axeSouris.y = Input.GetAxis("Mouse Y");
        axeSouris.x = Input.GetAxis("Mouse X");
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Moved)
            {
                vitesseMouvCameraTemp = vitesseMouvCamera / 2;
                axeSouris.x = t.deltaPosition.x;
                axeSouris.y = t.deltaPosition.y;
            }
        }
    }
    /// <summary>
    /// bouge la camera a l'aide d'interpolation afin de lisser son déplacement
    /// </summary>
    private void MoveCamera()
    {
        float zoomVal;
        if(mouseWheel!=0)
        {
            zoomVal = mouseWheel * ZoomSpeed;
            distance += zoomVal;
            tr.position = Vector3.Lerp(tr.position,tr.position+(tr.forward * zoomVal),fluiditéZoom);
        }
        if (cible == null)
        {
            if (axeSouris.magnitude > 0)
                tr.position = Vector3.Lerp(tr.position, tr.position + new Vector3(axeSouris.x * mouvementSpeed * Time.deltaTime, 0, axeSouris.y * mouvementSpeed * Time.deltaTime), fluiditéCamera);
        }
        else
        {
            BougerVersCible();
        }
    }
    private void BougerVersCible()
    {
        tr.position = Vector3.Lerp(tr.position, (cible.position - tr.forward * distance), fluiditéCamera);
    }
    public void Follow(Transform cible)
    {
        this.cible = cible;
    }
    public void Unfollow()
    {
        cible = null;
    }
}
