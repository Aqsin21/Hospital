﻿
namespace Final.Business.Services.Abstarct
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);

    }
}
