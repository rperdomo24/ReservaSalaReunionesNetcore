﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaSalaReuniones.En
{
    [Table("Sala_Reuniones")]
    public partial class SalaReuniones
    {
        public SalaReuniones()
        {
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        [Column("Id_Sala")]
        public int IdSala { get; set; }
        [Required]
        [Column("Nombre_Sala")]
        [StringLength(200)]
        public string NombreSala { get; set; }
        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [InverseProperty("IdSalaNavigation")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}