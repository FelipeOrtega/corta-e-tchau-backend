using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using corta_e_tchau_backend.Repository;
using System;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Service
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _repository;
        private readonly NotificationContext _notificationContext;

        public SchedulingService(ISchedulingRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<SchedulingGetDTO> Get(DateTime dataFilter)
        {
            try
            {
                List<Scheduling> schedulings = _repository.FullList(dataFilter);
                List<SchedulingGetDTO> schedulingsDTO = new List<SchedulingGetDTO>();
                foreach (var scheduling in schedulings)
                {
                    scheduling.user.password = scheduling.user.password = "";
                    String data = scheduling.date_time.ToString("dd/MM/yyyy");
                    String hora = scheduling.date_time.ToString("HH:mm");
                    if (scheduling.user != null) 
                    {
                       scheduling.user.schedulings = null;
                    }    
                    schedulingsDTO.Add(new SchedulingGetDTO(data, hora, scheduling.description, scheduling.status, scheduling.user));
                }
                return schedulingsDTO;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public Scheduling Get(int codigo)
        {
            try
            {
                Scheduling scheduling = _repository.SelectById(codigo);
                return scheduling;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(Scheduling scheduling)
        {
            try
            {
                if (_repository.isShedulingEmpty(scheduling))
                {
                    int codigoSchedulingInserido = _repository.Insert(scheduling);
                    return codigoSchedulingInserido;
                }
                else
                {
                    _notificationContext.AddNotification("Horário indisponível.");
                }
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(Scheduling scheduling)
        {
            try
            {
                _repository.Update(scheduling);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Scheduling scheduling = _repository.SelectById(codigo);

                if (scheduling == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(scheduling);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
