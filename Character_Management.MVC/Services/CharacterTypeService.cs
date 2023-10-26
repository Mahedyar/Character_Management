using AutoMapper;
using Character_Management.MVC.Contracts;
using Character_Management.MVC.Models;
using Character_Management.MVC.Services.Base;

namespace Character_Management.MVC.Services
{
    public class CharacterTypeService : BaseHttpService, ICharacterTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public CharacterTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<Response<int>> CreateCharacterType(CreateCharacterTypeVM characterTypeVM)
        {
            try
            {
                var response = new Response<int>();
                CreateCharacterTypeDto createCharacterTypeDto = _mapper.Map<CreateCharacterTypeDto>(characterTypeVM);


                AddBearerToken();

              
                var apiResponse = await _httpClient.CharacterTypePOSTAsync(createCharacterTypeDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var err in apiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ApiExceptionConvertor<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteCharacterType(int id)
        {
            try
            {
                AddBearerToken();
                await _httpClient.CharacterTypeDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch(ApiException ex)
            {
                return ApiExceptionConvertor<int>(ex);
            }
        }

        public async Task<CharacterTypeVM> GetCharacterTypeDetails(int id)
        {
            AddBearerToken();
            var characterType = await _httpClient.CharacterTypeGETAsync(id);
            return _mapper.Map<CharacterTypeVM>(characterType);
        }

        public async Task<List<CharacterTypeVM>> GetCharacterTypes()
        {
            AddBearerToken();
            var characterTypes = await _httpClient.CharacterTypeAllAsync();
            return _mapper.Map<List<CharacterTypeVM>>(characterTypes);
        }

        public async Task<Response<int>> UpdateCharacterType(int id, CharacterTypeVM characterType)
        {
            try
            {
                AddBearerToken();
                UpdateCharacterTypeDto updateCharacterTypeDto = _mapper.Map<UpdateCharacterTypeDto>(characterType);
                await _httpClient.CharacterTypePUTAsync(id, updateCharacterTypeDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ApiExceptionConvertor<int>(ex);
            }
        }
    }
}
