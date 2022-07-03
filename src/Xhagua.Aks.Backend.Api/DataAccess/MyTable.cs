namespace Xhagua.Aks.Backend.Api.DataAccess;

/// <summary>
/// 
/// </summary>
public class MyTable
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    public string? Notes { get; set; }

    #endregion Public Properties
}