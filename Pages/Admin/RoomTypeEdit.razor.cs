using System.Net.Http.Json;
using HotelManagementSystem_Web.Layout.Compoments;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class RoomTypeEdit 
{
    [Parameter]
    public string RoomTypeId { get; set; }
    public RoomTypeModel Model { get; set; } = new RoomTypeModel();
    public RoomTypeModel EditedModel { get; set; } = new RoomTypeModel();
    public bool isLoading { get; set; } = false;
    private AppModal Modal;
    private Guid _roomTypeId;

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
                var editModel = JsonConvert.SerializeObject(Model);
                EditedModel = JsonConvert.DeserializeObject<RoomTypeModel>(editModel);
            }
        }
        else
        {
            Console.WriteLine(JsonConvert.SerializeObject(res));
        }
    }

    private async Task HandleUpdateImage(InputFileChangeEventArgs e)
    {
        var file = e.File;
        if (file is not null)
        {
            var buffer = new byte[file.Size];
            await file.OpenReadStream(5 * 1024 * 1024).ReadAsync(buffer);
            EditedModel.RoomImg = Convert.ToBase64String(buffer);
            EditedModel.RoomImgMimeType = file.ContentType;
        }
    }

    public async Task HandleUpdateRoomType()
    {
        var url = $"admin/updateroomtype/{EditedModel.RoomTypeId}";
        var response = await _httpclient.PatchAsJsonAsync(url, EditedModel);
        
        if (!response.IsSuccessStatusCode) return;
        
        var jsonStr = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RoomTypeResModel>(jsonStr);
        
        if (result?.respCode == "200")
        {
            isLoading = true;
            EditedModel = new RoomTypeModel();
            await GetRoomTypeById();  
            isLoading = false;
        }
    }

    private async Task HandleDeleteRoomType()
    {
        var res = await _httpclient.DeleteAsync($"api/RoomType/deleteroomtype/{_roomTypeId}");
        var jsonStr = await res.Content.ReadAsStringAsync();
        Console.WriteLine(jsonStr);
        var result = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
        if (result?.respCode == "200")
        {
            _nav.NavigateTo("/admin/room-type");
        }
    }
}