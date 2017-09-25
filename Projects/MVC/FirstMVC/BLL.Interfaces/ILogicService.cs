using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
  public  interface  ILogicService<T>
    {
        IList<T> GetPage(int page, int pagesize);
        T GetById(int id);
        T CreateObj();
        void SaveObj(T src);
        T GetByIdForEdit(int id);
        void UpdateObj(T src);
        void DeleteObj(int id);

    }
}
