namespace Utils.CustomExceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException(string message) : base(message)
        { }
    }
}
