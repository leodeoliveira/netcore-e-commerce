using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail> Details { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        public decimal OrderTotal { get; set; }

    }
}
