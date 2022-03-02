using System;
using Pyramid.Services;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            IOperationService operationService = new OperationService();

            var members = operationService.GetHierarchy();

            var transfers = operationService.GetTransfers();
        }
    }
}
