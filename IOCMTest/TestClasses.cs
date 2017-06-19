using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCMTest
{
    public sealed class ImportAttribute : Attribute
    {
    }

   

    public interface ITimeProvider
    {
        DateTime GetCreatedOn();
    }

    public interface IUserRepository
    {
    }
    
    public class RealTimeProvider : ITimeProvider
    {
        public DateTime _createdOn;

        public RealTimeProvider()
        {
            _createdOn = DateTime.Now;
        }

        public DateTime GetCreatedOn()
        {
            return _createdOn;
        }
    }
    
    public class SqlUserRepository : IUserRepository
    {
    }

    public class InMemoryUserRepository : IUserRepository
    {
    }
    
    public abstract class UserServiceBase
    {
        protected UserServiceBase(IUserRepository repository)
        {
            this.Repository = repository;
        }

        public IUserRepository Repository { get; }
    }
    
    public class FakeUserService : UserServiceBase
    {
        public FakeUserService(IUserRepository repository)
            : base(repository)
        {
        }
    }
    
}
