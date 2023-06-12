using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymnasioEticBack.Models;

public partial class BaseArreglaaContext : DbContext
{
    public BaseArreglaaContext()
    {
    }

    public BaseArreglaaContext(DbContextOptions<BaseArreglaaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<EjerciciosHasRutina> EjerciciosHasRutinas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Herramientum> Herramienta { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaHasRutina> PersonaHasRutinas { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HJFI9OQ; Database=BaseArreglaa; Trusted_Connection=True; TrustServerCertificate=Yes ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Asistenc__814F3126222347CE");

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.PersonaId).HasColumnName("persona_ID");

            entity.HasOne(d => d.Persona).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asistenci__perso__33D4B598");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ejercici__3214EC077CB13DE0");

            entity.Property(e => e.EjercicioIdHerramienta).HasColumnName("Ejercicio_IdHerramienta");
            entity.Property(e => e.Maquina)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("maquina");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.VideoAsociado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Video_Asociado");

            entity.HasOne(d => d.EjercicioIdHerramientaNavigation).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.EjercicioIdHerramienta)
                .HasConstraintName("FK__Ejercicio__Ejerc__07C12930");
        });

        modelBuilder.Entity<EjerciciosHasRutina>(entity =>
        {
            entity.HasKey(e => e.RutinaEjercicio).HasName("PK__Ejercici__23E2F03ECD0DAD14");

            entity.ToTable("Ejercicios_has_Rutina");

            entity.Property(e => e.EjerciciosId).HasColumnName("Ejercicios_Id");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.RutinaId).HasColumnName("Rutina_id");
            entity.Property(e => e.Series).HasColumnName("series");

            entity.HasOne(d => d.Ejercicios).WithMany(p => p.EjerciciosHasRutinas)
                .HasForeignKey(d => d.EjerciciosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ejercicio__Ejerc__0A9D95DB");

            entity.HasOne(d => d.Rutina).WithMany(p => p.EjerciciosHasRutinas)
                .HasForeignKey(d => d.RutinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ejercicio__Rutin__0B91BA14");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEventos).HasName("PK__evento__19DEF4B9B2B8B51E");

            entity.ToTable("evento");

            entity.Property(e => e.IdEventos).HasColumnName("id_eventos");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PersonaId).HasColumnName("persona_ID");

            entity.HasOne(d => d.Persona).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__evento__persona___37A5467C");
        });

        modelBuilder.Entity<Herramientum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Herramie__3214EC07B62761E0");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3214EC2719B035BB");

            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Celular).HasColumnName("celular");
            entity.Property(e => e.Desahabilitado).HasColumnName("desahabilitado");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PersonaIdUsuario).HasColumnName("Persona_idUsuario");
            entity.Property(e => e.Rh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rh");
            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rol");

            entity.HasOne(d => d.PersonaIdUsuarioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.PersonaIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__Persona__38996AB5");
        });

        modelBuilder.Entity<PersonaHasRutina>(entity =>
        {
            entity.HasKey(e => e.RutinasPersona).HasName("PK__Persona___60022F078B0F89B3");

            entity.ToTable("Persona_has_Rutina");

            entity.Property(e => e.PersonaId).HasColumnName("persona_ID");
            entity.Property(e => e.RutinaId).HasColumnName("Rutina_Id");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaHasRutinas)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona_h__perso__3A81B327");

            entity.HasOne(d => d.Rutina).WithMany(p => p.PersonaHasRutinas)
                .HasForeignKey(d => d.RutinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona_h__Rutin__7A672E12");
        });

        modelBuilder.Entity<Rutina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rutina__3214EC072BF70B6C");

            entity.ToTable("Rutina");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipRutina)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tip_rutina");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6F1861799");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(105)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(105)
                .IsUnicode(false)
                .HasColumnName("correo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
