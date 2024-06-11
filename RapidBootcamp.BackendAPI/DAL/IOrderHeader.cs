﻿using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IOrderHeader : ICrud<OrderHeader>
    {
        //public IEnumerable<ViewOrderHeaderInfo> GetAllWithView();
        public string GetOrderLastHeaderId();
    }
}