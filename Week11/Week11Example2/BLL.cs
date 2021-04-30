using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11Example2
{
    interface DataAccessLayer
    {
        ContactDTO GetContactById(string id);
        string CreateContact(ContactDTO contact);
        bool DelecteContactById(string id);
        List<ContactDTO> GetAllContacts();

        string UpdateContact(string id, string  name, string phone, string address);


        string ExecuteCommand(string command);
    }

    abstract class BaseContact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Addr { get; set; }
    }

    class CreateContactCommand : BaseContact
    {

    }

    class ContactDTO : BaseContact
    {
        public string Id { get; set; }
    }

    class BLL
    {
        DataAccessLayer dal = default(DataAccessLayer);
        public BLL(DataAccessLayer dal)
        {
            this.dal = dal;
        }
        public ContactDTO GetContact(string id)
        {
            return dal.GetContactById(id);
        }
        public string CreateContact(CreateContactCommand contact)
        {
            ContactDTO contact1 = new ContactDTO();
            contact1.Id = Guid.NewGuid().ToString();
            contact1.Name = contact.Name;
            contact1.Addr = contact.Addr;
            contact1.Phone = contact.Phone;
            return dal.CreateContact(contact1);
        }
        public bool DelecteContact(string id)
        {
            return dal.DelecteContactById(id);
        }

        /*public string UpdateContact(ContactDTO contact)
        {
            return dal.UpdateContact(contact);
        }*/
        public string UpdateContact(string id, string name, string phone, string address)
        {
            return dal.UpdateContact(id, name, phone, address);
        }
        public List<ContactDTO> GetContacts()
        {
            return dal.GetAllContacts();
        }
        public string ExecuteCommand(string command)
        {
            return dal.ExecuteCommand(command);
        }
    }
}
