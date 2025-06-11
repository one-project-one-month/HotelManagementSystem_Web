using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace HotelManagementSystem_Web.Pages.Admin
{
    public partial class RoomType
    {
        private bool isLoading = false;
        List<RoomTypeModel> RoomTypeLst = new List<RoomTypeModel>();
        RoomTypeModel _model = new RoomTypeModel();

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            await RoomTypeList();
            isLoading = false;
        }
        public async Task RoomTypeList()
        {
            var res = await _httpClient.GetAsync("api/RoomType/getroomtypes");
            if (res.IsSuccessStatusCode)
            {
                var jsonStr = await res.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<RoomTypeListResModel>(jsonStr);
                if (resModel.respCode == "200")
                {
                    RoomTypeLst = resModel.RoomTypeList;
                    
                }
            }
        }

        public async Task HandleRoomTypeForm()
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("admin/createroomtype", _model);
                Console.WriteLine(JsonConvert.SerializeObject(_model));
                if (res.IsSuccessStatusCode)
                {
                    var jsonStr = await res.Content.ReadAsStringAsync();
                    var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                    if (respModel.respCode == "200")
                    {
                        _model = new RoomTypeModel(); // Optional: reset form

                        // Close the modal
                        await JS.InvokeVoidAsync("hideBootstrapModal", "#addRoomTypeModal");
                       await RoomTypeList();
                       StateHasChanged();
                    }
                }
                else
                {
                    Console.WriteLine(res.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private RoomTypeModel _roomTypeFilterText = new();
        private string _appliedFilterText = string.Empty;
        private List<RoomTypeModel> _roomTypesList = new List<RoomTypeModel>();


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
                : _roomTypesList.Where(r =>
                    r.RoomTypeName.Contains(_roomTypeFilterText.RoomTypeName, StringComparison.OrdinalIgnoreCase));
    }
}