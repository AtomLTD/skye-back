using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using skye_back.Domain.Conversation;
using skye_back.Domain.Message;
using skye_back.Domain.ModelInfo;
using skye_back.Domain.User;
using skye_back.Domain.UserConversations;
using skye_back.Domain.UserPreference;

namespace skye_back.Infrastructure;

public class SkyeBackDbContext : DbContext
{
    private readonly string _connectionString;
    
    public SkyeBackDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkyeBackDbContext).Assembly);
    }

    private static ILoggerFactory CreateLoggerFactory() => LoggerFactory.Create(builder => builder.AddConsole());

    public DbSet<Conversation> Conversations => Set<Conversation>();

    public DbSet<Message> Messages => Set<Message>();

    public DbSet<ModelInfo> ModelInfos => Set<ModelInfo>();

    public DbSet<User> Users => Set<User>();

    public DbSet<UserConversation> UserConversations => Set<UserConversation>();

    public DbSet<UserPreference> UserPreferences => Set<UserPreference>();
}