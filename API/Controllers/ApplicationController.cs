using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
[EnableCors]
public class ApplicationController : ControllerBase
{
    
        private IApplicationService _applicationService;
        private IMapper _mapper;
    
        public ApplicationController(IApplicationService service, IMapper mapper)
        {
            _applicationService = service;
            _mapper = mapper;
        }
    
        [HttpPost]
        [Route("CreateDB")]
        public String CreateDB()
        {
            _applicationService.CreateDB();
            return "DB Has been created";
        }

        [HttpDelete]
        [Route("DeleteDB")]
        public void DeleteDB()
        {
            _applicationService.DeleteDB();
        }
        

}
