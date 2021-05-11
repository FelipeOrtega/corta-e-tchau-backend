using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using corta_e_tchau_backend.Repository;
using System;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly NotificationContext _notificationContext;

        public UserService(IUserRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<User> Get()
        {
            try
            {
                List<User> users = _repository.Get();
                return users;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public User Get(User user)
        {
            try
            {
                User User = _repository.Get(user.phone, user.password);
                return User;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public User Get(int codigo)
        {
            try
            {
                User user = _repository.SelectById(codigo);
                return user;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(User user)
        {
            try
            {
                int codigoUserInserido = _repository.Insert(user);
                return codigoUserInserido;
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(User user)
        {
            try
            {
                _repository.Update(user);
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
                User user = _repository.SelectById(codigo);

                if (user == null)
                {
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(user);
            }
            catch (Exception)
            {
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
