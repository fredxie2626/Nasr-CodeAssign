namespace CodeAssign.Migrations.ContactMigrations
{
    using CodeAssign.Models.Contacts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeAssign.Models.Contacts.ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContactMigrations";
        }

        protected override void Seed(CodeAssign.Models.Contacts.ContactContext context)
        {
            context.Provinces.AddOrUpdate(
                                      p => p.ProvinceCode,
                                      new Province
                                      {
                                          ProvinceCode = "BC",
                                          ProvinceName = "British Columbia",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "AL",
                                          ProvinceName = "Alberta",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "ON",
                                          ProvinceName = "Ontario",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "QC",
                                          ProvinceName = "Quebec",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "NB",
                                          ProvinceName = "New Brunswick",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "PE",
                                          ProvinceName = "Prince Edward Island",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "NS",
                                          ProvinceName = "Nova Scotia",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "NL",
                                          ProvinceName = "Newfoundland & Labrador",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "SK",
                                          ProvinceName = "Saskatchewan",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "MB",
                                          ProvinceName = "Manitoba",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "YT",
                                          ProvinceName = "Yukon Territory",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "NT",
                                          ProvinceName = "Northwest Territories",
                                      },
                                      new Province
                                      {
                                          ProvinceCode = "NU",
                                          ProvinceName = "Nunavut",
                                      }
                                    );
            context.SaveChanges();

            context.Cities.AddOrUpdate(
                                    p => p.CityName,
                                    new City
                                    {
                                        CityName = "Vancouver",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "BC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Kelowna",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "BC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Tofino",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "BC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Victoria",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "BC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Whistler",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "BC").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Banff",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "AL").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Calgary",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "AL").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Edmonton",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "AL").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Jasper",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "AL").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Niagara Falls",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Niagara-on-the-Lake",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "London",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Ottawa",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "St Catharines",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Stratford",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Toronto",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "ON").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Montreal",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "QC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Quebec City",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "QC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Sherbrooke",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "QC").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Trois Rivières",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "QC").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Fredericton",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NB").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Saint John",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NB").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Cavendish",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "PE").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Charlottetown",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "PE").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Cape Breton",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NS").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Halifax",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NS").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Corner Brook",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NL").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "St. John's",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NL").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Regina",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "SK").FirstOrDefault().ProvinceId
                                    },
                                    new City
                                    {
                                        CityName = "Saskatoon",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "SK").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Winnipeg",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "MB").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Whitehorse",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "YT").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Yellowknife",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NT").FirstOrDefault().ProvinceId
                                    },

                                    new City
                                    {
                                        CityName = "Iqaluit",
                                        ProvinceId = context.Provinces.Where(p => p.ProvinceCode == "NU").FirstOrDefault().ProvinceId
                                    }
                                  );

            context.SaveChanges();
        }
    }
}
