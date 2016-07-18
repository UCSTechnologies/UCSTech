using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GFS.Domain.Entities;

namespace GFS.Models
{
    public class FuneralItemIndexViewModel
    {
        public FuneralItem Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}