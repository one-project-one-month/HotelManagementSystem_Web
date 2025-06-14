using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Register;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Auth;

public partial class Register
{
    private RegisterRequestModel  _model = new RegisterRequestModel();

    protected override async Task OnInitializedAsync()
    {
        
    }
    private async Task HandleRegister()
    {
        try
        {
            var res = await _httpClient.PostAsJsonAsync("api/User/register", _model);
            if (res.IsSuccessStatusCode)
            {
                var jsonStr = await res.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (resModel.respCode == "200")
                {
                    _navigation.NavigateTo("/login");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}