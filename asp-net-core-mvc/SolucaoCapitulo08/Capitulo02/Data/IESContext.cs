﻿using Capitulo02.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Discente;

namespace Capitulo02.Data
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {
        private object bc;

        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Academico> Academicos { get; set; }
        //public DbSet<UsuarioDaAplicacao> UsuariosDaAplicação { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.CursoID, cd.DisciplinaID });

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(d => d.DisciplinaID);
        }
    }
}
