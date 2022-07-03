﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public interface IContactTypeRepository : IRepository
    {
        IEnumerable<dbContactType> GetAll();
        dbContactType GetContactType(string name);
    }
}