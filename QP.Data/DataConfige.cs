using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QP.Cashier_Model.CreateEntity;

namespace QP.Cashier_Data
{
    
    /// <summary>
    /// 本类给每表实体添加配置约束
    /// </summary>
    public class DataConfige { }

    /// <summary>
    ///  权限表
    /// </summary>
    public class AuthoritysConfige : IEntityTypeConfiguration<Authoritys>
    {
        public void Configure(EntityTypeBuilder<Authoritys> builder)
        {
            builder.HasKey(p => p.AuthorityID);
            builder.Property(p => p.AuthorityID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.Roleds).HasMaxLength(36).IsRequired();
            builder.Property(p => p.AuthorityName).IsRequired();
        }
    }

    /// <summary>
    ///  导航表
    /// </summary>
    public class NavsConfige : IEntityTypeConfiguration<Navs>
    {
        public void Configure(EntityTypeBuilder<Navs> builder)
        {
            //builder.HasKey(p => p.ParentID);
            //builder.Property(p => p.ParentID).HasMaxLength(36).IsRequired();        
            //builder.Property(p => p.NavName).IsRequired();
            //builder.Property(p => p.ImageID).HasMaxLength(36).IsRequired();
            //builder.Property(p => p.NavUrl).IsRequired();
            //builder.Property(p => p.SonID).HasMaxLength(36).IsRequired();
            //builder.Property(p => p.nav_status).IsRequired();
        }

      
    }


    /// <summary>
    /// 类别表
    /// </summary>
    public class CategorysConfige : IEntityTypeConfiguration<Categorys>
    {
        public void Configure(EntityTypeBuilder<Categorys> builder)
        {
            builder.HasKey(p => p.CategorysID);
            builder.Property(p => p.CategorysID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.CategorysName).IsRequired();
        }
    }

    /// <summary>
    /// 门店表配置
    /// </summary>
    public class ShopsConfige : IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.HasKey(p => p.ShopID);
            builder.Property(u => u.ShopID).HasMaxLength(36).IsRequired();
            builder.Property(q => q.ShopAbbreviation).IsRequired();
            builder.Property(q => q.ShopAddress).IsRequired();
            builder.Property(q => q.ShopPhone).HasMaxLength(11).IsRequired();
            builder.Property(q => q.ShopName).IsRequired();
            builder.Property(q => q.ShopInstructions).IsRequired();
            builder.Property(q => q.ShopPrincipal).HasMaxLength(8).IsRequired();
            builder.Property(q => q.ShopDeadlineInvest).IsRequired();
            builder.Property(q => q.Classify).IsRequired();
            builder.Property(q => q.stringShopSonID).HasMaxLength(36).IsRequired();
            //使用HasOne和WithOne两个扩展方法对User表和Address表进行1-1关系配置
            //builder.HasOne(q => q.Address).WithOne(q => q.User).HasForeignKey<Address>(q => q.UserID);
        }
    }

    /// <summary>
    /// 操作表配置
    /// </summary>
    public class OperationConfige : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(p => p.OperationID);
            builder.Property(p => p.OperationID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.StaffCreateTime).IsRequired();
            builder.Property(p => p.StaffCreator).HasMaxLength(6).IsRequired();
            builder.Property(p => p.StaffModifyUser).HasMaxLength(6).IsRequired();
            builder.Property(p => p.StaffUpdateTime).IsRequired();

        }
    }

    /// <summary>
    /// 会员表
    /// </summary>
    public class MembersConfige : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.HasKey(p => p.MemberID);
            builder.Property(p => p.MemberID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.ClientBirthType).HasMaxLength(1).HasDefaultValue("N").IsRequired();
            builder.Property(p => p.ClientAdrees).IsRequired();
            builder.Property(p => p.ClientBirth).IsRequired();
            builder.Property(p => p.ClientIdentity).HasMaxLength(19).IsRequired();
            builder.Property(p => p.ClientName).HasMaxLength(6).IsRequired();
            builder.Property(p => p.ClientPhone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.ClientSex).HasMaxLength(1).IsRequired();
            builder.Property(p => p.RecentConsumptionTime).IsRequired();
            builder.Property(p => p.StoredArrears).IsRequired();
            builder.Property(p => p.ProjectArrears).IsRequired();

            //builder.HasOne(q => q.Operation).WithOne(q => q.Members).HasForeignKey<Operation>(q => q.OperationID);
            //builder.HasOne(q => q.Shops).WithOne(q => q.Members).HasForeignKey<Shops>(q => q.ShopID);
            //builder.HasOne(q => q.CardMembers).WithOne(q => q.Members).HasForeignKey<CardMembers>(q => q.CardMemberID);
        }
    }

    /// <summary>
    /// 会员卡表配置
    /// </summary>
    public class CardMembersConfige : IEntityTypeConfiguration<CardMembers>
    {
        public void Configure(EntityTypeBuilder<CardMembers> builder)
        {
            builder.HasKey(p => p.CardMemberID);
            builder.Property(p => p.CardMemberID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.AcrossStore).HasMaxLength(1).HasDefaultValue("N").IsRequired();
            builder.Property(p => p.Balance).IsRequired();
            builder.Property(p => p.CardIntegral).IsRequired();
            builder.Property(p => p.CardMemberName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CardNumber).HasMaxLength(20).IsRequired();
            builder.Property(p => p.IntegralReason).IsRequired();
            builder.Property(p => p.IntegralTime).IsRequired();
            //  builder.HasOne(q => q.Operations).WithOne(q => q.CardMembers).HasForeignKey<Operation>(q => q.OperationID);
        }
    }

    /// <summary>
    /// 员工表配置
    /// </summary>
    public class StaffsConfige : IEntityTypeConfiguration<Staffs>
    {
        public void Configure(EntityTypeBuilder<Staffs> builder)
        {
            builder.HasKey(p => p.StaffID);
            builder.Property(p => p.StaffID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.StaffBirth).IsRequired();
            builder.Property(p => p.StaffBirthType).HasMaxLength(1).HasDefaultValue("N").IsRequired();
            builder.Property(p => p.StaffDuty).IsRequired();
            builder.Property(p => p.StaffEntryTime).IsRequired();
            builder.Property(p => p.StaffIdentity).HasMaxLength(19).IsRequired();
            builder.Property(p => p.StaffName).HasMaxLength(6).IsRequired();
            builder.Property(p => p.StaffPhone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.StaffSex).HasMaxLength(1).IsRequired();

            //builder.HasOne(q => q.Operation).WithOne(q => q.Staffs).HasForeignKey<Operation>(q => q.OperationID);
            //builder.HasOne(q => q.Shops).WithOne(q => q.Staffs).HasForeignKey<Shops>(q => q.ShopID);
            //builder.HasOne(q => q.Authoritys).WithOne(q => q.Staffs).HasForeignKey<Authoritys>(q => q.AuthorityID);
        }
    }

    /// <summary>
    /// 工资表配置
    /// </summary>
    public class WagesConfige : IEntityTypeConfiguration<Wages>
    {
        public void Configure(EntityTypeBuilder<Wages> builder)
        {
            builder.HasKey(p => p.WagesID);
            builder.Property(p => p.WagesID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.PushMoney).IsRequired();
            builder.Property(p => p.Withhold).IsRequired();
            builder.Property(p => p.WithholdCause).IsRequired();
            builder.Property(p => p.BasicSalary).IsRequired();
        }
    }

    /// <summary>
    /// 证书表配置
    /// </summary>
    public class CertificatesConfige : IEntityTypeConfiguration<Certificates>
    {
        public void Configure(EntityTypeBuilder<Certificates> builder)
        {
            builder.HasKey(p => p.CertificateID);
            builder.Property(p => p.CertificateID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.CertificateName).IsRequired();
            builder.Property(p => p.Describe).IsRequired();
            builder.Property(p => p.ExpireTime).IsRequired();
        }
    }

    /// <summary>
    ///  图片表配置
    /// </summary>
    public class ImagesConfige : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(p => p.ImageID);
            builder.Property(p => p.ImagesUrl).HasMaxLength(36).IsRequired();
            builder.Property(p => p.ImagesUrl).IsRequired();
            builder.Property(p => p.Describe).IsRequired();
        }
    }

    /// <summary>
    ///库存表配置
    /// </summary>
    public class InventorysConfige : IEntityTypeConfiguration<Inventorys>
    {
        public void Configure(EntityTypeBuilder<Inventorys> builder)
        {
            builder.HasKey(p => p.InventoryID);
            builder.Property(p => p.InventoryID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.InventoryNumber).IsRequired();
            builder.Property(p => p.SupplierName).IsRequired();
        }
    }

    /// <summary>
    ///  产品表
    /// </summary>
    public class ProductsConfige : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.ProductID);
            builder.Property(p => p.ProductID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.OperationID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.InventorysID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.CategorysID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductPrice).IsRequired();
            builder.Property(p => p.PurchasePrice).IsRequired();
            builder.Property(p => p.PurchaseSpec).IsRequired();
            builder.Property(p => p.ShopPrice).IsRequired();
            builder.Property(p => p.UsageAmount).IsRequired();
            builder.Property(p => p.MarketingUnit).IsRequired();
            builder.Property(p => p.Productbarcode).IsRequired();
        }
    }

    /// <summary>
    ///项目表配置
    /// </summary>
    public class ProjectTypesConfige : IEntityTypeConfiguration<ProjectTypes>
    {
        public void Configure(EntityTypeBuilder<ProjectTypes> builder)
        {
            builder.HasKey(p => p.ProjectTypID);
            builder.Property(p => p.ProjectTypID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.OperationID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.StaffID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.CategorysID).HasMaxLength(36).IsRequired();
            builder.Property(p => p.ProductID).HasMaxLength(36).IsRequired();

            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.SalePrice).IsRequired();
            builder.Property(p => p.ValueAtcost).IsRequired();

        }
    }


}


