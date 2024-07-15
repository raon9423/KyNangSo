using System;
namespace WebAppCore.Services
{
    public interface INotyfServices
    {
        void Success(string message);

        void Error(string message);
    }

}

