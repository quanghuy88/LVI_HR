using Core.Enums;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IContextUserService : IInjection
    {
        bool IsAuthenticated { get; }
        decimal UserId { get; }
        string UserName { get; }
        string UserDisplayName { get; }
        decimal BranchId { get; }
        decimal DeparmentId { get; }
        string[] Roles { get; }
        string AccessibleResources { get; }
        bool IsAdministrator { get; }
        //AccessLevel GetAccessLevel(string resource, Privilege privilege);
        //AccessLevel GetAccessLevel<TResource>(Privilege privilege) where TResource : class;
        //bool IsGranted(string resource, Privilege privilege);
        //bool IsGranted<TResource>(Privilege privilege) where TResource : class;
    }

    public interface IContextUserService<TResource> : IContextUserService where TResource : class
    {
        AccessLevel ReadLevel { get; }
        AccessLevel CreateLevel { get; }
        AccessLevel UpdateLevel { get; }
        AccessLevel DeleteLevel { get; }
        AccessLevel ApproveLevel { get; }
        AccessLevel FinalApproveLevel { get; }
        AccessLevel AssignLevel { get; }
    }
}
