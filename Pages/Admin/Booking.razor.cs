using System.Net.Http.Json;
using HotelManagementSystem_Web.Models.Booking;
using HotelManagementSystem_Web.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class Booking
{
    BookingReqModel _model = new BookingReqModel();
    private bool showModal = false;

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



    private bool showActionColumn = false;
    private List<BookingReqModel> bookings = new();
    private List<BookingReqModel> filteredBookings = new();
    private string selectedStatus = "";
    private int currentPage = 1;
    private int pageSize = 10;


    private int totalPages => (int)Math.Ceiling((double)(filteredBookings?.Count ?? 0) / pageSize);
    private bool CanGoBack => currentPage > 1;
    private bool CanGoForward => currentPage < totalPages;

    private async Task ShowAddBookingModal()
    {
        _model = new BookingReqModel();
        await JS.InvokeVoidAsync("showBootstrapModal", "#bookingModal");
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