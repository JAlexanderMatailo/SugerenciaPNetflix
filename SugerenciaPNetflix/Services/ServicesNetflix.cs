﻿using Microsoft.EntityFrameworkCore;
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

        #endregion


    }

}
