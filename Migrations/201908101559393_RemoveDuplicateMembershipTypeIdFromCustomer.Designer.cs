// <auto-generated />
namespace Vidly.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class RemoveDuplicateMembershipTypeIdFromCustomer : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemoveDuplicateMembershipTypeIdFromCustomer));
        
        string IMigrationMetadata.Id
        {
            get { return "201908101559393_RemoveDuplicateMembershipTypeIdFromCustomer"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}