﻿namespace Eshopper.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
