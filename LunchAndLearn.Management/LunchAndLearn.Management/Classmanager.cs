﻿using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;

namespace LunchAndLearn.Management
{
  public class ClassManager : IManagerClass<Class>
  {
    private readonly ILunchAndLearnRepository<Class> _lunchAndLearnRepository;

    public ClassManager(ILunchAndLearnRepository<Class> lunchAndLearnRepository)
    {
      _lunchAndLearnRepository = lunchAndLearnRepository;
    }

    public Class Get(int id)
    {
      return _lunchAndLearnRepository.Get(id);
    }

    public List<Class> GetAll()
    {
      return _lunchAndLearnRepository.GetAll().ToList();
    }

    public int Create(Class entity)
    {
      _lunchAndLearnRepository.Create(entity);
      _lunchAndLearnRepository.SaveChanges();
      return entity.ClassId;
    }

    public void Update(Class entity)
    {
      _lunchAndLearnRepository.Update(entity);
      _lunchAndLearnRepository.SaveChanges();
    }

    public void Delete(int id)
    {
      _lunchAndLearnRepository.Delete(id);
      _lunchAndLearnRepository.SaveChanges();
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          //Dispose of all repos used in this class here Example: _productRepository, _personRepository
          _lunchAndLearnRepository.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
