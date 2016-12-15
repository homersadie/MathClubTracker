using System;
namespace MathClubTracker.NHibernate.Services
{
    public interface IIdentityService
    {
        string CurrentUser { get; set; }
    }
}
