using System;
using Pyramid.Services;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            IOperationService operationService = new OperationService();

            operationService.GetMembers();
        }
    }
}
