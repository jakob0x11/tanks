using System;
using Godot;

public class Player : Area2D {
    // nodes loaded from the scene
    private Node _controllerContainer;
    private Timer _movementTimer;
    // rest of local vars
    private Node controller;
    private bool hasMoved; 


    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        _controllerContainer = GetNode<Node>("ControllerContainer");
        SetController(new TankController(this));
        _movementTimer = GetNode<Timer>("MovementDelayTimer");
        _movementTimer.Connect("timeout", this, "_OnMovementTimerTimeout");
        hasMoved = false;
    }

    private void _OnMovementTimerTimeout() {
        hasMoved = false;
    }

    // probably want to wrap or pass in physics process delta for smooth movement 
    public bool Move(Vector2 direction, bool bypassDelay) {
        if (!bypassDelay && hasMoved) {
            return false;
        }
        Position = new Vector2(Position + direction * 25);
        hasMoved = true;
        _movementTimer.Start();
        return true;
    }

    private void SetController(PlayerController controller) {
        if (_controllerContainer == null) {
            GD.PrintErr("Controller container is not initialized!");
        }

        foreach (Node child in _controllerContainer.GetChildren()) {
            child.QueueFree();
        }

        this.controller = controller;
        _controllerContainer.AddChild(this.controller);
    }
}
