﻿using Homework19.Models;
using Homework19.Services.Interfaces;
using Hommework19.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Homework19.Services.Runtime
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly DataBaseContext _context;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            var optionsMSSQL = new DbContextOptionsBuilder<DataBaseContext>();

            optionsMSSQL.UseSqlServer(_configuration["ConnectionString"]);

            _context = new(optionsMSSQL.Options);

            if(_context.Contacts.Count() < 1)
            {
                Task.Run(async () => 
                {
                    await _context.Contacts.AddRangeAsync([
                    new(){
                        LastName = "Иванов",
                        FirstName = "Иван",
                        MiddleName = "Иванович",
                        Address = "Россия, г. Москва, ул. Пушкина, д. Колотушкина, 1",
                        PhoneNumber = "321-00-01",
                        Description = "Жилец квартиры 1"
                    },
                    new(){
                        LastName = "Петров",
                        FirstName = "Петр",
                        MiddleName = "Петрович",
                        Address = "Россия, г. Москва, ул. Пушкина, д. Колотушкина, 2",
                        PhoneNumber = "321-00-02",
                        Description = "Жилец квартиры 2"
                    },
                    new(){
                        LastName = "Ильин",
                        FirstName = "Илья",
                        MiddleName = "Ильич",
                        Address = "Россия, г. Москва, ул. Пушкина, д. Колотушкина, 3",
                        PhoneNumber = "321-00-03",
                        Description = "Жилец квартиры 3"
                    },
                ]);

                    await _context.SaveChangesAsync();
                });
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            var result = Enumerable.Empty<Contact>();

            try
            {
                result = _context.Contacts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public Contact? GetContact(int id)
        {
            Contact? result = null;

            try
            {
                result = _context.Contacts.Where(_ => _.Id == id).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
    }
}
