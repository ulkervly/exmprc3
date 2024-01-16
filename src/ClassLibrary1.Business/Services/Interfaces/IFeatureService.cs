using Hook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        Task CreateAsync(Feature feature);
        Task UpdateAsync(Feature feature);
        Task DeleteAsync(int id);
        Task<Feature> GetByExpression(Expression<Func<Feature,bool>>?expression=null,params string[] include);
        Task <List<Feature>> GetAllAsync(Expression<Func<Feature, bool>>? expression=null, params string[] include);
    }
}
