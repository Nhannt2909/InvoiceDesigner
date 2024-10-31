﻿// <auto-generated />
using System;
using InvoiceDesigner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceDesigner.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241029210318_AddInitialMigration")]
    partial class AddInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BIC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DefaultVat")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentTerms")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("VatId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WWW")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "US Dollar",
                            Name = "USD"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Euro",
                            Name = "EUR"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Czech Koruna",
                            Name = "CZK"
                        });
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("VatId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.DropItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormDesignerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FormDesignerId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Selector")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartSelector")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UniqueId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FormDesignerId");

                    b.HasIndex("FormDesignerId1");

                    b.ToTable("DropItems");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.DropItemCssStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DropItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DropItemId");

                    b.ToTable("DropItemStyles");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.FormDesigner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Columns")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rows")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(32);

                    b.HasKey("Id");

                    b.ToTable("FormDesigners");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EnabledVat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PONumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Vat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0m);

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrice");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Bank", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Company", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.DropItem", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.FormDesigner.FormDesigner", "FormDesigner")
                        .WithMany()
                        .HasForeignKey("FormDesignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.FormDesigner.FormDesigner", null)
                        .WithMany("DropItems")
                        .HasForeignKey("FormDesignerId1");

                    b.Navigation("FormDesigner");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.DropItemCssStyle", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.FormDesigner.DropItem", "DropItem")
                        .WithMany("CssStyle")
                        .HasForeignKey("DropItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DropItem");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Invoice", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Company");

                    b.Navigation("Currency");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.InvoiceItem", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.ProductPrice", b =>
                {
                    b.HasOne("Invoicer.Domain.Shared.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Invoicer.Domain.Shared.Models.Product", null)
                        .WithMany("ProductPrice")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.DropItem", b =>
                {
                    b.Navigation("CssStyle");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.FormDesigner.FormDesigner", b =>
                {
                    b.Navigation("DropItems");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("Invoicer.Domain.Shared.Models.Product", b =>
                {
                    b.Navigation("ProductPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
