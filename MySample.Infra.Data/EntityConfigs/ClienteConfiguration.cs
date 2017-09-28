using MySample.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MySample.Infra.Data.EntityConfigs
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(14);
        }
    }
}
