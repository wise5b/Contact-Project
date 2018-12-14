using ContactList.Models;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ContactList.Controllers
{
    [Authorize(Roles = "1")]
    public class ContactController : Controller
    {

        private ContactService _service;

        public ContactController()
        {
            _service = new ContactService();
        }

        public string Get()
        {
            string connStr = GetConnStr();

            var model = _service.Get(connStr);

            string strJson;
            JavaScriptSerializer json = new JavaScriptSerializer()
            {
                MaxJsonLength = Globals.maxValue
            };
            strJson = json.Serialize(model);
            return strJson;
        }

		public int Add(Contact contact)
		{
			string connStr = GetConnStr();

			try
			{
				int result = _service.Add(contact, connStr);
				return result;
			}
			catch (System.Exception ex)
			{
				return ex.HResult;
			}
		}

		public int Update(Contact contact)
        {
            string connStr = GetConnStr();

            try
            {
				int result = _service.Update(contact, connStr);
				return result;
            }
            catch (System.Exception ex)
            {
				return ex.HResult;
            }
        }

		public int Delete(string id)
		{
			string connStr = GetConnStr();

			try
			{
				int result = _service.Delete(id, connStr);
				return result;
			}
			catch (System.Exception ex)
			{
				return ex.HResult;
			}
		}

		private string GetConnStr()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var tid = identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                string upn = identity?.Name;
                TenantController tc = new TenantController();
                return tc.GetConnStr(tid, upn);
            }
            else {
                return "";
            }
        }

    }
}
