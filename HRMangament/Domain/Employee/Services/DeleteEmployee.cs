using HRMangament.Domain.AccessLayer.Employees;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Services.Employees
{
    public interface IDeleteEmployee
    {
        void Excute(int employeeId);
    }
    public class DeleteEmployee: IDeleteEmployee
    {
        private readonly IEmployeeDataAdapter _employeeDataAdapter;

        public DeleteEmployee(IEmployeeDataAdapter employeeDataAdapter)
        {
            _employeeDataAdapter = employeeDataAdapter;
        }
        public void Excute(int employeeId)
        {
             _employeeDataAdapter.DeleteEmployee(employeeId);
        }
    }
}
