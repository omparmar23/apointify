﻿using apointify.Models;
using apointify.VirtualModels;

namespace apointify.ExtentionMethods
{
    public static class HelperClass
    {
        public static EmployeeVM ToModel(this Employee obj)
        {
            return new EmployeeVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                Salary = obj.Salary,
                Age = obj.Age,
                Department = obj.Department,
            };
        }
        public static Employee ToContext(this EmployeeVM obj)
        {
            return new Employee()
            {
                Id = obj.Id,
                Name = obj.Name,
                Salary = obj.Salary,
                Age = obj.Age,
                Department = obj.Department,
            };
        }
        
        
        public static User ToContext(this UserVM obj)
        {
            return new User()
            {
                UserId = obj.UserId,
                Name = obj.Name,
                Role = obj.Role,
                Username = obj.Username,
                Email = obj.Email,
                Password = obj.Password,
                MobileNumber = obj.MobileNumber,
                City = obj.City,
                InsertData = DateTime.Now,
                UpdatedDate =DateTime.Now,
            };
        }

        public static UserVM ToModel(this User obj)
        {
            return new UserVM()
            {
                Name = obj.Name,
                Role = obj.Role,
                Username = obj.Username,
                Email = obj.Email,
                Password = obj.Password,
                MobileNumber = obj.MobileNumber,
                City = obj.City,
                InsertData = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }


        public static CustomerVM ToModel(this Customer obj)
        {
            return new CustomerVM()
            {
                CustomerId = obj.CustomerId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MobileNo = obj.MobileNo,
                BirthDate = obj.BirthDate,
                UserName = obj.UserName,
                UserEmailAddress = obj.UserEmailAddress,
                Password = obj.Password,
                HomeAddress = obj.HomeAddress,
                City = obj.City,
                State = obj.State,
                Zipcode = obj.Zipcode,
                InsertedDate = obj.InsertedDate,
            };

        }
        public static Customer ToContext(this CustomerVM obj)
        {
            return new Customer()
            {
                CustomerId = obj.CustomerId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MobileNo = obj.MobileNo,
                BirthDate = obj.BirthDate,
                UserName = obj.UserName,
                UserEmailAddress = obj.UserEmailAddress,
                Password = obj.Password,
                HomeAddress = obj.HomeAddress,
                City = obj.City,
                State = obj.State,
                Zipcode = obj.Zipcode,
                InsertedDate = obj.InsertedDate,
            };
        }


        public static FirmDetail ToContext(this FirmDetailVM obj)
        {
            return new FirmDetail()
            {
                FirmId = obj.FirmId,
                Userid = obj.Userid,
                ServiceId = obj.ServiceId,
                ServiceType = obj.ServiceType,
                FirmName = obj.FirmName,
                FirmImage = obj.FirmImage,
                Email = obj.Email,
                MobileNumber = obj.MobileNumber,
                Address = obj.Address,
                City = obj.City,
                IsDeleted = obj.IsDeleted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }
        public static FirmDetailVM ToModel(this FirmDetail obj)
        {
            return new FirmDetailVM()
            {
                FirmId = obj.FirmId,
                Userid = obj.Userid,
                ServiceId = obj.ServiceId,
                ServiceType = obj.ServiceType,
                FirmName = obj.FirmName,
                FirmImage = obj.FirmImage,
                Email = obj.Email,
                MobileNumber = obj.MobileNumber,
                Address = obj.Address,
                City = obj.City,
                IsDeleted = Convert.ToBoolean(0),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }

        public static AppointmentVM ToContext(this Appointment obj)
        {
            return new AppointmentVM()
            {
                AppointmentId = obj.AppointmentId,
                UserId = obj.UserId,
                FirmId = obj.FirmId,
                AppointmentDate = obj.AppointmentDate,
                TimeSlot = obj.TimeSlot,
                IsDeleted = Convert.ToBoolean(0),
                InsertDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }

        public static Appointment ToContext(this AppointmentVM obj)
        {
            return new Appointment()
            {
                AppointmentId = obj.AppointmentId,
                FirmId = obj.FirmId,
                UserId = obj.UserId,
                AppointmentDate =obj.AppointmentDate,
                TimeSlot = obj.TimeSlot,
                IsDeleted = obj.IsDeleted,
                InsertDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }


    }
};
