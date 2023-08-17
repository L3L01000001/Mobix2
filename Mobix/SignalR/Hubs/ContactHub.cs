using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Mobix.Data;
using Mobix.EntityModels;

namespace SignalR.Hubs
{
    //[Authorize]
    public class ContactHub : Hub
    {
        private readonly MobixDbContext _db;

        public ContactHub(MobixDbContext db)
        {
            _db = db;
        }

        public async Task SendMessage(string message)
        {
            var poruka = new PorukeZaAdmina
            {
                Sadrzaj = message
            };

            _db.PorukeZaAdmina.Add(poruka);
            await _db.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
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