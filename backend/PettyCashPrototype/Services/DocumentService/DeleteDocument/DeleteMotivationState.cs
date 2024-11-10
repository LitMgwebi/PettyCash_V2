namespace PettyCashPrototype.Services.DocumentService.DeleteDocument
{
    public class DeleteMotivationState: IDeleteDocument
    {
        public async Task<string> DeleteDocument(PettyCashContext db, IRequisition _requisition, Document document)
        {
            Requisition requisition = await _requisition.GetOne(document.RequisitionId);
            if (requisition.ManagerId == null)
            {
                document.IsActive = false;
                db.Documents.Update(document);
                int result = await db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not delete ${document.FileName}.{document.FileExtension}.");

                return "Motivation has successfully been deleted.";
            }
            else
                throw new Exception("Your requisition has already been processed by your line manager. You cannot delete your motivation.");
        }
    }
}
