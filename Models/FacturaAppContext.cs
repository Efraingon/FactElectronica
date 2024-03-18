using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FactElectronica.Models;

public partial class FacturaAppContext : DbContext
{
    public FacturaAppContext()
    {
    }

    public FacturaAppContext(DbContextOptions<FacturaAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticuloInventario> ArticuloInventarios { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<RenglonFactura> RenglonFacturas { get; set; }

    public virtual DbSet<Vendedor> Vendedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HA6EJBN\\SQLEXPRESS;Database=FacturaApp;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticuloInventario>(entity =>
        {
            entity.HasKey(e => new { e.Consecutivo, e.Codigo }).HasName("p_ArticuloInventario");

            entity.ToTable("ArticuloInventario");

            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AlicuotaIva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CostoUnitario).HasColumnType("money");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(7000)
                .IsUnicode(false);
            entity.Property(e => e.Existencia).HasColumnType("money");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrecioConIva).HasColumnType("money");
            entity.Property(e => e.PrecioSinIva).HasColumnType("money");
            entity.Property(e => e.TipoDeArticulo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TipoDeProducto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnidadDeVenta)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Consecutivo).HasName("p_Ciudad");

            entity.ToTable("Ciudad");

            entity.Property(e => e.Consecutivo).ValueGeneratedNever();
            entity.Property(e => e.FldOrigen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength()
                .HasColumnName("fldOrigen");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Consecutivo);

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Consecutivo, "u_ClienteConsecutivo").IsUnique();

            entity.Property(e => e.Consecutivo).ValueGeneratedNever();
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Contacto)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(160)
                .IsUnicode(false);
            entity.Property(e => e.NumeroRif)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NumeroRIF");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TipoDeContribuyente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ZonaDeCobranza)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ZonaPostal)
                .HasMaxLength(7)
                .IsUnicode(false);

            entity.HasOne(d => d.ConsecutivoCiudadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.ConsecutivoCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClienteCiud");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => new { e.Consecutivo, e.Numero }).HasName("p_factura");

            entity.ToTable("factura");

            entity.HasIndex(e => new { e.Consecutivo, e.Numero }, "u_FacturaNumero").IsUnique();

            entity.Property(e => e.Numero)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("smalldatetime");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(7000)
                .IsUnicode(false);
            entity.Property(e => e.TotalBaseImponible).HasColumnType("money");
            entity.Property(e => e.TotalFactura).HasColumnType("money");
            entity.Property(e => e.TotalIva)
                .HasColumnType("money")
                .HasColumnName("TotalIVA");
            entity.Property(e => e.TotalMontoExento).HasColumnType("money");
            entity.Property(e => e.TotalRenglones).HasColumnType("money");

            entity.HasOne(d => d.ConsecutivoClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ConsecutivoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_facturaclie");

            entity.HasOne(d => d.ConsecutivoVendedorNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ConsecutivoVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_facturaor");
        });

        modelBuilder.Entity<RenglonFactura>(entity =>
        {
            entity.HasKey(e => new { e.Consecutivo, e.NumeroFactura }).HasName("p_renglonFactura");

            entity.ToTable("renglonFactura");

            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Articulo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Cantidad).HasColumnType("money");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(7000)
                .IsUnicode(false);
            entity.Property(e => e.PrecioConIva)
                .HasColumnType("money")
                .HasColumnName("PrecioConIVA");
            entity.Property(e => e.PrecioSinIva)
                .HasColumnType("money")
                .HasColumnName("PrecioSinIVA");
            entity.Property(e => e.TotalRenglon).HasColumnType("money");

            entity.HasOne(d => d.Factura).WithOne(p => p.RenglonFactura)
                .HasForeignKey<RenglonFactura>(d => new { d.Consecutivo, d.NumeroFactura })
                .HasConstraintName("fk_renglonFacturafact");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.Consecutivo).HasName("p_Vendedor");

            entity.ToTable("Vendedor");

            entity.HasIndex(e => e.Codigo, "u_VenCodigo").IsUnique();

            entity.Property(e => e.Consecutivo).ValueGeneratedNever();
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.Rif)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RIF");
            entity.Property(e => e.StatusVendedor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
