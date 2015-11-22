using System;
using UnityEngine;
public interface ICommand
{
    ICommand nextCommand{ get; set; }
    void Execute();
    void Undo();
}
public abstract class Command: ICommand
{
    public ICommand nextCommand { get; set; }
    protected bool execute = true;

    public virtual void Execute()
    {
        if (nextCommand != null)
            nextCommand.Execute();
    }
    public virtual void Undo()
    {
        if (nextCommand != null)
            nextCommand.Undo();
    }   
}
[System.Serializable]
public class ExecuteCommandException : System.Exception
{
    private static string myMessage = "Une commande ne peut être executée qu'une fois.    ";
    public ExecuteCommandException() { }
    public ExecuteCommandException(string message) : base(myMessage+message) { }
    public ExecuteCommandException(string message, System.Exception inner) : base(myMessage + message, inner) { }
}
[System.Serializable]
public class UndoCommandException : System.Exception
{
    private static string myMessage = "Une commande ne peut être annulée qu'une fois.    ";
    public UndoCommandException() { }
    public UndoCommandException(string message) : base(myMessage + message) { }
    public UndoCommandException(string message, System.Exception inner) : base(myMessage + message, inner) { }
}

