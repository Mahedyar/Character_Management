using Character_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace Character_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client , ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected Response<Guid> ApiExceptionConvertor<Guid>(ApiException exception)
        {
            if(exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation Errors Occured",ValidationErrors = exception.Response, Success = true };
            }
            else if(exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found ....",Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, try again later...",Success = true };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
