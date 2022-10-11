﻿using EmployeeMicroservice.Models;
using EmployeeMicroservice.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EmployeeController : ControllerBase
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeeController));
        private readonly IEmpService ser;
        public EmployeeController(IEmpService _ser)
        {
            ser = _ser;
        }
        [HttpGet]
        [Route("GetEmployeeProfile/{employeeId}")]
        public Employee GetEmployeeProfile(int employeeId)
        {
            return ser.GetEmployeeprofile(employeeId);
            _log4net.Info("In employee controller HttpGet GetEmployeeProfile and" + employeeId + "is searched");
        }
        [HttpGet()]
        [Route("ViewEmployeeOffers/{employeeId}")]
        public async Task<IList<Offer>> ViewEmployeeOffers(int employeeId, string token)
        {

            return await ser.ViewEmployeeOffers(employeeId, token);
            _log4net.Info("In employee controller HttpGet ViewEmployeeOffers and" + employeeId + "is viewed");

        }
        [HttpGet]
        [Route("ViewMostLikedOffers/{employeeId}")]
        public async Task<IList<Offer>> ViewMostLikedOffers(int employeeId, string token)
        {
             return await ser.ViewMostLikedOffers(employeeId, token);
            _log4net.Info("In employee controller HttpGet ViewMostLikedOffers and" + employeeId + "is viewed");
        }

      
        }
    }




