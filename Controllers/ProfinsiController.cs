using AutoMapper;
using KlinikAPI.DTOS;
using KlinikAPI.Interfaces;
using KlinikAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Controllers
{
    
    public class ProfinsiController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ProfinsiController(IUnitOfWork uow,IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        //Get /api/profinsi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sel = await uow.ProfinsiRepository.GetProfinsisAsync();
            var seldto = mapper.Map<IEnumerable<ProfinsiDTO>>(sel);
            //var seldto = (from s in sel select new ProfinsiDTO() { id = s.id, name = s.name }); sebelum pake automapper
            return Ok(seldto); 
        }

        //Get /api/profinsi/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Profinsi profinsi = await uow.ProfinsiRepository.GetProfinsisIdAsync(id);

            return Ok(profinsi);
        }

        //Get /api/profinsi/GetName/Sumatera
        [HttpGet("GetName/{nama}")]
        public async Task<IEnumerable<Profinsi>> GetName(string nama)
        {
            var profinsi = await uow.ProfinsiRepository.GetProfinsisNameAsync(nama);
            return profinsi;
        }

        //Post /api/profinsi/addProfinsi/
        [HttpPost("addProfinsi")]
        public async Task<IActionResult> AddProfinsi(ProfinsiDTO ProfinsiDTO)
        {
            var profinsi = mapper.Map<Profinsi>(ProfinsiDTO);
            profinsi.updated_by = 1;
            profinsi.updated_date = System.DateTime.Now;
            //var profinsi = new Profinsi
            //{
            //    name = ProfinsiDTO.name,
            //    updated_date = System.DateTime.Now,
            //    updated_by = 1
            //};
            await uow.ProfinsiRepository.AddProfinsi(profinsi);
            await uow.save();
            return StatusCode(201);
        }

        [HttpPut("{ProfinsiId}")]
        public async Task<IActionResult> Update(int ProfinsiId, ProfinsiDTO ProfinsiDTO)
        {
            if (ProfinsiId != ProfinsiDTO.id)
                return BadRequest("Update Not Allowed");

            var sel = await uow.ProfinsiRepository.GetProfinsisIdAsync(ProfinsiId);
            if (sel == null)
                return BadRequest("Update Not Allowed");

            sel.updated_by = 1;
            sel.updated_date = System.DateTime.Now;
            mapper.Map(ProfinsiDTO, sel);

            //throw new Exception("Some Unknown Error Occured"); //test exception 
            await uow.save();
            return StatusCode(200);
        }

        [HttpPatch("{ProfinsiId}")] //tidak di implementasiin di project hanya untuk belajar saja
        public async Task<IActionResult> UpdatePatch(int ProfinsiId, JsonPatchDocument<Profinsi> ProfinsiToPatch)
        {

            var sel = await uow.ProfinsiRepository.GetProfinsisIdAsync(ProfinsiId);            
            sel.updated_by = 1;
            sel.updated_date = System.DateTime.Now;
            ProfinsiToPatch.ApplyTo(sel,ModelState);
            await uow.save();
            return StatusCode(200);
        }

        //Get /api/profinsi/8 menggunakan html verb delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await uow.ProfinsiRepository.DeleteProfinsi(id);
            await uow.save();
            return Ok(id);
        }

        ////Function dibawah cuma coba2 saat belajar
        ////Post /api/profinsi/add?profinsiname=Lampung
        ////Post /api/profinsi/add/Kepri
        //[HttpPost("add")]
        //[HttpPost("add/{profinsiname}")]
        //public async Task<IActionResult> AddProfinsi(string ProfinsiName)
        //{
        //    Profinsi profinsi = new Profinsi();
        //    profinsi.name = ProfinsiName;
        //    await dc.tProfinsi.AddAsync(profinsi);
        //    await dc.SaveChangesAsync();
        //    return Ok(profinsi);
        //}

    }
}
