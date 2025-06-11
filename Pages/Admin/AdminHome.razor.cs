using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HotelManagementSystem_Web.Pages.Admin;

public partial class AdminHome : ComponentBase
{
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
        var res = await _httpClient.GetAsync("Admin/Bookings");
        if (res.IsSuccessStatusCode)
        {
            var jsonStr = await res.Content.ReadAsStringAsync();
            Console.WriteLine(jsonStr);
        }
    }
}