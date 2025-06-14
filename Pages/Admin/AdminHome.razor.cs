using HotelManagementSystem_Web.Models.Booking;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class AdminHome : ComponentBase
{
    private List<BookingModel> _bookingLst = new List<BookingModel>(); 
    protected override async Task OnInitializedAsync()
    {
        await GetBookingList();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("setColumnChartRoomType");
            await JSRuntime.InvokeVoidAsync("setLineChartSale");
            await JSRuntime.InvokeVoidAsync("setPieChartSourcesBooking");
            await JSRuntime.InvokeVoidAsync("setBarChartCount");
        }
    }

    public async Task GetBookingList()
    {
        var res = await _httpClient.GetAsync("admin/Bookings");
        if (res.IsSuccessStatusCode)
        {
            var jsonStr = await res.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<BookingListResponseModel>(jsonStr)!;
            _bookingLst = lst.Bookings;
        }
        else
        {
            Console.WriteLine(res.Content.ReadAsStringAsync());
        }
    }
}