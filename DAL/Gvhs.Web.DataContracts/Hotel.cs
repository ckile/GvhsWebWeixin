using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gvhs.Web.DataContracts
{
    public class EHotel : IEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Remark { get; set; }

        [StringLength(200)]
        public string ImgUrl { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Phone]
        public string Mobile { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Phone]
        public string Fax { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string WWW { get; set; }

    }
}
