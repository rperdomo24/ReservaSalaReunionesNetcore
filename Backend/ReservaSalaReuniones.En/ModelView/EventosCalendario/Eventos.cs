using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.En.ModelView.EventosCalendario
{
    public class Eventos
    {
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; } = false;
        public string backgroundColor { get; set; }

    }
}
