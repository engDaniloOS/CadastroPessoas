using CadastroPessoas.Dominio.Servicos;
using CadastroPessoas.Dominio.Servicos.Interfaces;
using CadastroPessoas.Repositorios;
using CadastroPessoas.Repositorios.Interfaces;
using Infraestrutura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CadastroPessoas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string ConfigureConnectionString()
            => Configuration.GetConnectionString("Default").Replace("?path?", Environment.CurrentDirectory);

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Contexto>(
                        option => option.UseSqlServer(ConfigureConnectionString()));

            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
