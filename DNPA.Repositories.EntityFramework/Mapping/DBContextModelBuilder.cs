using DNPA.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DNPA.Repositories.Mapping
{
    public class DBContextModelBuilder
    {
        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity(typeof(ContinentEntity), b =>
                {
                    b.ToTable("Continents");

                    b.Property<Guid>("ContinentID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ContinentID");

                    b.Property<string>("ContinentCode");

                    b.Property<string>("ContinentName");
                });

            modelBuilder.Entity(typeof(CountryEntity), b =>
                {
                    b.ToTable("Countries");

                    b.Property<Guid>("CountryID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("CountryID");

                    //b.ToTable("Continent");

                    b.Property<string>("CountryName");

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryCode3");

                    b.Property<string>("Capital");

                    b.Property<string>("ContinentCode");

                    b.Property<int>("Area");

                    b.Property<int>("Population");

                    b.Property<decimal?>("Latitude");

                    b.Property<decimal?>("Longitude");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("CurrencyName");

                    b.Property<string>("Languages");

                });


        }
    }
}
