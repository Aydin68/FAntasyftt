﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FAntasyftt.Models
{
    public partial class Spieler
    {
        public Spieler()
        {
            Uebernehmen = new HashSet<Uebernehmen>();
        }

        public int SId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public double Preis { get; set; }
        public int Alter { get; set; }
        public int Trikotnummer { get; set; }
        public bool? Kapitaen { get; set; }
        public int TId { get; set; }
        [JsonIgnore]
        public virtual Team TIdNavigation{ get; set; }
        [JsonIgnore]
       
        public virtual ICollection<Uebernehmen> Uebernehmen { get; set; }
    }
}