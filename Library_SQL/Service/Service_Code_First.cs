
using Library_SQL.Data;
using Library_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library_SQL.Services
{
    public static class Service_Code_First
    {
        public static async Task AddCustomerAsync(Customer customer)
        {
            using SQL_CodeFirstContext context = new SQL_CodeFirstContext();

            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customer>> GetCustomers()
        {
            using SQL_CodeFirstContext context = new SQL_CodeFirstContext();

            return await context.Customers.ToListAsync();
        }

        public static async Task<Customer> GetCustomer(int id)
        {
            using SQL_CodeFirstContext context = new SQL_CodeFirstContext();

            return await context.Customers.FindAsync(id);
        }

        public static async Task UpdateCustomer(int id, Customer updatedCustomer)
        {
            using SQL_CodeFirstContext context = new SQL_CodeFirstContext();

            var customer = await context.Customers.FindAsync(id);

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
            using SQL_CodeFirstContext context = new SQL_CodeFirstContext();

            var customer = await context.Customers.FindAsync(id);

            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }
    }
}
