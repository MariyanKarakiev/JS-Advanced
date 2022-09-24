using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("partId")]
   public class CarPartInputDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
