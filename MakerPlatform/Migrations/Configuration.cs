namespace MakerPlatform.Migrations
{
    using MakerPlatform.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MakerPlatform.Models.MakerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MakerPlatform.Models.MakerDBContext context)
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
            #region
            var marketPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="market-scdy" ,ModuleName="�г�����"},
                new ServiceModule(){ModuleCode="market-ltjz" ,ModuleName="��̳����"},
                new ServiceModule(){ModuleCode="market-ckds" ,ModuleName="���ʹ���"},
                new ServiceModule(){ModuleCode="market-mtgg" ,ModuleName="ý����"},
                new ServiceModule(){ModuleCode="market-gjzh" ,ModuleName="����չ��"},
                new ServiceModule(){ModuleCode="market-gnzh" ,ModuleName="����չ��"}
            };

            var brandPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="brand-ppch" ,ModuleName="Ʒ�Ʋ߻�"},
                new ServiceModule(){ModuleCode="brand-ppgl" ,ModuleName="Ʒ�ƹ���"},
                new ServiceModule(){ModuleCode="brand-ppkf" ,ModuleName="Ʒ�ƿ���"}
            };

            var sellPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="sell-ctqd" ,ModuleName="��ͳ����"},
                new ServiceModule(){ModuleCode="sell-gnds" ,ModuleName="���ڵ���"},
                new ServiceModule(){ModuleCode="sell-kjds" ,ModuleName="�羳����"},
                new ServiceModule(){ModuleCode="sell-b2b" ,ModuleName="B2B"},
                new ServiceModule(){ModuleCode="sell-b2c" ,ModuleName="B2C"}
            };

            var makePlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="make-dplsc" ,ModuleName="����������"},
                new ServiceModule(){ModuleCode="make-zyhzz" ,ModuleName="רҵ������"}
            };

            var projectPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="project-ybzz" ,ModuleName="��������"},
                new ServiceModule(){ModuleCode="project-mzjl" ,ModuleName="ģ�μ���"},
                new ServiceModule(){ModuleCode="project-gjzz" ,ModuleName="��������"},
                new ServiceModule(){ModuleCode="project-szsc" ,ModuleName="�����Բ�"}
            };

            var productPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="product-zcxm" ,ModuleName="�ڴ���Ŀ"},
                new ServiceModule(){ModuleCode="product-cxyy" ,ModuleName="��ѧ����"},
                new ServiceModule(){ModuleCode="product-whcy" ,ModuleName="�Ļ�����"},
                new ServiceModule(){ModuleCode="product-sjfa" ,ModuleName="���-����"},
                new ServiceModule(){ModuleCode="product-khxq" ,ModuleName="�ͻ�����"},
                new ServiceModule(){ModuleCode="product-cpzc" ,ModuleName="��Ʒ�ڳ�"},
                new ServiceModule(){ModuleCode="product-odmoem" ,ModuleName="ODM/OEM"}

            };
            var supplyManagementModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="supply-ccwl" ,ModuleName="�ִ�����"},
                new ServiceModule(){ModuleCode="supply-ffps" ,ModuleName="�ַ�����"},
                new ServiceModule(){ModuleCode="supply-cgwf" ,ModuleName="�ɹ��ⷢ"},
                new ServiceModule(){ModuleCode="supply-jygl" ,ModuleName="�������"}
            };
            var tutorPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="tutor-zlgh" ,ModuleName="ս�Թ滮"},
                new ServiceModule(){ModuleCode="tutor-qyjl" ,ModuleName="��ҵ����"},
                new ServiceModule(){ModuleCode="tutor-gwpx" ,ModuleName="������ѵ"},
                new ServiceModule(){ModuleCode="tutor-cxy" ,ModuleName="��ѧ��"},
                new ServiceModule(){ModuleCode="tutor-xh" ,ModuleName="Э��"},
                new ServiceModule(){ModuleCode="tutor-rlzy" ,ModuleName="������Դ����"}
            };

            var fundPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="fund-zc" ,ModuleName="�ڳ�"},
                new ServiceModule(){ModuleCode="fund-jj" ,ModuleName="����PE��VC"},
                new ServiceModule(){ModuleCode="fund-gqjy" ,ModuleName="��Ȩ����"},
                new ServiceModule(){ModuleCode="fund-bx" ,ModuleName="����"},
                new ServiceModule(){ModuleCode="fund-yh" ,ModuleName="����"}
            };

            var serviceTypes = new List<ServiceType>
            {
                new ServiceType{TypeCode="MarketPlatform", TypeName="�г�ƽ̨",ServiceModules = marketPlatformModules},
                new ServiceType{TypeCode="BrandPlatform", TypeName="Ʒ��ƽ̨",ServiceModules = brandPlatformModules},
                new ServiceType{TypeCode="SellPlatform", TypeName="����ƽ̨",ServiceModules = sellPlatformModules},
                new ServiceType{TypeCode="MakePlatform", TypeName="����ƽ̨",ServiceModules = makePlatformModules},
                new ServiceType{TypeCode="ProjectPlatform", TypeName="����ƽ̨",ServiceModules = projectPlatformModules},
                new ServiceType{TypeCode="ProductPlatform", TypeName="��Ʒƽ̨",ServiceModules = productPlatformModules},
                new ServiceType{TypeCode="SupplyManagement", TypeName="��Ӧ������",ServiceModules = supplyManagementModules},
                new ServiceType{TypeCode="TutorPlatform", TypeName="��ʦƽ̨",ServiceModules = tutorPlatformModules},
                new ServiceType{TypeCode="FundPlatform", TypeName="�ʽ�ƽ̨",ServiceModules = fundPlatformModules}
            };
            context.ServiceTypes.AddRange(serviceTypes);
            context.SaveChanges();
            #endregion
        }
    }
}
