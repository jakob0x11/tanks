public interface ICommand {
    bool Execute(Player player, object data = null, bool bypassDelay = false);
}