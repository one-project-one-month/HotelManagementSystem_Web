

using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Guest;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin
{

    public partial class Guest
    {
        GuestReqModel _model = new GuestReqModel();

        private async Task HandleValidSubmit()
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("/Guest/createguestbyadmin", _model);
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<BaseResponseModel>(jsonStr);
                if (respModel?.respCode == "200")
                {
                    Console.WriteLine("Guest created successfully");
                    _model = new GuestReqModel();
                    await ShowModal();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ShowModal()
        {
            throw new NotImplementedException();
        }

        private bool showActionColumn = false;
        private List<GuestReqModel> guests = new();
        private List<GuestReqModel> filteredGuests = new();
        private string selectedStatus = "";

        private string Search = "";
        private int currentPage = 1;
        private int pageSize = 10;

        private int totalPages => (int)Math.Ceiling((double)(filteredGuests?.Count ?? 0) / pageSize);
        private bool CanGoBack => currentPage > 1;
        private bool CanGoForward => currentPage < totalPages;

        private void NextPage()
        {
            if (CanGoForward) currentPage++;
            StateHasChanged();
        }

        private void PreviousPage()
        {
            if (CanGoBack) currentPage--;
            StateHasChanged();
        }

        public void ApplyFilter(string selectedStatus)
        {
            if (string.IsNullOrEmpty(selectedStatus))
            {
                filteredGuests = guests;
            }
            else
            {
                filteredGuests = guests.Where(g => g.Name.Contains(selectedStatus, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            currentPage = 1;
            StateHasChanged();
        }


    }


}