namespace SugerenciaPNetflix.ViewModel
{
    public class UsuarioVM
    {
        public int ID_Usuario { get; set; } // int Primary key identity NOT NULL,
        public string Nombre_usuario { get; set; } // varchar(50) not null,
        public DateTime fecha_nacimiento { get; set; } //date not null
        public List<TipoPeliculaVM> tipos { get; set; }
    } 
}
