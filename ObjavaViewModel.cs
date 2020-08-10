using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INSTA_APP.Models.ViewModel
{
    public class ObjavaViewModel
    {
        public string IDkorisnicko_ime { get; set; }

        [Required]
        public string datumStr { get; set; }
        public string opis { get; set; }
        public Nullable<int> total_like { get; set; }
        public string total_coment { get; set; }

        public string ImeProfile { get; set; }

        public int ID { get; set; }
    }
}