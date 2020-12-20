using Microsoft.EntityFrameworkCore;
using OngPetCare.Api.Dto;
using OngPetCare.infra.Context;
using OngPetCare.infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngPetCare.Api.Services
{
    public class AnimalService
    {
        private readonly DataBaseContext _context;

        public AnimalService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Create(AnimalDto dto)
        {           
            try
            {
                long newId = _context.Animals.OrderByDescending(x => x.Id).First().Id + 1;
                Animal model = new Animal()
                {
                    Id = newId,
                    Nome = dto.Nome,
                    Observacoes = dto.Observacoes,
                    DataChegada = dto.DataChegada,
                    Raca = dto.Raca
                };

                var result = _context.Animals.Add(model);

                if (await _context.SaveChangesAsync() > 0)
                    return model;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetById(long id)
        {
            try
            {
                return await _context.Animals
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> Update(AnimalDto animal)
        {
            try
            {
                var entity = await _context.Animals.FirstOrDefaultAsync(x => x.Id == animal.Id);
                if (entity != null)
                {
                    entity.Nome = animal.Nome;
                    entity.Raca = animal.Raca;
                    entity.Observacoes = animal.Observacoes;
                    entity.DataChegada = animal.DataChegada;

                    return await _context.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> Delete(long id)
        {
            try
            {
                _context.Animals.Remove(new Animal { Id = id });
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> List()
        {
            try
            {
                return await _context.Animals.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
