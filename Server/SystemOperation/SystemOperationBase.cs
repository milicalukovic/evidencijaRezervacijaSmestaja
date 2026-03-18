using DBBroker;
using Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        //Template metod - OpsteIzvrsenjeSO i Izvrsenje odredjene SO

        protected GenericDBRepository repository;

        public SystemOperationBase()
        {
            repository = new GenericDBRepository();
        }


        public void ExecuteTemplate()
        {
            try
            {
                repository.OpenConnection();
                repository.BeginTransaction();

                ExecuteConcreteOperation();

                repository.Commit();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw;
            }
            finally
            {
                repository.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
