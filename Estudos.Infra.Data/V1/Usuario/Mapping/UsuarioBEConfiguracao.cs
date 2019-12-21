using Estudos.Domain.V1.Entidades.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estudos.Infra.Data.V1.Usuario.Mapping
{
    class UsuarioBEConfiguracao : IEntityTypeConfiguration<UsuarioBE>
    {
        public void Configure(EntityTypeBuilder<UsuarioBE> builder)
        {
            EntidadeBaseBEConfiguracao.ConfigurarAtributosBase(builder);
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.HasQueryFilter(x => x.DataExclusao == null);
        }
    }
}
