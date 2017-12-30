using DistributedToDo.DAL.Entities;
using System;

namespace DistributedToDo.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
