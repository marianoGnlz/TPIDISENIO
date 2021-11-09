using DomusTPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomusTPI.IServices
{
    public interface ICalendarioService
    {
        Request<IList<Calendario>> GetCalendarios();
        Request<Calendario> GetCalendario(int id);
        Request<Calendario> Save(Calendario calendario);
        Request<Calendario> Update(Calendario calendario);
        Request<Calendario> Delete(int id);
    }
}
