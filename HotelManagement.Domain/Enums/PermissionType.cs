namespace HotelManagement.Domain.Enums
{
    [Flags]
    public enum PermissionType
    {
        None = 0,
        ManageRooms = 1,
        ManageReservations = 2,
        ManageGuests = 4,
        ManageEmployees = 8,
        ManageHotel = 16,
        SuperAdmin = 31
    }
}
