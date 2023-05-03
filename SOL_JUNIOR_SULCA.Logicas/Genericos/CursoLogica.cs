using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Logicas.Genericos
{
    public class CursoLogica
    {
        private DataBaseContexto _contexto;
        private CursoRepositorio _cursoRepositorio;

        public List<Curso> Listar()
        {
            using (_contexto = new DataBaseContexto())
            {
                _cursoRepositorio = new CursoRepositorio(_contexto);
                return _cursoRepositorio.GetAll();
            }
        }

        public List<Curso> BuscarPorId(int id)
        {
            using (_contexto = new DataBaseContexto())
            {
                _cursoRepositorio = new CursoRepositorio(_contexto);
                return _cursoRepositorio.GetAllBy(x => x.Id == id);
            }
        }

        public void Guardar(Curso entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _cursoRepositorio = new CursoRepositorio(_contexto);
                _cursoRepositorio.Save(entidad);

                _contexto.SaveChanges();
            }
        }

        public void Actualizar(Curso entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _cursoRepositorio = new CursoRepositorio(_contexto);
                Curso _ = _cursoRepositorio.GetOne(x => x.Id == entidad.Id);
                if (_ != null)
                {
                    _.Descripcion = entidad.Descripcion;
                    _.Credito = entidad.Credito;
                    _cursoRepositorio.Update(_);
                    _contexto.SaveChanges();
                }
            }
        }
    }
}
