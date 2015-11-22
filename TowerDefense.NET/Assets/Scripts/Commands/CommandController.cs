using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CommandController<T> where T : ICommand
{
    private int currentIndex=0;
    private int lastIndex=-2;
    private List<T> commands;
    public CommandController()
    {
        commands = new List<T>();        
    }
    public CommandController(params T[] source)
    {
        commands = new List<T>();
        commands.AddRange(source);
    }
    public CommandController(List<T> source)
    {
        commands = new List<T>();
        commands.AddRange(source);
    }
    public void ExecuteCommand()
    {
        if(currentIndex < commands.Count())
        {
           
            commands[currentIndex].Execute();
            currentIndex++;
            lastIndex = currentIndex;
        }

    }
    public void UndoCommand()
    {
        Debug.Log("currentIndex :" + currentIndex);
        if (lastIndex > 0)
        {
            currentIndex--;
            commands[currentIndex].Undo();
        }
        lastIndex = currentIndex;

    }
    public void AddCommand(T command)
    {
        commands.Add(command);
    }
    public void AddExecuteCommand(T command)
    {
        if (currentIndex +1== commands.Count() )
        {
            commands.Add(command);
        }
        else
        {
            ResetListAt(currentIndex);
            commands.Add(command);
        }
        ExecuteCommand();
    }
    public void Clear()
    {
        commands.Clear();
        Reset();
    }
    private void Reset()
    {
        lastIndex = -2;
        currentIndex = 0;
    }
    public void ResetListAt(int index)
    {
        commands.RemoveRange(index, commands.Count - index);
    }

}
