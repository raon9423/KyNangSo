using System;
namespace WebAppCore.Services
{
    public class NotyfServices : INotyfServices
    {
        private readonly INotyfServices _notyfServices;

        public NotyfServices(INotyfServices notyfServices)
        {
            _notyfServices = notyfServices;
        }

        public void Success(string message)
        {
            _notyfServices.Success(message);
        }

        public void Error(string message)
        {
            _notyfServices.Error(message);
        }
    }

}

