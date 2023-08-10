using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Mobix.Data;

namespace SignalR.Hubs
{
    //[Authorize]
    public class ContactHub : Hub
    {
        //private readonly MobixDbContext _db;

        //public ContactHub(MobixDbContext db)
        //{
        //    _db = db;
        //}

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            // This method is called when a client connects
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // This method is called when a client disconnects
            await base.OnDisconnectedAsync(exception);
        }

        //private bool IsUserInRole(string userId, string roleName)
        //{
        //    var userRoleExists = _db.UserRoles.Any(ur =>
        //        ur.UserId == userId &&
        //        _db.Roles.Any(r => r.Name == roleName && r.Id == ur.RoleId)
        //    );

        //    return userRoleExists;
        //}
    }
}