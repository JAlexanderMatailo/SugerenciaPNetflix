using Microsoft.EntityFrameworkCore;
using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Services
{
    public class ServicesNetflix : IServicioNetflix
    {
        SugerencaPeliculaContext _context;
        public ServicesNetflix(SugerencaPeliculaContext context)
        {
            _context = context;
        }

        #region TipoPelicula
        public bool registrarTipoPelicula(TipoPeliculaVM tipopel)
        {
            var existe = _context.TipoPeliculas.Where(x => x.NombreTipoPelicula == tipopel.nombre_TipoPelicula).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context = _context.Database.BeginTransaction())
                {
                    try
                    {
                        TipoPelicula tipo = new TipoPelicula
                        {
                            NombreTipoPelicula = tipopel.nombre_TipoPelicula
                        };
                        _context.TipoPeliculas.Add(tipo);
                        _context.SaveChanges();

                        context.Commit();

                        registrado = true;
                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = false;
                    }
                }
            }
            return registrado;
        }

        public List<TipoPeliculaVM> GetAllTipoPelicula()
        {
            List<TipoPeliculaVM> ListaTipoPeliculas = new List<TipoPeliculaVM>();
            var tipoPelicula = _context.TipoPeliculas.ToList();
            foreach (var item in tipoPelicula)
            {
                TipoPeliculaVM tipoP = new TipoPeliculaVM
                {
                    Id_TipoPelicula = item.IdTipoPelicula,
                    nombre_TipoPelicula = item.NombreTipoPelicula
                };
                ListaTipoPeliculas.Add(tipoP);
            };
            return ListaTipoPeliculas;
        }

        public bool actualizarTipoPelicula(TipoPeliculaVM tipopel)
        {
            var tipoPeliculaExiste = _context.TipoPeliculas.FirstOrDefault(x => x.IdTipoPelicula == tipopel.Id_TipoPelicula);
            if (tipoPeliculaExiste != null)
            {
                tipoPeliculaExiste.NombreTipoPelicula = tipopel.nombre_TipoPelicula;
            }
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false; // No se encontró el tipo de pelicula a actualizar
        }
        #endregion

        #region Usuario

        public bool registrarUsuario(UsuarioVM usuario)
        {
            var existe = _context.Usuarios.Where(x => x.NombreUsuario == usuario.Nombre_usuario).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Usuario user = new Usuario
                        {
                            NombreUsuario = usuario.Nombre_usuario,
                            FechaNacimiento = usuario.fecha_nacimiento
                        };
                        _context.Usuarios.Add(user);
                        _context.SaveChanges();
                        int codigo = _context.Usuarios.Where(x => x.NombreUsuario == usuario.Nombre_usuario).FirstOrDefault().IdUsuario;
                        if (usuario.tipos != null)
                        {
                            foreach (var item in usuario.tipos)
                            {
                                UsuarioTipoPelicula relacion = new UsuarioTipoPelicula
                                {
                                    IdUsuario = codigo,
                                    IdTipoPelicula = item.Id_TipoPelicula
                                };
                                _context.UsuarioTipoPeliculas.Add(relacion);
                                _context.SaveChanges();
                            }
                        }
                        context.Commit();

                        registrado = true;
                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = false;
                    }
                }
            }
            return registrado;
        }

        public List<UsuarioVM> GetAllUsuarios()
        {
            List<UsuarioVM> listaUsuarios = new List<UsuarioVM>();
            var UsuariolIsta = _context.Usuarios.ToList();
            foreach (var item in UsuariolIsta)
            {
                UsuarioVM usuarios = new UsuarioVM
                {
                    ID_Usuario = item.IdUsuario,
                    Nombre_usuario = item.NombreUsuario,
                    fecha_nacimiento = item.FechaNacimiento
                };
                listaUsuarios.Add(usuarios);
            };
            return listaUsuarios;
        }

        public bool actualizarUsuarios(UsuarioVM usuarios)
        {
            var usuarioExiste = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == usuarios.ID_Usuario);
            if (usuarioExiste != null)
            {
                usuarioExiste.NombreUsuario = usuarios.Nombre_usuario;
                usuarioExiste.FechaNacimiento = usuarios.fecha_nacimiento;
            }
            try
            {
                _context.SaveChanges();
                int codigo = _context.Usuarios.Where(x => x.NombreUsuario == usuarios.Nombre_usuario).FirstOrDefault().IdUsuario;
                if (usuarios.tipos != null)
                {
                    foreach (var item in usuarios.tipos)
                    {
                        UsuarioTipoPelicula relacion = new UsuarioTipoPelicula
                        {
                            IdUsuario = codigo,
                            IdTipoPelicula = item.Id_TipoPelicula
                        };
                        _context.UsuarioTipoPeliculas.Add(relacion);
                        _context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        #endregion

        #region Peliculas
        public bool registrarPeliculas(PeliculaVM peliculaVM)
        {
            var existe = _context.Peliculas.Where(x => x.NombrePelicula == peliculaVM.nombre_pelicula).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Pelicula pelicula = new Pelicula
                        {
                            NombrePelicula = peliculaVM.nombre_pelicula,
                            DuracionPelicula = peliculaVM.duracion_pelicula,
                            Imagen = peliculaVM.imagen
                        };
                        _context.Peliculas.Add(pelicula);
                        _context.SaveChanges();
                        int codigo = _context.Peliculas.Where(x => x.NombrePelicula == peliculaVM.nombre_pelicula).FirstOrDefault().IdPelicula;
                        if (peliculaVM.tipos_pelicula != null)
                        {
                            foreach (var item in peliculaVM.tipos_pelicula)
                            {
                                PeliculaTipoPelicula relacion = new PeliculaTipoPelicula
                                {
                                    IdPelicula = codigo,
                                    IdTipoPelicula = item.Id_TipoPelicula
                                };
                                _context.PeliculaTipoPeliculas.Add(relacion);
                                _context.SaveChanges();
                            }
                        }
                        context.Commit();
                        registrado = true;

                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = false;
                    }
                }
            }
            return registrado;
        }

        public List<PeliculaVM> GetAllPeliculas()
        {
            List<PeliculaVM> listapelicula = new List<PeliculaVM>();
            var peliculas = _context.Peliculas.ToList();
            foreach (var item in peliculas)
            {
                PeliculaVM pelicula = new PeliculaVM
                {
                    Id_Pelicula = item.IdPelicula,
                    nombre_pelicula = item.NombrePelicula,
                    duracion_pelicula = item.DuracionPelicula
                };
                listapelicula.Add(pelicula);
            };
            return listapelicula;
        }

        public bool actualizarPelicula(PeliculaVM pelicula)
        {
            var peliculaExiste = _context.Peliculas.FirstOrDefault(x => x.IdPelicula == pelicula.Id_Pelicula);
            if (peliculaExiste != null)
            {
                peliculaExiste.NombrePelicula = pelicula.nombre_pelicula;
                peliculaExiste.DuracionPelicula = pelicula.duracion_pelicula;
            }
            try
            {
                _context.SaveChanges();
                int codigo = _context.Peliculas.Where(x => x.NombrePelicula == pelicula.nombre_pelicula).FirstOrDefault().IdPelicula;
                if (pelicula.tipos_pelicula != null)
                {
                    foreach (var item in pelicula.tipos_pelicula)
                    {
                        PeliculaTipoPelicula relacion = new PeliculaTipoPelicula
                        {
                            IdPelicula = codigo,
                            IdTipoPelicula = item.Id_TipoPelicula
                        };
                        _context.PeliculaTipoPeliculas.Add(relacion);
                        _context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        #endregion

    }

}
