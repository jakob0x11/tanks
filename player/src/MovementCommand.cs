using Godot;

public class MovementCommand : ICommand {
    public class Params {
        public readonly Vector2 direction;

        public Params(Vector2 direction) {
            this.direction = direction;
        }
    }

    public bool Execute(Player player, object data = null, bool bypassDelay = false)
    {
        if (data is Params _data)
        {
            return player.Move(_data.direction, bypassDelay);
        }
        return false;
    }
} 