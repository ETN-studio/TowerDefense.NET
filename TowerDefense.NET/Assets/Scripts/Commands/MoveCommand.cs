using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// A utiliser impérativement pour bouger un élément du jeu
/// </summary>
public class MoveCommand : ICommand {
    private GameObject Gobj;
    private Vector3 Velocity;
    public MoveCommand(GameObject gobj,Vector3 Velocity)
    {
        Gobj = gobj;
        this.Velocity = Velocity;
    }
    public void Execute()
    {
        Gobj.transform.position += Velocity;
    }

    public void Undo()
    {
        Gobj.transform.position -= Velocity;
    }
}
