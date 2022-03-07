using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramid.Entities;

namespace Pyramid.Services
{
    interface IOperationService
    {
        Member GetHierarchy();
        void MakeTransfers(ref Account[] accounts);
        Account[] CreateAccounts(Member members);
        void ShowMembersWithSalary(Account[] accounts);
    }
}
