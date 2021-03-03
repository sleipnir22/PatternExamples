namespace domain 
{
    public class Administrator 
    {
        public ILogger Logger {get;set;}

        public void Login(ILogger logger) {
            //методы
            Logger = logger;
            Logger.Connect();
        }
    }

    public class User 
    {
        ILogger logger;
    }

    public interface ILogger 
    {
        void Connect();
        void Disconnect();
    }
}