using BodeTrack.DataAccess.General;
using BodeTrack.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeTrack.BusinnesLogic.Services
{
    public class GeneralServices
    {
        private readonly DepartamentoRepository _departamentoRepository;

        public GeneralServices(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        #region Departamentos
        public IEnumerable<tbDepartamentos> ListarDepartamentos()
        {
            try
            {
                var list = _departamentoRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbDepartamentos> result = null;
                return result;
            }
        }
        #endregion Departamentos
    }





}
