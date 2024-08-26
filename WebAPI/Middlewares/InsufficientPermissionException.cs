using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebAPI.Middlewares
{
    public class InsufficientPermissionException : Exception
    {
        public InsufficientPermissionException()
        {
        }

        public InsufficientPermissionException(string message) : base(message)
        {
        }

        //public InsufficientPermissionException(string resource, Privilege privilege) : base($"Access denied for ({resource.ToUpper()}.{privilege})")
        //{
        //}

        //public InsufficientPermissionException(Type resourceType, Privilege privilege) : base($"Access denied for ({resourceType.Name.ToUpper()}.{privilege})")
        //{
        //}

        //public InsufficientPermissionException(Type resourceType, Privilege privilege, AccessLevel accessLevel) : base($"Access level ({accessLevel}) denied for {resourceType.Name.ToUpper()}.{privilege}")
        //{
        //}
    }

}
