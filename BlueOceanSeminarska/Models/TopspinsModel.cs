using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlueOceanSeminarska.Models

{
    public class TopspinsModel

    {
        public int Id { get; set; }
        public string RemoteId { get; set; }
        public decimal RemoteIdCount { get; set; }
    }
}