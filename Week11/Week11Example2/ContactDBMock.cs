using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11Example2
{
    class ContactDBMock : DataAccessLayer
    {
        List<ContactDTO> contacts = new List<ContactDTO>();
        public string CreateContact(ContactDTO contact)
        {
            contacts.Add(contact);
            return contact.Id;
        }

        public bool DelecteContactById(string id)
        {
            ContactDTO contact = contacts.Find(x => x.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                return true;
            }
            return false;
        }

        public bool ExecuteCommand(string command)
        {
            throw new NotImplementedException();
        }

        public List<ContactDTO> GetAllContacts()
        {
            return contacts;
        }

        public ContactDTO GetContactById(string id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public string UpdateContact(ContactDTO contact)
        {
            throw new NotImplementedException();
        }

        public string UpdateContact(string id, string name, string phone, string address)
        {
            throw new NotImplementedException();
        }

        string DataAccessLayer.ExecuteCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
