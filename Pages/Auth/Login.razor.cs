using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Auth;

public partial class Login
{
    LoginRequestModel _model = new LoginRequestModel();

    private async Task HandleLogin()
    {
        try
        {
            var res = await _httpClient.PostAsJsonAsync("api/User/Login", _model);
            if (res.IsSuccessStatusCode)
            {
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (respModel.respCode == "200")
                {
                    _navigation.NavigateTo("/user-home");
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