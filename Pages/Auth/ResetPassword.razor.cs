using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.ForgotPassword;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Auth;

public partial class ResetPassword 
{
    [Parameter]
    public string? email { get; set; }

    private ResetPasswordRequestModel _resetPasswordRequestModel;

    protected override async Task OnInitializedAsync()
    {
        _resetPasswordRequestModel = new ResetPasswordRequestModel
        {
            Email = email
        };
        
    }

    private async Task HandleResetPassword()
    {
        var res = await _httpClient.PostAsJsonAsync("api/User/resetpassword", _resetPasswordRequestModel);
        if (res.IsSuccessStatusCode)
        {
            var jsonStr = await res.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
            if (resModel.respCode == "200")
            {
                _navigation.NavigateTo("/login");
            }
            else
            {
                Console.WriteLine(resModel.respDescription);
            }
        }
        else
        {
            Console.WriteLine("Reset Password Failed");
        }
    }
}