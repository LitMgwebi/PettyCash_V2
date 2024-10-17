﻿using System.Security.Claims;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private IDocument _document;
        private IRequisition _requisition;
        public DocumentsController(IDocument document, IRequisition requisition)
        {
            _document = document;
            _requisition = requisition;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Document>>> Index(string command, int requisitionId = 0)
        {
            try
            {
                IEnumerable<Document> documents = await _document.GetAll(command, requisitionId);
                return Ok(documents);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Motivation>> Details(string command, int id)
        {
            try
            {
                Document document = await _document.GetOne(command, id);
                return Ok(document);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public async Task<ActionResult<Document>> Create(UploadFile uploadFile)
        {
            try
            {
                string messageFromRequisition = string.Empty;
                var identity = (ClaimsIdentity)User.Identity!;
                string name = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault()!;
                string message = await _document.Upload(uploadFile.command, uploadFile.File, uploadFile.RequisitionId, name);

                Requisition requisition = await _requisition.GetOne(uploadFile.RequisitionId);

                messageFromRequisition = await _requisition.Edit(requisition, uploadFile.command, forDoc: true);

                return Ok(new { message = message });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Document document)
        {
            try
            {
                _document.Edit(document);
                return Ok(new { message = $"{document.FileName} has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpPut, Route("delete")]
        public async Task<ActionResult> Delete([FromBody]DeleteDocumentViewModel viewModel)
        {
            try
            {
                string message = await _document.SoftDelete(viewModel.document, viewModel.command);

                return Ok(new { message });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
