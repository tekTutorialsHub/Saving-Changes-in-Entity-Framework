using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCrud
{


    public class Employee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }


    public class Department
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }

        
        public string Name { get; set; }
        public string Descr { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }


    public class Region
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegionID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }


    }

    public class Territory
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TerritoryID { get; set; }
        public string Name { get; set; }
        
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
    }


    public class SalesPerson
    {

        [Key, ForeignKey("Employee")]
        public int EmployeeID { get; set; }


        public int TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }

    }



}
