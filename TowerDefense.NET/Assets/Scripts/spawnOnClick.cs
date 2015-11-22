using UnityEngine;
using System.Collections;
using System;

public class spawnOnClick : MonoBehaviour {
    public Camera cam;
    public GameObject model;
    private Renderer GobjRenderer;
    private CommandController<Command> Spawner;

    // Use this for initialization
    void Start () {
        if(cam==null)
        cam = Camera.allCameras[0];
        GobjRenderer = model.GetComponent<Renderer>();
        Spawner = new CommandController<Command>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnElement();
        }
        //if(Input.GetKeyDown(KeyCode.LeftControl)&& Input.GetKeyDown(KeyCode.Z))
        if (Input.GetMouseButtonDown(1))
        {
            Spawner.UndoCommand();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)&& Input.GetKeyDown(KeyCode.Y))
        {
            Spawner.ExecuteCommand();
        }
    }

    private void SpawnElement()
    {
        var clickPosReponse = FindPositionOfClickInWorldPosition();
        if (clickPosReponse.HasValue)
        {
           var CorrectPosition=clickPosReponse.Value;
            CorrectPosition.y += GobjRenderer.bounds.size.y/2;
            Spawner.AddExecuteCommand(new SpawnCommand(CorrectPosition, Quaternion.identity, model));
        }
    }

    private Vector3? FindPositionOfClickInWorldPosition()
    {
        Vector3? ClickPos=null;
        RaycastHit hitInfo;
        Vector3 DirectionClick = cam.ScreenPointToRay(Input.mousePosition).direction;
        Vector3 camPos = cam.transform.position;
        if (Physics.Raycast(cam.transform.position, DirectionClick, out hitInfo))
        {            
            ClickPos = camPos + (DirectionClick * hitInfo.distance);
            Debug.Log("ScreenToWorldPoint : " + ClickPos);          
        }
        return ClickPos;
    }
}
