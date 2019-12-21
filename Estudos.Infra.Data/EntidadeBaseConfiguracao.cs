using Estudos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estudos.Infra.Data
{
    public static class EntidadeBaseBEConfiguracao
    {
        private const short TAMANHO_MAXIMO_LOGIN = 80;

        public static void ConfigurarAtributosBase<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : EntidadeBase
        {
            //builder.Property(x => x).HasMaxLength(TAMANHO_MAXIMO_LOGIN);
            //builder.Property(x => x.LoginUsuarioAlteracao).HasMaxLength(TAMANHO_MAXIMO_LOGIN);
            //builder.Property(x => x.LoginUsuarioExclusao).HasMaxLength(TAMANHO_MAXIMO_LOGIN);
        }
    }
}
