using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// A utiliser impérativement pour bouger un élément du jeu
/// </summary>
public class MoveCommand : Command {
    private GameObject Gobj;
    private Vector3 Velocity;
    private Vector3 positionAvantDeBouger;


 

    public MoveCommand(GameObject gobj,Vector3 Velocity)
    {
        Gobj = gobj;
        this.Velocity = Velocity;
    }
    public override void Execute()
    {
        if (execute)
        {
            Gobj.transform.position += Velocity;
            positionAvantDeBouger = Gobj.transform.position;
            execute = false;
        }
        else
        {
            throw new ExecuteCommandException();
        }
    }
    public override void Undo()
    {
        if (!execute)
        {
            Gobj.transform.position = positionAvantDeBouger;
            execute = true;
        }
        else
        {
            throw new UndoCommandException();
        }
    }
}
