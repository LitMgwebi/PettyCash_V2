﻿namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public interface IEditState
    {
        Task<string> EditRequisition(PettyCashContext db, Requisition requisition);
    }
}
