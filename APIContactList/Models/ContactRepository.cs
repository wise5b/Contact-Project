using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace ContactList.Models
{
	public class ContactRepository
	{
		private IDbConnection _db;

		public List<Contact> Get(string connStr)
		{

			_db = new SqlConnection(connStr);

			List<Contact> contacts = _db.Query<Contact>("dbo.GetContacts", commandType: CommandType.StoredProcedure).ToList();

			return contacts;
		}

		public int Add(Contact contact, string connStr)
		{
			SqlParameter[] parameters = {
								new SqlParameter("@Id", contact.Id),
								new SqlParameter("@FirstName", contact.FirstName),
								new SqlParameter("@LastName", contact.LastName),
								new SqlParameter("@Address", contact.Address),
								new SqlParameter("@City", contact.City),
								new SqlParameter("@State", contact.State),
								new SqlParameter("@Zip", contact.Zip),
								new SqlParameter("@Country", contact.Country),
								new SqlParameter("@HomePhone", contact.HomePhone),
								new SqlParameter("@MobilePhone", contact.MobilePhone),
								new SqlParameter("@WorkPhone", contact.WorkPhone),
								new SqlParameter("@Fax", contact.Fax),
								new SqlParameter("@Email", contact.Email),
								new SqlParameter("@Website", contact.Website),
								new SqlParameter("@Facebook", contact.Facebook),
								new SqlParameter("@Instagram", contact.Instagram)};

			var args = new DynamicParameters(new { });
			parameters.ToList().ForEach(p => args.Add(p.ParameterName, p.Value));

			_db = new SqlConnection(connStr);
			_db.Execute("dbo.UpdateContact", args, commandType: CommandType.StoredProcedure);
			return 1;
		}

		public int Update(Contact contact, string connStr)
		{
			SqlParameter[] parameters = {
								new SqlParameter("@Id", contact.Id),
								new SqlParameter("@FirstName", contact.FirstName),
								new SqlParameter("@LastName", contact.LastName),
								new SqlParameter("@Address", contact.Address),
								new SqlParameter("@City", contact.City),
								new SqlParameter("@State", contact.State),
								new SqlParameter("@Zip", contact.Zip),
								new SqlParameter("@Country", contact.Country),
								new SqlParameter("@HomePhone", contact.HomePhone),
								new SqlParameter("@MobilePhone", contact.MobilePhone),
								new SqlParameter("@WorkPhone", contact.WorkPhone),
								new SqlParameter("@Fax", contact.Fax),
								new SqlParameter("@Email", contact.Email),
								new SqlParameter("@Website", contact.Website),
								new SqlParameter("@Facebook", contact.Facebook),
								new SqlParameter("@Instagram", contact.Instagram)};

			var args = new DynamicParameters(new { });
			parameters.ToList().ForEach(p => args.Add(p.ParameterName, p.Value));

			_db = new SqlConnection(connStr);
			_db.Execute("dbo.UpdateContact", args, commandType: CommandType.StoredProcedure);
			return 1;
		}

		public int Delete(string id, string connStr)
		{
			SqlParameter[] parameters = { new SqlParameter("@Id", id) };

			var args = new DynamicParameters(new { });
			parameters.ToList().ForEach(p => args.Add(p.ParameterName, p.Value));
			_db = new SqlConnection(connStr);
     		_db.Execute("dbo.DeleteContact", args, commandType: CommandType.StoredProcedure);
			return 1;
		}
	}

}