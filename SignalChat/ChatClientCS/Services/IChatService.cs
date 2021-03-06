﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ChatClientCS.Models;
using ChatClientCS.Enums;

namespace ChatClientCS.Services
{
    public interface IChatService
    {
        event Action<User> ParticipantLoggedIn;
        event Action<string> ParticipantLoggedOut;
        event Action<string> ParticipantDisconnected;
        event Action<string> ParticipantReconnected;
        event Action ConnectionReconnecting;
        event Action ConnectionReconnected;
        event Action ConnectionClosed;
        event Action<string, string, MessageType, Aes> NewTextMessage;
        event Action<string, byte[], MessageType> NewImageMessage;
        event Action<string> ParticipantTyping;

        Task ConnectAsync();
        Task<List<User>> LoginAsync(string name, byte[] photo);
        Task LogoutAsync();

        Task SendBroadcastMessageAsync(string msg);
        Task SendBroadcastMessageAsync(byte[] img);
        Task SendUnicastTextMessageAsync(string recepient, string msg, Aes aes);
        Task SendUnicastMessageAsync(string recepient, byte[] img);
        Task TypingAsync(string recepient);
    }
}