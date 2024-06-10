using CRUD.Database;
using CRUD.Model.Request;
using CRUD.Model.Response;

namespace CRUD.Service
{
    public interface ICRUD
    {
        Response InsertData(InsertRequest request);
        List<SelectResponse> SelectData();
        Response UpdateData(UpdateRequest request);
        Response DeleteData(DeleteRequest request);
    }
    public class CRUDService : ICRUD
    {
        private readonly IDataAccess _dataAccess;
        public CRUDService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Response InsertData(InsertRequest request)
        {
            try
            {
                var Message = new Response();
                if (request != null)
                {
                    var data = _dataAccess.InsertData(request);
                    Message.message = data.ToString();


                }
                return Message;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectResponse> SelectData()
        {
            try
            {
                var datas = new List<SelectResponse>();

                var data = _dataAccess.SelectData();
                datas = data.ToList();

                return datas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response UpdateData(UpdateRequest request)
        {
            try
            {
                var Message = new Response();
                if (request != null)
                {
                    var data = _dataAccess.UpdateData(request);
                    Message.message = data.ToString();


                }
                return Message;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response DeleteData(DeleteRequest request)
        {
            try
            {
                var Message = new Response();
                if (request != null)
                {
                    var data = _dataAccess.DeleteData(request);
                    Message.message = data.ToString();


                }
                return Message;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
