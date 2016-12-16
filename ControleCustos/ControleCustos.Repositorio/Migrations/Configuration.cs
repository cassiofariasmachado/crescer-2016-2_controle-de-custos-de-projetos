namespace ControleCustos.Repositorio.Migrations
{
    using Dominio;
    using Dominio.Enum;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleCustos.Repositorio.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControleCustos.Repositorio.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            this.popularRecursos(context);
        }

        private void popularRecursos(ControleCustos.Repositorio.DatabaseContext context)
        {
            context.Recurso.AddOrUpdate(new Patrimonio { Nome = "VM Interna", TipoRecurso = TipoRecurso.Fisico, Modelo = "VM", Marca = "VM", DataCompra = new DateTime(2016, 12, 15), Situacao = SituacaoRecurso.Disponivel, TempoDeVidaUtil = 10, ValorCompra = 600, ValorMensal = 100 });
        }
    }
}
