using CustomForms.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomForms.ServerApp.Data
{
    public class CustomFormsContext : DbContext
    {
        public CustomFormsContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<BlankForm> BlankForms { get; set; }
        public DbSet<FormInputFieldDefinition> FormInputFieldDefinitions { get; set; }
        public DbSet<FormInputFieldAnswer> FormInputFieldAnswers { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
    }
}
