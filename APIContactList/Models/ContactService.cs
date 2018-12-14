using System.Collections.Generic;

namespace ContactList.Models
{
	public class ContactService
	{

		private ContactRepository _repository;

		public ContactService()
		{
			_repository = new ContactRepository();
		}

		public List<Contact> Get(string connStr)
		{
			return _repository.Get(connStr);
		}

		public int Add(Contact contact, string connStr)
		{
			return _repository.Add(contact, connStr);
		}

		public int Update(Contact contact, string connStr)
		{
			return _repository.Update(contact, connStr);
		}

		public int Delete(string id, string connStr)
		{
			return _repository.Delete(id, connStr);
		}
	}
}