using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract class PlayerController : Node {

    protected readonly Player player;

    protected Stack<Tuple<ICommand, object>> commandHistory; 

    public PlayerController(Player player) {
        this.player = player;
        commandHistory = new Stack<Tuple<ICommand, object>>();
    }

    protected void RecordCommand(ICommand command, object data = null) {
        commandHistory.Push(new Tuple<ICommand, object>(command, data));
    }

    protected Tuple<ICommand, object> PopCommand() {
        return commandHistory.Pop();
    }
}