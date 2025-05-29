using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room.RoomTypeReqModel;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HotelManagementSystem_Web.Pages.Admin
{
    public partial class Room
    {

        RoomReqModel _model = new RoomReqModel();

        private async Task HandleValidSubmit(Room room)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("", _model);
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (respModel.respCode == "200")
                {
                    Console.WriteLine("Hee Hee Har Har");
                    _navigation.NavigateTo("/user-home");
                }
            }
            catch (Exception ex)
            {

            }



        }

    }

}
