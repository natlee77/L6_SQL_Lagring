using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library_SQL.Models//steg 1
{

    public class Customer //skapa 
    {
         [JsonProperty(PropertyName = "id")]  //json property for cosmos db||oavsätt var -- som  håller json 
        [Key]
        public int Id { get; set; }

          [JsonProperty(PropertyName = "firstName")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Customer(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}   
//++ class CodeFirstDbContext
//++ installed Entity ... sql server
//             entity ..tools