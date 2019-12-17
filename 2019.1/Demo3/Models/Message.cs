namespace Demo3.Models
{
    public class Message
    {
        public string Welcome { get; private set; }

        public Message(string message)
        {
            this.Welcome = message;
        }
    }
}
