﻿using ExpressVoitures.Server.Models;

namespace ExpressVoitures.Server.Repositories
{
    public interface IVoitureRepository
    {
        public Task<IList<Voiture>> GetAll();
        public Task<Voiture?> GetById(int id);
        public Task<bool> Create(Voiture voiture);
        public Task<bool> Update(Voiture voiture);
        public Task<bool> DeleteById(int id);
    }
}
