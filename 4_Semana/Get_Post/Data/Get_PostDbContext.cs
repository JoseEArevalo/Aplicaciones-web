namespace Get_Post.Data
{
    using Get_Post.Models;
    using Microsoft.EntityFrameworkCore;
    public class Get_PostDbContext:DbContext
    {
        public Get_PostDbContext(DbContextOptions db):base(db)
        {
            //que tipo de proyecto ????
            //conectar con una API de IA
        }

        public DbSet<TipoPreguntaModel> TipoPreguntas { get; set; }
        public DbSet<PreguntasModel> Preguntas { get; set; }
    }
}
