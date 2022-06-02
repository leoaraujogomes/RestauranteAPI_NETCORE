using System;

namespace RestauranteAPI_NETCORE.Models
{
    public class RestauranteModel
    {
        public string RestaurantName { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
    }
}
