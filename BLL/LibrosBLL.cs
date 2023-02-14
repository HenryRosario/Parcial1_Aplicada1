using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class LibrosBLL{
        private Contexto _contexto;

        public LibrosBLL(Contexto contexto){
            _contexto = contexto;
        }
        
        
        public bool Existe(int libroId){
            return _contexto.Libros.Any(o => o.LibroId == libroId);
        }

        private bool Insertar(Libros libros){
            _contexto.Libros.Add(libros);
            return _contexto.SaveChanges()> 0;
        }

        private bool Modificar(Libros libros){
            _contexto.Entry(libros).State = EntityState.Modified;
            return _contexto.SaveChanges()> 0;
        }

        public bool Guardar(Libros libros){
            if (!Existe(libros.LibroId))
                return this.Insertar(libros);
            else
                return this.Modificar(libros);
        }

      

        public Libros? Buscar(int LibroId){
            return _contexto.Libros
                    .Where(o=> o.LibroId== LibroId)
                    .AsNoTracking()
                    .SingleOrDefault();
                    
        }
        public List<Libros> GetList(Expression<Func<Libros, bool>> Criterio){
            return _contexto.Libros
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

}
        
        