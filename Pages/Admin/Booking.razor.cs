using System.Net.Http.Json;
using HotelManagementSystem_Web.Models.Booking;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Room;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class Booking
{
    BookingReqModel _model = new BookingReqModel();
    private bool showModal = false;
    private bool showActionColumn = false;
    private List<BookingReqModel> bookings = new();
    private List<BookingReqModel> filteredBookings = new();
    private string selectedStatus = "";
    private int currentPage = 1;
    private int pageSize = 10;
    private List<RoomTypeModel> roomTypes = new();
    private List<RoomModel> roomListRes = new();
    private int totalPages => (int)Math.Ceiling((double)(filteredBookings?.Count ?? 0) / pageSize);
    private bool CanGoBack => currentPage > 1;
    private bool CanGoForward => currentPage < totalPages;

    protected override async Task OnInitializedAsync()
    {
        await GetRoomTypesList();
    }

    private async Task HandleValidSubmit()
    {
        try
        {
            var res = await _httpClient.PostAsJsonAsync("/admin/CreateBooking", _model);
            var jsonStr = await res.Content.ReadAsStringAsync();
            var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
            if (respModel?.respCode == "200")
            {
                Console.WriteLine("Booking created successfully");
                _model = new BookingReqModel();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



    private async Task ShowAddBookingModal()
    {
        _model = new BookingReqModel();
        await JS.InvokeVoidAsync("showBootstrapModal", "#bookingModal");
    }

    private async Task GetRoomTypesList()
    {
        var res = await _httpClient.GetAsync("api/RoomType/getroomtypes");
        if (res.IsSuccessStatusCode)
        {
            var resJson = await res.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<RoomTypeListResModel>(resJson)!;
            if (resModel.respCode == "200")
            {
                roomTypes = resModel.RoomTypeList;
            }
            else
            {
                Console.WriteLine(resJson);
            }
        }
    }

    private async Task OnRoomTypeChanged(ChangeEventArgs e)
    {
        _model.Rooms = new List<Guid>();
        var selectedRoomTypeId = e.Value == typeof(Guid) ? Guid.Parse(e.Value.ToString()) : Guid.Empty;
        await GetRoomList();
        AddRoomIdToBooking(selectedRoomTypeId);
        var json = JsonConvert.SerializeObject(_model);
        Console.WriteLine(json);
    }

    private void AddRoomIdToBooking(Guid roomTypeId)
    {
        var roomId = roomListRes.Where(x => x.roomTypeId == roomTypeId && x.roomStatus).Select(x => x.roomId).FirstOrDefault();
        _model.Rooms.Add(roomId);
    }

    private async Task GetRoomList()
    {
        var res = await _httpClient.GetAsync("api/Room/getrooms");
        if (res.IsSuccessStatusCode)
        {
            var jsonRes = await res.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<RoomListResModel>(jsonRes)!;
            roomListRes = resModel.RoomList;
        }
    }

    private void ApplyFilter()
    {
        filteredBookings = bookings
            .Where(b =>
                string.IsNullOrEmpty(selectedStatus) ||
                b.BookingStatus?.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase) == true
            )
            .ToList();

        currentPage = 1;
    }

    private void ToggleActionColumn() => showActionColumn = !showActionColumn;

    private void PreviousPage()
    {
        if (CanGoBack)
            currentPage--;
    }

    private void NextPage()
    {
        if (CanGoForward)
            currentPage++;
    }

    private void OpenEditModal(BookingReqModel booking)
    {
        _model = booking;
    }

    private async Task DeleteBooking(Guid? bookingId)
    {
        if (bookingId == null)
            return;

        var confirmed = await JS.InvokeAsync<bool>("confirm", "Are you sure to delete this booking?");
        if (!confirmed) return;

        var response = await _httpClient.DeleteAsync($"/Bookings/createbookingbyadmin/{bookingId}");
    }
}