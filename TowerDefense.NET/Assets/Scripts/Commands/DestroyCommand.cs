using UnityEngine;
using System.Collections.Generic;

public class DestroyCommand : Command {
    private GameObject objectToDestroy;
    public DestroyCommand(GameObject Gobj)
    {
        if (objectToDestroy == null)
            throw new System.Exception("Command objectToDestroy is null");
        else
        {
            objectToDestroy = Gobj;
        }
    }
    public override void Execute()
    {
        objectToDestroy.SetActive(false);
    }

    public override void Undo()
    {
        objectToDestroy.SetActive(true);
    }
   ~DestroyCommand()
    {
        if(!objectToDestroy.activeSelf)
        {
            UnityEngine.Object.Destroy(objectToDestroy);
        }
    }
}
