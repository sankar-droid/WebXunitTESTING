using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebXunitTESTING.Interface;
using WebXunitTESTING.Services;

namespace WebXunitTESTING.Pages
{
    public class EmployeeModel : PageModel
    {

        private readonly IEmployee _employeeservice;


        public EmployeeModel(IEmployee _ser)
        {
            _employeeservice = _ser;
        }


        public List<EmployeeClass> listOfEmployees {  get; set; }= new List<EmployeeClass>();



        public void OnGet()
        {
            listOfEmployees=_employeeservice.GetRows();
        }
    }
}
