using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room.RoomTypeReqModel;
using Newtonsoft.Json;
using System.Net.Http.Json;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components;

namespace HotelManagementSystem_Web.Pages.Admin
{
    public partial class Room
    {

        RoomReqModel _model = new RoomReqModel();

        private List<RoomTypeModel> roomTypes = new();
        private async Task HandleValidSubmit()
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("admin/rooms", _model);
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (respModel.respCode == "200")
                {
                    Console.WriteLine("Success");
                    // _navigation.NavigateTo("/user-home");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task GetRoomList()
        {
            try
            {
                var res = await _httpClient.GetAsync("api/Room/getrooms");
                if (res.IsSuccessStatusCode)
                {
                    var jsonStr = await res.Content.ReadAsStringAsync();
                    var respModel = JsonConvert.DeserializeObject<RoomListResModel>(jsonStr);
                    if (respModel.respCode == "200")
                    {
                        roomList = respModel.RoomList;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await GetRoomList();
        }
        
        private void HandleRoomType(ChangeEventArgs e)
        {
            var selectedValue = e.Value?.ToString();

            if (Guid.TryParse(selectedValue, out Guid selectedRoomTypeId))
            {
                Console.WriteLine($"Selected Room Type ID: {selectedRoomTypeId}");
            }
            else
            {
                Console.WriteLine("Invalid or empty Room Type ID.");
            }
        }

        
        private List<RoomReqModel> roomList = new();
        private List<RoomReqModel> filteredRooms = new();
        // private RoomReqModel newRoom = new();

        private string searchRoomNo = "";
        private string searchRoomType = "";
        private string searchRoomStatus = "";

        private int currentPage = 1;
        private int pageSize = 5;
        private int totalPages => (int)Math.Ceiling((double)filteredRooms.Count / pageSize);
        private bool CanGoNext => currentPage < totalPages;
        private bool CanGoPrevious => currentPage > 1;

        private void ToggleFeature(RoomReqModel room)
        {
            _model.IsFeatured = !room.IsFeatured;
        }

        private void HandleFilter()
        {
            FilterRooms();
        }


        private void FilterRooms()
        {
            var query = roomList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRoomNo))
            {
                query = query.Where(r => r.RoomNo.Contains(searchRoomNo, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchRoomStatus))
            {
                query = query.Where(r => r.RoomStatus == searchRoomStatus);
            }

            filteredRooms = query.ToList();
            currentPage = 1;
        }

        private IEnumerable<RoomReqModel> PaginatedRooms()
        {
            return filteredRooms
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private void NextPage()
        {
            if (CanGoNext) currentPage++;
        }

        private void PreviousPage()
        {
            if (CanGoPrevious) currentPage--;
        }

    }

}
