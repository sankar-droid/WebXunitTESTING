using Moq;
using WebXunitTESTING.Interface;
using WebXunitTESTING.Services;
namespace RazorDBTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mockrepo = new Mock<EmployeeService>();
            var employeelist = new List<EmployeeClass>
            {
                new EmployeeClass{Id=1, Name="Sankar",DeptNo=103},
                new EmployeeClass(Id=2, Name="Vivek",DeptNo=107),
                new EmployeeClass(Id=3, Name="Abdul",DeptNo=110)

            };
            mockrepo.Setup(repo => repo.GetRows()).Returns(employeelist);


            var servcice = mockrepo.Object;
            var result = servcice.GetRows();
            Assert.Equal(3,result.Count);
            Assert.Contains(result, s => s.Name == "Abdul");

            
        }
    }
}