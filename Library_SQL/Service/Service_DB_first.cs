using Library_SQL.Data;
using Library_SQL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library_SQL.Services
{
    public static class Service_DB_First
    {
        public static async Task AddCustomerAsync(Customere customere)
        {
            using SQL_DB_FirstContext context = new SQL_DB_FirstContext();

            context.Customeres.Add(customere);
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customere>> GetCustomers()
        {
            using SQL_DB_FirstContext context = new SQL_DB_FirstContext();

            return await context.Customeres.ToListAsync();
        }

        public static async Task<Customere> GetCustomer(int id)
        {
            using SQL_DB_FirstContext context = new SQL_DB_FirstContext();

            return await context.Customeres.FindAsync(id);
        }

        public static async Task UpdateCustomer(int id, Customere updatedCustomer)
        {
            using SQL_DB_FirstContext context = new SQL_DB_FirstContext();

            var customer = await context.Customeres.FindAsync(id);

            if (customer != null)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Email = updatedCustomer.Email;

                context.Entry(customer).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static async Task DeleteCustomer(int id)
        {
            using SQL_DB_FirstContext context = new SQL_DB_FirstContext();

            var customer = await context.Customeres.FindAsync(id);

            if (customer != null)
            {
                context.Customeres.Remove(customer);
                await context.SaveChangesAsync();
            }
        }
    }
}
