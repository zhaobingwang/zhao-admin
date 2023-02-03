using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.Admin.ApplicationCore.Entities;

namespace Zhao.Admin.ApplicationCore.Interfaces
{
    public interface ISampleService
    {
        Task<Sample> CreateAsync(Sample sample);
        Task<List<Sample>> ListAsync();
        Task<Sample> GeyAsync(Guid id);
        Task UpdateAsync(Sample sample);
        Task DeleteAsync(Guid id);
    }
}
