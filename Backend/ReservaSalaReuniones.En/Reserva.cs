﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaSalaReuniones.En
{
    public partial class Reserva
    {
        [Key]
        [Column("Id_Reserva")]
        public int IdReserva { get; set; }
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("Id_Sala")]
        public int IdSala { get; set; }
        [Column("Fecha_Inicio", TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }
        [Column("Fecha_Fin", TypeName = "datetime")]
        public DateTime FechaFin { get; set; }

        [Column("Color_Reserva")]
        [StringLength(100)]
        public string ColorReserva { get; set; }
        [Required]
        [Column("DescripcionReserva")]
        [StringLength(500)]
        public string DescripcionReserva { get; set; }

        public bool Estado { get; set; }

        [ForeignKey(nameof(IdSala))]
        [InverseProperty(nameof(SalaReuniones.Reserva))]
        public virtual SalaReuniones IdSalaNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Reserva))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}