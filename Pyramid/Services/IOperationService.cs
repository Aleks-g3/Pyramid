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
        Transfers GetTransfers();
    }
}
