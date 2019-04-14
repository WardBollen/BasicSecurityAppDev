using System.Security.Cryptography;

namespace ChatServerCS
{
    public interface IClient
    {
        void ParticipantDisconnection(string name);
        void ParticipantReconnection(string name);
        void ParticipantLogin(User client);
        void ParticipantLogout(string name);
        void UnicastTextMessage(string sender, string message, Aes aes);
        void UnicastPictureMessage(string sender, byte[] img);
        void ParticipantTyping(string sender);
    }
}