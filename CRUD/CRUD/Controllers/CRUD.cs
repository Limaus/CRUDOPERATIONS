using CRUD.Database;
using CRUD.Model.Request;
using CRUD.Model.Response;
using CRUD.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CRUD : ControllerBase
    {
       
        private readonly ICRUD _crud;
        private readonly IDataAccess _dataAccess;
        private IConfiguration _config;
        public CRUD(ICRUD crud, IDataAccess dataAccess)
        {
            _crud = crud;
            _dataAccess = dataAccess;

        }

        [HttpPost]
        [Route("InsertData")]
        public Response InsertData(InsertRequest request)
        {
            try
            {

                var response = _crud.InsertData(request);
                var mssg = response.message;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SelectEmployeeData")]
        public List<SelectResponse> SelectData()
        {
            try
            {

                var response = _crud.SelectData();
               

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("UpdateEmployeeData")]
        public Response UpdateData(UpdateRequest request)
        {
            try
            {

                var response = _crud.UpdateData(request);
                var mssg = response.message;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("DeleteEmployeeData")]
        public Response DeleteData(DeleteRequest request)
        {
            try
            {

                var response = _crud.DeleteData(request);
                var mssg = response.message;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
