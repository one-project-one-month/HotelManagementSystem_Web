using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class RoomTypeEdit 
{
    [Parameter]
    public string RoomTypeId { get; set; }
    public RoomTypeModel Model { get; set; } = new RoomTypeModel();
    public bool isLoading { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        await GetRoomTypeById();
        isLoading = false;
    }

    public async Task GetRoomTypeById()
    {
        var res = await _httpclient.GetAsync($"api/RoomType/{RoomTypeId}");
        if (res.IsSuccessStatusCode)
        {
            var jsonStr = await res.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<RoomTypeResModel>(jsonStr);
            if (resModel.respCode == "200")
            {
                Model = resModel.RoomType;
            }
        }
    }
}