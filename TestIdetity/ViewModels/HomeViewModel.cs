using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestIdetity.Models;

namespace TestIdetity.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Gig> UpComingGigs { get; set; }

        public bool Actions { get; set; }
        public string Heading { get; set; }
    }
}