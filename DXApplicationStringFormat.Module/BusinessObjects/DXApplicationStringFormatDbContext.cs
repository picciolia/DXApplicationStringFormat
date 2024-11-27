using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace DXApplicationStringFormat.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891/core-prerequisites-for-design-time-model-editor-with-entity-framework-core-data-model.
public class DXApplicationStringFormatContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<DXApplicationStringFormatEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new DXApplicationStringFormatEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class DXApplicationStringFormatDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DXApplicationStringFormatEFCoreDbContext> {
	public DXApplicationStringFormatEFCoreDbContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<DXApplicationStringFormatEFCoreDbContext>();
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DXApplicationStringFormat");
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
        return new DXApplicationStringFormatEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(DXApplicationStringFormatContextInitializer))]
public class DXApplicationStringFormatEFCoreDbContext : DbContext {
	public DXApplicationStringFormatEFCoreDbContext(DbContextOptions<DXApplicationStringFormatEFCoreDbContext> options) : base(options) {
	}
    public DbSet<CostoCorso> TariffeAttestati { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SetOneToManyAssociationDeleteBehavior(DeleteBehavior.SetNull, DeleteBehavior.Cascade);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
