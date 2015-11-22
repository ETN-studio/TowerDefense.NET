using UnityEngine;
using System.Collections;
using System;

public class SpawnCommand : Command
{
    private Vector3 positionToSpawn;
    private Quaternion rotation;
    private GameObject model;
    private GameObject createdObject;
    public SpawnCommand(Vector3 position, Quaternion Rotation, GameObject model)
    {
        positionToSpawn = position;
        rotation = Rotation;
        if (model == null)
            throw new Exception("Command model is null");
        else
        {
            this.model = model;
        }
    }
    public override void Execute()
    {
        //if (model == null)
        //    throw new Exception("Command model in Execute() is null");
        //if (execute)
        //{
            createdObject = (GameObject)UnityEngine.Object.Instantiate(model, positionToSpawn, Quaternion.identity);
            
            base.Execute();
            execute = false;
        //}
        //else
        //{
        //    throw new ExecuteCommandException();
        //}
        
    }
    public override void Undo()
    {
        UnityEngine.Object.Destroy(createdObject);
       
        //if (!execute)
        //{
            base.Undo();
           
            execute = true;
            Debug.Log("HELLO");
        //}
        //else
        //{
        //    throw new ExecuteCommandException();
        //}
        Debug.Log("execute");
    }
}
