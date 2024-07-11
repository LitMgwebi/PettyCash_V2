﻿namespace PettyCashPrototype.Services.RequisitionService
{
    public interface IRequisition
    {
        public Task<IEnumerable<Requisition>> GetAll(string purpose, int divisionId, int jobTitleId, string userId);
        public Task<Requisition> GetOne(int id);
        public Task Create(Requisition requisition);
        public void Edit(Requisition requisition);
        public void SoftDelete(Requisition requisition);
    }
}
