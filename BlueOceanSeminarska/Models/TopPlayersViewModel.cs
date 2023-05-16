using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlueOceanSeminarska.Models
{
        public class TopPlayersViewModel
        {
            public int Id { get; set; }
            public string RemoteId { get; set; }
            [DisplayFormat(DataFormatString = "{0:n2}")]
            public decimal? SumAmount { get; set; }
            public DateTime? Datum { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
    }
    
}