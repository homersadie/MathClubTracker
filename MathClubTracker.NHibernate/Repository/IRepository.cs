//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for NHibernate model.
// Code is generated on: 10/6/2013 4:01:09 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace MathClubTracker.NHibernate
{
    public partial interface IRepository<T>
    {
        T Add(T entity);
        void Remove(T entity);
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);

        ICollection<T> GetAll();

    }
}