﻿using apointify.ExtentionMethods;
using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





namespace apointify.Controllers
{

    public class EmployeeController : ControllerBase
    {
        OmParmarContext DBEntities = new OmParmarContext(); 

        [HttpGet, Route("api/EmployeeData")]
        public ServiceResponse<List<Employee>> GetEmployeeData()
        {
            ServiceResponse<List<Employee>> serviceReponse = new ServiceResponse<List<Employee>>();
            try
            {
                using (DBEntities = new OmParmarContext())
                {
                    var user = DBEntities.Employees.ToList();
                    serviceReponse.data = user;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data Fetched successfully";
                }
            }
            catch (Exception ex)
            {
                //serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();

            }
            return serviceReponse;
        }


        [HttpGet, Route("api/EmployeeData/{id:int}")]
        public Employee GetIdWiseEmployeeData(int Id)
        {
            ServiceResponse<List<Employee>> serviceReponse = new ServiceResponse<List<Employee>>();
            Employee dbObject = DBEntities.Employees.Where(m => m.Id == Id).FirstOrDefault();
           
            return dbObject;
        }
        [HttpPost, Route("api/AddEmployeeData")]
        public ServiceResponse<List<EmployeeVM>> CreateEmployee(EmployeeVM employee)
        {
            ServiceResponse<List<EmployeeVM>> serviceReponse = new ServiceResponse<List<EmployeeVM>>();
            try
            {
                List<EmployeeVM> newEmployee = new List<EmployeeVM>();
                newEmployee.Add(employee);
                using (DBEntities = new OmParmarContext())
                {
                    Employee dbObject = employee.ToContext();
                    // to avoid conflict of autogenerated id
                    dbObject.Id = new int();
                    DBEntities.Employees.Add(dbObject);
                    DBEntities.SaveChanges();

                    serviceReponse.data = newEmployee;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data added successfully";
                }
            }
            catch (Exception ex)
            {
                //serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();

            }
            return serviceReponse;

        }


        //[HttpPost, Route("api/UpdateEmployeeData/{id:int}")]
        [HttpPut, Route("api/UpdateEmployeeData/{id:int}")]
        public ServiceResponse<bool> UpdateEmployee(EmployeeVM employee)
        {
            ServiceResponse<bool> serviceReponse = new ServiceResponse<bool>();
            try
            {

                Employee dbObject = DBEntities.Employees.Where(m => m.Id == employee.Id).FirstOrDefault();
                if (dbObject == null)
                {
                    serviceReponse.data = false;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data does not exist";
                }
                else
                {
                    dbObject.Salary = employee.Salary;
                    dbObject.Age = employee.Age;
                    dbObject.Name = employee.Name;
                    dbObject.Department = employee.Department;

                    DBEntities.SaveChanges();

                    serviceReponse.data = true;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data Updated successfully";

                }

            }
            catch (Exception ex)
            {
                serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();

            }
            return serviceReponse;
        }



        [HttpDelete("api/DeleteEmployeeData/{id:int}")]
        public ServiceResponse<bool> DeleteEmployee(int id)
            {
            ServiceResponse<bool> serviceReponse = new ServiceResponse<bool>();
            try
            {

                Employee dbObject = DBEntities.Employees.Where(m => m.Id == id).FirstOrDefault();
                if (dbObject == null)
                {
                    serviceReponse.data = false;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data does not exist";
                }
                else
                {
                    DBEntities.Employees.Remove(dbObject);
                    DBEntities.SaveChanges();

                    serviceReponse.data = true;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data Deleted successfully";

                }
            }
            catch (Exception ex)
            {
                serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();

            }
            return serviceReponse;
        }







    }
}
