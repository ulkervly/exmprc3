using Hook.Business.Exceptions.Common;
using Hook.Business.Services.Interfaces;
using Hook.Core.Entities;
using Hook.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task CreateAsync(Feature feature)
        {
          if (feature == null) throw new NullReferenceException(); 
          feature.CreatedTime = DateTime.UtcNow;
            feature.UpdatedTime = DateTime.UtcNow;
            await _featureRepository.CreateAsync(feature);
            await _featureRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
           if(id<0) throw new IdBelowZeroException();
           var feature=await _featureRepository.GetSingleAsync(x=>x.Id==id);
            if(feature is null) throw new NullReferenceException();
            _featureRepository.Delete(feature);
           await  _featureRepository.CommitAsync();
        }

        public async Task<List<Feature>> GetAllAsync(Expression<Func<Feature, bool>>? expression, params string[] include)
        {
            return await _featureRepository.GetAllWhere(expression, include).ToListAsync();
        }

        public async Task<Feature> GetByExpression(Expression<Func<Feature, bool>>? expression, params string[] include)
        {
            return await _featureRepository.GetSingleAsync(expression, include);
        }

        public async Task UpdateAsync(Feature feature)
        {
            if (feature == null) throw new NullReferenceException();
            var existfeature = await _featureRepository.GetSingleAsync(x=>x.Id==feature.Id && !x.IsDeleted);
            existfeature.Title = feature.Title;
            existfeature.Description = feature.Description;
            existfeature.ButtonName = feature.ButtonName;
            existfeature.UpdatedTime = DateTime.UtcNow;
            await _featureRepository.CreateAsync(feature);
            await _featureRepository.CommitAsync();

        }
    }
}
