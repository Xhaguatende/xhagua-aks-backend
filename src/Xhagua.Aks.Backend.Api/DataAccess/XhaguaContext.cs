namespace Xhagua.Aks.Backend.Api.DataAccess;

using Microsoft.EntityFrameworkCore;

/// <summary>
///
/// </summary>
public class XhaguaContext : DbContext
{
    #region Public Constructors

    /// <summary>
    ///
    /// </summary>
    /// <param name="options"></param>
    public XhaguaContext(DbContextOptions<XhaguaContext> options) : base(options)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    ///
    /// </summary>
    public DbSet<MyTable> MyTables { get; set; } = default!;

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    ///
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<MyTable>(entity =>
        {
            entity.ToTable(nameof(MyTable));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)

                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasMaxLength(500);
        });
    }

    #endregion Protected Methods
}