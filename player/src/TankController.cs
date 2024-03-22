using System;
using Godot;

public class TankController : PlayerController
{
    // private Timer _movementTimer;
    private readonly MovementCommand movementCommand;

    public TankController(Player player) : base(player)
    {
        movementCommand = new MovementCommand();

        // _movementTimer = GetNode<Timer>("MovementDelayTimer");
        // _movementTimer.Connect("timeout", this, "_OnMovementTimerTimeout");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("move_down")) {
            if (movementCommand.Execute(player, new MovementCommand.Params(Vector2.Down))) {
                RecordCommand(movementCommand, Vector2.Down);
            }
        } else if (Input.IsActionPressed("move_up")) {
            if (movementCommand.Execute(player, new MovementCommand.Params(Vector2.Up))) {
                RecordCommand(movementCommand, Vector2.Up);
            }
        } else if (Input.IsActionPressed("move_right")) {
            if (movementCommand.Execute(player, new MovementCommand.Params(Vector2.Right))) {
                RecordCommand(movementCommand, Vector2.Right);
            }
        } else if (Input.IsActionPressed("move_left")) {
            if (movementCommand.Execute(player, new MovementCommand.Params(Vector2.Left))) {
                RecordCommand(movementCommand, Vector2.Left);
            }
        }

        if (Input.IsActionJustReleased("reset_commands")) {
            UndoCommand();
        }
    }

    public void UndoCommand() {
        if (commandHistory.Count == 0) {
            return;
        }
        Tuple<ICommand, object> command = PopCommand();
        if (command.Item1 is MovementCommand) {
            movementCommand.Execute(player, new MovementCommand.Params(-(Vector2)command.Item2), true);
        }
    }
}
