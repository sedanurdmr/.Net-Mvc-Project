using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcprojee.ViewModel
{
    public class dersModel
    {
        public int dersid { get; set; }
        [Required(ErrorMessage ="Ders Adını giriniz")]
        [Display(Name ="Ders Adı")]
        public string dersadi { get; set; }
        [Required(ErrorMessage = "Öğretmen Adını giriniz")]
        [Display(Name = "Öğretmen Adı")]
        public string ogretmen { get; set; }
        [Required(ErrorMessage = "Ders Saatini giriniz")]
        [Display(Name = "Ders Saati")]
        public string derssaati { get; set; }
    }
}