using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HotelManagementSystem_Web.Pages.Admin
{
    
    public partial class RoomType
    {
        RoomTypeModel _model = new RoomTypeModel();

        public async Task HandleRoomTypeForm()
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("admin/roomtypes", _model);
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (respModel.respCode == "200")
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<RoomTypeModel> _roomTypesList = new();
        private RoomTypeModel _roomTypeFilterText = new();
        private string _appliedFilterText = string.Empty;

        
        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                var buffer = new byte[file.Size];
                await file.OpenReadStream(5 * 1024 * 1024).ReadAsync(buffer);
                _model.RoomImg = Convert.ToBase64String(buffer);
                _model.RoomImgMimeType = file.ContentType;
            }
        }

        // private void HandleRoomTypeForm()
        // {
        //     _roomTypesList.Add(_model);
        //     _model = new RoomTypeModel();
        // }

    
        
        private void ClearFilter()
        {
            _appliedFilterText = string.Empty;
            _roomTypeFilterText.RoomTypeName = string.Empty;
        }


        private IEnumerable<RoomTypeModel> FilteredRoomTypes =>
            string.IsNullOrWhiteSpace(_roomTypeFilterText.RoomTypeName)
                ? _roomTypesList
                : _roomTypesList.Where(r => r.RoomTypeName.Contains(_roomTypeFilterText.RoomTypeName, StringComparison.OrdinalIgnoreCase));
    }

    }

