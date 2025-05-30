using System.Diagnostics;
using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.ForgotPassword;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Auth;

public partial class ForgotPassword 
{
    ForgotPasswordRequestModel forgotPasswordRequest = new();

    private async Task HandleForgotPassword()
    {
        var res =  await _httpClient.PostAsJsonAsync("api/User/forgotpassword", forgotPasswordRequest);
        if (res.IsSuccessStatusCode)
        {
            var jsonStr = await res.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
            if (result.respCode == "200")
            {
                _navigation.NavigateTo($"/reset-password/{forgotPasswordRequest.Email}");
            }
        }
    }
}