using System.Net.Http.Json;
using HotelManagementSystem_Web.Models;
using HotelManagementSystem_Web.Models.Guest;
using Newtonsoft.Json;

namespace HotelManagementSystem_Web.Pages.Admin
{
    public partial class Guest
    {
        GuestReqModel _model = new GuestReqModel();

        private async Task GuestList()
        {
            try
            {
                var res = await _httpClient.GetAsync("/api/Guest/GetGuestList");
                var jsonStr = await res.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<GuestListReqModel>(jsonStr);
                if (respModel.respCode == "200")
                {
                    guestList = respModel.guestList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        protected override async Task OnInitializedAsync()
        {
           await GuestList();
        } 

        private async Task ShowModal()
        {
            throw new NotImplementedException();
        }

        private bool showActionColumn = false;
        private List<GuestReqModel> guestList = new();
        // private List<GuestReqModel> filteredGuests = new();
        private string selectedStatus = "";

        private string Search = "";
        private int currentPage = 1;
        private int pageSize = 10;

        // private int totalPages => (int)Math.Ceiling((double)(filteredGuests?.Count ?? 0) / pageSize);
        private bool CanGoBack => currentPage > 1;
        // private bool CanGoForward => currentPage < totalPages;

        // private void NextPage()
        // {
        //     if (CanGoForward) currentPage++;
        //     StateHasChanged();
        // }

        private void PreviousPage()
        {
            if (CanGoBack) currentPage--;
            StateHasChanged();
        }

        // public void ApplyFilter(string selectedStatus)
        // {
        //     if (string.IsNullOrEmpty(selectedStatus))
        //     {
        //         filteredGuests = guests;
        //     }
        //     else
        //     {
        //         filteredGuests = guests.Where(g => g.Name.Contains(selectedStatus, StringComparison.OrdinalIgnoreCase))
        //             .ToList();
        //     }
            //
            // currentPage = 1;
            // StateHasChanged();
        }
    }
