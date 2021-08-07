using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Helpers;
using API.Extensions;
using Newtonsoft.Json;
using API.Data;

namespace API.Controllers
{
    [Authorize]
    public class FormationController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly DataContext _context;
        public FormationController(DataContext context, IUnitOfWork unitOfWork, IMapper mapper,
            IPhotoService photoService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult<List<Formation>>> AddFormations([FromBody] Request results)
        {
            List<Formation> formations = new List<Formation>();
            foreach (FormationDto fd in results.ecoles)
            {
                var split = fd.Ville.Split(' ');
                var formation = new Formation()
                {
                    Name = fd.Name,
                    Ville = split[0],
                    Phone = split[1],
                    Site = fd.Site,
                    Secteur = fd.Secteur,
                    Etablissement = fd.Etablissement,
                    Adresse = fd.Adresse,
                    Domaine = results.Secteur
                };
                formations.Add(formation);
            }
            this._context.AddRange(formations);
            await this._context.SaveChangesAsync();
            return Ok(formations);
            
            }

            [HttpGet("FormationsByDomaine")]
        public async Task<ActionResult<IEnumerable<FormationDto>>>  GetFormations([FromQuery]FormationParams formationParams )
        {

            var formations= await  _unitOfWork.FormationRepository.GetFormations(formationParams);

          Response.AddPaginationHeader(formations.CurrentPage,formations.PageSize, formations.TotalCount,
                                       formations.TotalPages);
            return Ok(formations);
        }

         [HttpGet("Formations/{Id}")]
        public async Task<ActionResult<IEnumerable<FormationDto>>>  GetFormation(int id ){

            var formations= await _unitOfWork.FormationRepository.GetFormation(id);

return Ok(formations);
        }



        }    public class Request
    {
        public string Secteur { get; set; }
        public List<FormationDto> ecoles { get; set; }
    }
}