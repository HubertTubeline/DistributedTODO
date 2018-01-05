﻿using DistributedToDo.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace DistributedToDo.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        ClientProfile GetClient(string login);
        void Edit(ClientProfile profile);
    }
}
