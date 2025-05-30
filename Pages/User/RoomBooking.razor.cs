using Microsoft.AspNetCore.Components;

namespace HotelManagementSystem_Web.Pages.User;

public partial class RoomBooking
{
    private bool _isCompleteWhenToPay = false;
    private bool _isCompleteChoosePayment = false;
    private bool _isCompleteReserveMessage = false;
    private bool _isCompleteReserveReview = false;
    private bool _isCompleteProfile = false;
    private bool _isDoneWhenToPay = false;
    private bool _isDoneChoosePayment = false;
    private bool _isDoneReserveMessage = false;
    private bool _isDoneReserveReview = false;
    private bool _isDoneProfile = false;

    private void HandleWhenToPay()
    {
        _isDoneWhenToPay = true;
        _isCompleteWhenToPay = true;
    }

    private void ChangeWhenToPay()
    {
        _isDoneWhenToPay = false;
        _isCompleteWhenToPay = false;
    }

    private void HandleChoosePayment()
    {
        _isDoneChoosePayment = true;
        _isCompleteChoosePayment = true;
    }

    private void ChangeChoosePayment()
    {
        _isDoneChoosePayment = false;
        _isCompleteChoosePayment = false;
    }

    private void HandleReserveMessage()
    {
        _isDoneReserveMessage = true;
        _isCompleteReserveMessage = true;
    }

    private void ChangeReserveMessage()
    {
        _isDoneReserveMessage = false;
        _isCompleteReserveMessage = false;
    }

    private void HandleProfile()
    {
        _isDoneProfile = true;
        _isCompleteProfile = true;
    }

    private void ChangeProfile()
    {
        _isDoneProfile = false;
        _isCompleteProfile = false;
    }

    private void HandleReservation()
    {
        _isDoneReserveReview = true;
        _isCompleteReserveReview = true;
    }

    private void ChangeReservation()
    {
        _isDoneReserveReview = false;
        _isCompleteReserveReview = false;
    }
}