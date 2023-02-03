using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.Admin.ApplicationCore.Entities;
using Zhao.Admin.ApplicationCore.Interfaces;

namespace Zhao.Admin.ApplicationCore.Services
{
    public class SampleService : ISampleService
    {
        private readonly IRepository<Sample> _sampleRepository;

        public SampleService(IRepository<Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }
        public async Task<Sample> CreateAsync(Sample sample)
        {
            var result = await _sampleRepository.AddAsync(sample);
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _sampleRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception($"No entity object of {nameof(Sample)} was found by id={id}");
            }
            await _sampleRepository.DeleteAsync(entity);
        }

        public async Task<Sample> GeyAsync(Guid id)
        {
            var entity = await _sampleRepository.GetByIdAsync(id);
            return entity;
        }

        public async Task<List<Sample>> ListAsync()
        {
            var entities = await _sampleRepository.ListAsync();
            return entities;
        }

        public async Task UpdateAsync(Sample sample)
        {
            await _sampleRepository.UpdateAsync(sample);
        }
    }
}
