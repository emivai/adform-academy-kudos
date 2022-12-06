﻿using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adform.Academy.Kudos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            var id = await _employeeService.AddAsync(employee);

            return Created($"/api/employees/{id}", employeeDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetAsync();

            return Ok(_mapper.Map<List<EmployeeDto>>(employees));
        }
    }
}