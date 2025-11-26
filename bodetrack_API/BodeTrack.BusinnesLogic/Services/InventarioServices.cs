using BodeTrack.DataAccess.Repositories.General;
using BodeTrack.DataAccess.Repositories.Inventario;
using BodeTrack.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeTrack.BusinnesLogic.Services
{
    public class InventarioServices
    {
        private readonly EntradasRepository _entradasRespository;
        private readonly LotesRepository _lotesRepository;
        private readonly SalidasRepository _salidaRepository;

        public InventarioServices(
            EntradasRepository entradasRepository,
            LotesRepository lotesRepository,
            SalidasRepository salidaRepository
            )
        {
            _entradasRespository = entradasRepository;
            _lotesRepository = lotesRepository;
            _salidaRepository = salidaRepository;
        }

        #region Entradas

        public IEnumerable<tbEntradas> ListarEntradas()
        {
            try
            {
                var list = _entradasRespository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEntradas> result = null;
                return result;
            }
        }

        #endregion Entradas

        #region Lotes

        public IEnumerable<tbLotes> ListarLotes()
        {
            try
            {
                var list = _lotesRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbLotes> result = null;
                return result;
            }
        }

        #endregion Lotes

        #region Salidas

        public IEnumerable<tbSalidas> ListarSalidas()
        {
            try
            {
                var list = _salidaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSalidas> result = null;
                return result;
            }
        }

        #endregion Salidas
    }
}