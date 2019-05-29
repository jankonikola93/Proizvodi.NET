using DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using System.IO;
using System.Configuration;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProizvodiContext _context;
        private Dictionary<string, object> repositories;
        public UnitOfWork(ProizvodiContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository<TEntity>)repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void LogError(string error)
        {
            var LogDestination = ConfigurationManager.AppSettings["LogDestination"].ToString();
            StreamWriter SW;
            if (Directory.Exists(LogDestination))
            {
                var destination = System.IO.Path.Combine(LogDestination, "LogError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!File.Exists(destination))
                {
                    SW = File.CreateText(destination);
                    SW.Close();
                }

                using (SW = File.AppendText(destination))
                {
                    SW.Write("\r\n\n");
                    SW.WriteLine(DateTime.Now.ToString("dd-MM-yyyy H:mm:ss") + " " + error);
                    SW.Close();
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
