namespace Domain.Common;

public abstract class BaseAuditableEntity
{
    public int ID { get; set; }
    public DateTime CREATIONDTTM { get; set; }

    public string CREATEDBY { get; set; }

    public DateTime? LASTMODIFIEDDTTM { get; set; }

    public string? LASTMODIFIEDBY { get; set; }
}