﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopNovel.Models;

#nullable disable

namespace WebShopNovel.Migrations
{
    [DbContext(typeof(WebNovel))]
    partial class EcommerceVer2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebShopNovel.Models.Account", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Randomkey")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "RoleId" }, "IX_Account_RoleId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttributeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributeId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AttributeId");

                    b.ToTable("Attribute", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.AttributePrice", b =>
                {
                    b.Property<int>("AttributePriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttributePriceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributePriceId"), 1L, 1);

                    b.Property<int?>("AttributeId")
                        .HasColumnType("int")
                        .HasColumnName("AttributeID");

                    b.Property<bool?>("IsActived")
                        .HasColumnType("bit");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.HasKey("AttributePriceId");

                    b.HasIndex(new[] { "AttributeId" }, "IX_AttributePrices_AttributeID");

                    b.HasIndex(new[] { "ProductId" }, "IX_AttributePrices_ProductID");

                    b.ToTable("AttributePrices");
                });

            modelBuilder.Entity("WebShopNovel.Models.Category", b =>
                {
                    b.Property<int>("CateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CateID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CateId"), 1L, 1);

                    b.Property<string>("Alias")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Cover")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descriptions")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsPublished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<int?>("Levels")
                        .HasColumnType("int");

                    b.Property<int?>("Ordering")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentID");

                    b.Property<string>("ThumbImg")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CateId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Customer", b =>
                {
                    b.Property<int>("CustommerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustommerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustommerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Randomkey")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustommerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebShopNovel.Models.ImportDetail", b =>
                {
                    b.Property<int>("TicketDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TicketDetailsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketDetailsId"), 1L, 1);

                    b.Property<decimal?>("ImportCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    b.Property<decimal?>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TicketDetailsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TicketId");

                    b.ToTable("ImportDetails");
                });

            modelBuilder.Entity("WebShopNovel.Models.ImportTicket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<DateTime?>("ImportDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("ImportTicket", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TransactionStatusId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionStatusID");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Order_CustomerID");

                    b.HasIndex(new[] { "TransactionStatusId" }, "IX_Order_TransactionStatusID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex(new[] { "OrderId" }, "IX_OrderDetails_OrderID");

                    b.HasIndex(new[] { "ProductId" }, "IX_OrderDetails_ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebShopNovel.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CateId")
                        .HasColumnType("int")
                        .HasColumnName("CateID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Descriptions")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("Homeflag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBestsellers")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("PublisherdId")
                        .HasColumnType("int")
                        .HasColumnName("PublisherId");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDesc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitInStock")
                        .HasColumnType("int");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex(new[] { "CateId" }, "IX_Product_CateID");

                    b.HasIndex(new[] { "PublisherdId" }, "IX_Product_PublisherId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PublisherId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebShopNovel.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipperID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipperId"), 1L, 1);

                    b.Property<string>("Company")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<DateTime?>("Shipdate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShipperName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shipper", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.TransactStatus", b =>
                {
                    b.Property<int>("TransactionStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransactionStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionStatusId"), 1L, 1);

                    b.Property<string>("Descriptions")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactionStatusId");

                    b.ToTable("TransactStatus", (string)null);
                });

            modelBuilder.Entity("WebShopNovel.Models.Account", b =>
                {
                    b.HasOne("WebShopNovel.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Account_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebShopNovel.Models.AttributePrice", b =>
                {
                    b.HasOne("WebShopNovel.Models.Attribute", "Attribute")
                        .WithMany("AttributePrices")
                        .HasForeignKey("AttributeId")
                        .HasConstraintName("FK_AttributePrices_Attribute");

                    b.HasOne("WebShopNovel.Models.Product", "Product")
                        .WithMany("AttributePrices")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_AttributePrices_Product");

                    b.Navigation("Attribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebShopNovel.Models.ImportDetail", b =>
                {
                    b.HasOne("WebShopNovel.Models.Product", "Product")
                        .WithMany("ImportDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ImportDetails_Product");

                    b.HasOne("WebShopNovel.Models.ImportTicket", "Ticket")
                        .WithMany("ImportDetails")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_ImportDetails_ImportTicket");

                    b.Navigation("Product");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("WebShopNovel.Models.ImportTicket", b =>
                {
                    b.HasOne("WebShopNovel.Models.Account", "User")
                        .WithMany("ImportTickets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ImportTicket_Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebShopNovel.Models.Order", b =>
                {
                    b.HasOne("WebShopNovel.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customers");

                    b.HasOne("WebShopNovel.Models.TransactStatus", "TransactionStatus")
                        .WithMany("Orders")
                        .HasForeignKey("TransactionStatusId")
                        .HasConstraintName("FK_Order_TransactStatus");

                    b.Navigation("Customer");

                    b.Navigation("TransactionStatus");
                });

            modelBuilder.Entity("WebShopNovel.Models.OrderDetail", b =>
                {
                    b.HasOne("WebShopNovel.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderDetails_Order");

                    b.HasOne("WebShopNovel.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderDetails_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebShopNovel.Models.Product", b =>
                {
                    b.HasOne("WebShopNovel.Models.Category", "Cate")
                        .WithMany("Products")
                        .HasForeignKey("CateId")
                        .HasConstraintName("FK_Product_Category");

                    b.HasOne("WebShopNovel.Models.Publisher", "Publisher")
                        .WithMany("Products")
                        .HasForeignKey("PublisherdId")
                        .HasConstraintName("FK_Product_Publisher");

                    b.Navigation("Cate");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("WebShopNovel.Models.Account", b =>
                {
                    b.Navigation("ImportTickets");
                });

            modelBuilder.Entity("WebShopNovel.Models.Attribute", b =>
                {
                    b.Navigation("AttributePrices");
                });

            modelBuilder.Entity("WebShopNovel.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebShopNovel.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebShopNovel.Models.ImportTicket", b =>
                {
                    b.Navigation("ImportDetails");
                });

            modelBuilder.Entity("WebShopNovel.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebShopNovel.Models.Product", b =>
                {
                    b.Navigation("AttributePrices");

                    b.Navigation("ImportDetails");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebShopNovel.Models.Publisher", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebShopNovel.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebShopNovel.Models.TransactStatus", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
