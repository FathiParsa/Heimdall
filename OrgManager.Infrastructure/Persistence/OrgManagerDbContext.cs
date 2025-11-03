using Microsoft.EntityFrameworkCore;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Infrastructure.Persistence;

public class OrgManagerDbContext : DbContext
{
    public OrgManagerDbContext(DbContextOptions<OrgManagerDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    public DbSet<TimeLogEntry> TimeLogEntries { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrgManagerDbContext).Assembly);
    }
}
