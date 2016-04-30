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
                new ServiceModule(){ModuleCode="market-scdy" ,ModuleName="市场调研"},
                new ServiceModule(){ModuleCode="market-ltjz" ,ModuleName="论坛讲座"},
                new ServiceModule(){ModuleCode="market-ckds" ,ModuleName="创客大赛"},
                new ServiceModule(){ModuleCode="market-mtgg" ,ModuleName="媒体广告"},
                new ServiceModule(){ModuleCode="market-gjzh" ,ModuleName="国际展会"},
                new ServiceModule(){ModuleCode="market-gnzh" ,ModuleName="国内展会"}
            };

            var brandPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="brand-ppch" ,ModuleName="品牌策划"},
                new ServiceModule(){ModuleCode="brand-ppgl" ,ModuleName="品牌管理"},
                new ServiceModule(){ModuleCode="brand-ppkf" ,ModuleName="品牌开发"}
            };

            var sellPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="sell-ctqd" ,ModuleName="传统渠道"},
                new ServiceModule(){ModuleCode="sell-gnds" ,ModuleName="国内电商"},
                new ServiceModule(){ModuleCode="sell-kjds" ,ModuleName="跨境电商"},
                new ServiceModule(){ModuleCode="sell-b2b" ,ModuleName="B2B"},
                new ServiceModule(){ModuleCode="sell-b2c" ,ModuleName="B2C"}
            };

            var makePlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="make-dplsc" ,ModuleName="大批量生产"},
                new ServiceModule(){ModuleCode="make-zyhzz" ,ModuleName="专业化制造"}
            };

            var projectPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="project-ybzz" ,ModuleName="样板制作"},
                new ServiceModule(){ModuleCode="project-mzjl" ,ModuleName="模治检量"},
                new ServiceModule(){ModuleCode="project-gjzz" ,ModuleName="工具制作"},
                new ServiceModule(){ModuleCode="project-szsc" ,ModuleName="试做试产"}
            };

            var productPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="product-zcxm" ,ModuleName="众创项目"},
                new ServiceModule(){ModuleCode="product-cxyy" ,ModuleName="产学研用"},
                new ServiceModule(){ModuleCode="product-whcy" ,ModuleName="文化创意"},
                new ServiceModule(){ModuleCode="product-sjfa" ,ModuleName="设计-方案"},
                new ServiceModule(){ModuleCode="product-khxq" ,ModuleName="客户需求"},
                new ServiceModule(){ModuleCode="product-cpzc" ,ModuleName="产品众筹"},
                new ServiceModule(){ModuleCode="product-odmoem" ,ModuleName="ODM/OEM"}

            };
            var supplyManagementModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="supply-ccwl" ,ModuleName="仓储物流"},
                new ServiceModule(){ModuleCode="supply-ffps" ,ModuleName="分发配送"},
                new ServiceModule(){ModuleCode="supply-cgwf" ,ModuleName="采购外发"},
                new ServiceModule(){ModuleCode="supply-jygl" ,ModuleName="精益管理"}
            };
            var tutorPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="tutor-zlgh" ,ModuleName="战略规划"},
                new ServiceModule(){ModuleCode="tutor-qyjl" ,ModuleName="企业教练"},
                new ServiceModule(){ModuleCode="tutor-gwpx" ,ModuleName="顾问培训"},
                new ServiceModule(){ModuleCode="tutor-cxy" ,ModuleName="产学研"},
                new ServiceModule(){ModuleCode="tutor-xh" ,ModuleName="协会"},
                new ServiceModule(){ModuleCode="tutor-rlzy" ,ModuleName="人力资源开发"}
            };

            var fundPlatformModules = new List<ServiceModule>
            {
                new ServiceModule(){ModuleCode="fund-zc" ,ModuleName="众筹"},
                new ServiceModule(){ModuleCode="fund-jj" ,ModuleName="基金、PE、VC"},
                new ServiceModule(){ModuleCode="fund-gqjy" ,ModuleName="股权交易"},
                new ServiceModule(){ModuleCode="fund-bx" ,ModuleName="保险"},
                new ServiceModule(){ModuleCode="fund-yh" ,ModuleName="银行"}
            };

            var serviceTypes = new List<ServiceType>
            {
                new ServiceType{TypeCode="MarketPlatform", TypeName="市场平台",ServiceModules = marketPlatformModules},
                new ServiceType{TypeCode="BrandPlatform", TypeName="品牌平台",ServiceModules = brandPlatformModules},
                new ServiceType{TypeCode="SellPlatform", TypeName="销售平台",ServiceModules = sellPlatformModules},
                new ServiceType{TypeCode="MakePlatform", TypeName="制造平台",ServiceModules = makePlatformModules},
                new ServiceType{TypeCode="ProjectPlatform", TypeName="工程平台",ServiceModules = projectPlatformModules},
                new ServiceType{TypeCode="ProductPlatform", TypeName="产品平台",ServiceModules = productPlatformModules},
                new ServiceType{TypeCode="SupplyManagement", TypeName="供应链管理",ServiceModules = supplyManagementModules},
                new ServiceType{TypeCode="TutorPlatform", TypeName="导师平台",ServiceModules = tutorPlatformModules},
                new ServiceType{TypeCode="FundPlatform", TypeName="资金平台",ServiceModules = fundPlatformModules}
            };
            context.ServiceTypes.AddRange(serviceTypes);
            context.SaveChanges();
            #endregion
        }
    }
}
