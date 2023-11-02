using banco.Cajas;
using banco.Egresos;
using banco.Ingresos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace banco.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class bancoDbContext :
    AbpDbContext<bancoDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    
    // Entidades
    
    public DbSet<Ingreso> Ingresos { get; set; }
    public DbSet<Egreso> Egresos { get; set; }
    public DbSet<Caja> Cajas { get; set; }

    
    public bancoDbContext(DbContextOptions<bancoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(bancoConsts.DbTablePrefix + "YourEntities", bancoConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        
        
        // Mapeo de Ingreso
        builder.Entity<Ingreso>(b =>
        {
            b.ToTable("Ingreso", bancoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(b => b.fecha).IsRequired();
            b.Property(b => b.valor).IsRequired();
        });
        
        // Mapeo de Egreso
        builder.Entity<Egreso>(b =>
        {
            b.ToTable("Egreso", bancoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(b => b.fecha).IsRequired();
            b.Property(b => b.valor).IsRequired();
        });
        
        // Mapeo de Caja
        builder.Entity<Caja>(b =>
        {
            b.ToTable("Caja", bancoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(b => b.descripcion).IsRequired().HasMaxLength(64);
            b.Property(b => b.saldo).IsRequired();
        });
        
        // Relacion de Caja con muchos Ingresos
        builder.Entity<Caja>()
            .HasMany<Ingreso>(g => g.listaIngresos)
            .WithOne(s => s.Caja)
            .HasForeignKey(s => s.CajaId)
            .IsRequired();
            
        // Relacion de Caja con muchos Egresos
        builder.Entity<Caja>()
            .HasMany<Egreso>(g => g.listaEgresos)
            .WithOne(s => s.Caja)
            .HasForeignKey(s => s.CajaId)
            .IsRequired();    
            
    }
}
