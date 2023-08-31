using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITC_Project_Manager.Models;

public partial class ItcpmContext : DbContext
{
    public ItcpmContext()
    {
    }

    public ItcpmContext(DbContextOptions<ItcpmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Facultad> Facultads { get; set; }

    public virtual DbSet<Observacion> Observacións { get; set; }

    public virtual DbSet<Presentacion> Presentacións { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Supervisor> Supervisors { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JAVIER; Database=ITCPM; Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activida__3213E83F400A10D4");

            entity.ToTable("actividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estudiante).HasColumnName("estudiante");
            entity.Property(e => e.Horas).HasColumnName("horas");
            entity.Property(e => e.Terminar)
                .HasColumnType("datetime")
                .HasColumnName("terminar");
            entity.Property(e => e.Titulo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.EstudianteNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Estudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__actividad__estud__5CD6CB2B");
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83FC7966B49");

            entity.ToTable("administrador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__administr__usuar__4222D4EF");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__docente__3213E83F390CC8E7");

            entity.ToTable("docente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Presentación).HasColumnName("presentación");
            entity.Property(e => e.Telefono)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.PresentaciónNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.Presentación)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__docente__present__5629CD9C");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__docente__usuario__5535A963");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estudian__3213E83F31FDC996");

            entity.ToTable("estudiante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Programa).HasColumnName("programa");
            entity.Property(e => e.Proyecto).HasColumnName("proyecto");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tipoIdentificacion");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.ProgramaNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__progr__4D94879B");

            entity.HasOne(d => d.ProyectoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Proyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__proye__4E88ABD4");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__usuar__4F7CD00D");
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facultad__3213E83F2DE3EE86");

            entity.ToTable("facultad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TelefonoContacto).HasColumnName("telefonoContacto");
        });

        modelBuilder.Entity<Observacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__observac__3213E83F0FD0FA39");

            entity.ToTable("observación");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DiaRealizada)
                .HasColumnType("datetime")
                .HasColumnName("diaRealizada");
            entity.Property(e => e.Proyecto).HasColumnName("proyecto");
            entity.Property(e => e.Tipo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.ProyectoNavigation).WithMany(p => p.Observacións)
                .HasForeignKey(d => d.Proyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__observaci__proye__52593CB8");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__presenta__3213E83FA1ABCD15");

            entity.ToTable("presentación");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Administrador).HasColumnName("administrador");
            entity.Property(e => e.DiaAsignado)
                .HasColumnType("datetime")
                .HasColumnName("diaAsignado");
            entity.Property(e => e.DiaPresentacion)
                .HasColumnType("datetime")
                .HasColumnName("diaPresentacion");
            entity.Property(e => e.Salon)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("salon");

            entity.HasOne(d => d.AdministradorNavigation).WithMany(p => p.Presentacións)
                .HasForeignKey(d => d.Administrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__presentac__admin__44FF419A");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__programa__3213E83F6847ED62");

            entity.ToTable("programa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Facultad).HasColumnName("facultad");
            entity.Property(e => e.NombrePrograma)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("nombrePrograma");

            entity.HasOne(d => d.FacultadNavigation).WithMany(p => p.Programas)
                .HasForeignKey(d => d.Facultad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__programa__facult__3F466844");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__proyecto__3213E83FEDA5AF7D");

            entity.ToTable("proyecto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumIntegrantes).HasColumnName("numIntegrantes");
            entity.Property(e => e.Presentación).HasColumnName("presentación");
            entity.Property(e => e.Tarjetas).HasColumnName("tarjetas");
            entity.Property(e => e.UltActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("ultActualizacion");

            entity.HasOne(d => d.PresentaciónNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Presentación)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__proyecto__presen__4AB81AF0");

            entity.HasOne(d => d.TarjetasNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Tarjetas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__proyecto__tarjet__49C3F6B7");
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supervis__3213E83FA12888C5");

            entity.ToTable("supervisor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Docente).HasColumnName("docente");
            entity.Property(e => e.Motivo)
                .HasColumnType("text")
                .HasColumnName("motivo");
            entity.Property(e => e.Proyecto).HasColumnName("proyecto");

            entity.HasOne(d => d.DocenteNavigation).WithMany(p => p.Supervisors)
                .HasForeignKey(d => d.Docente)
                .HasConstraintName("FK__superviso__docen__59FA5E80");

            entity.HasOne(d => d.ProyectoNavigation).WithMany(p => p.Supervisors)
                .HasForeignKey(d => d.Proyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__superviso__proye__59063A47");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tarjetas__3213E83F0E57448C");

            entity.ToTable("tarjetas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Extension)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("extension");
            entity.Property(e => e.FechaSubida)
                .HasColumnType("datetime")
                .HasColumnName("fechaSubida");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Titulo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83FCC807891");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("correo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
