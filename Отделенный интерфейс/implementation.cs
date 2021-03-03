using domain;

namespace package 
{
    public class ConcreteLogger : ILogger 
    {
        public void Connect() 
        {
            Console.WriteLine("User's been connected!");
        }

        public void Disconnect() 
        {
            Console.WriteLine("User's been disconnected!");
        }
    }


    public class DataRequest 
    {
        Administrator administrator;

        public DataRequest()
        {
            //
        }

        public void Request(ConcreteLogger logger)
        {
            administrator.Login(logger);
        }
    }
}