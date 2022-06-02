using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteAPI_NETCORE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : ControllerBase
    {
        static List<Models.RestauranteModel> restaurantes;
        public static List<Models.RestauranteModel> MontaLista(String caminho)
        {
            restaurantes = new List<Models.RestauranteModel>();
            Models.RestauranteModel restauranteModel;
            var reader = new StreamReader(caminho.Replace("\"",""));
            var header = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                restauranteModel = new Models.RestauranteModel();
                var linha = reader.ReadLine().Split(",");
                restauranteModel.RestaurantName = linha[0];
                var horarios = linha[1].Trim().Split("-");
                restauranteModel.HorarioAbertura = Convert.ToDateTime(horarios[0]);
                restauranteModel.HorarioFechamento = Convert.ToDateTime(horarios[1]);
                restaurantes.Add(restauranteModel);
            }
            return restaurantes;
        }

        private readonly ILogger<RestauranteController> _logger;

        public RestauranteController(ILogger<RestauranteController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public String Post(String caminho)
        {
            try
            {
                Program.caminho = caminho;
                MontaLista(caminho);
                return "Lista de restaurantes cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                return "Caminho inválido, erro: "+ex;
            };
        }
        [HttpGet]
        public List<String> Get(String horario)
        {
            try {
            var horarioBusca = Convert.ToDateTime(horario);
            var restaurantesAbertos = new List<String>();
            foreach(var linha in restaurantes)
            {
                if (horarioBusca >= linha.HorarioAbertura && horarioBusca < linha.HorarioFechamento)
                {
                    restaurantesAbertos.Add(linha.RestaurantName+" está aberto e fechará às "+linha.HorarioFechamento.ToString("HH:mm"));
                }
            }
            if (restaurantesAbertos.Count == 0)
            {
                restaurantesAbertos.Clear();
                restaurantesAbertos.Add("Não há restaurantes abertos no momento.");
                return restaurantesAbertos;
            }
            return restaurantesAbertos;
            }
            catch (Exception ex)
            {
                List<String> erro;
                erro = new List<String>();
                erro.Add("Horário inválido ou lista não cadastrada, erro: " + ex);
                return erro;
            }
        }
    }
}
