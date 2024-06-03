﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmallFactory.Data;

#nullable disable

namespace SmallFactory.Migrations.Machines
{
    [DbContext(typeof(MachinesContext))]
    partial class MachinesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmallFactory.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasColumnType("numeric")
                        .HasColumnName("budget");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("factories");
                });

            modelBuilder.Entity("SmallFactory.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Input1Count")
                        .HasColumnType("integer")
                        .HasColumnName("input_1_count");

                    b.Property<int>("Input2Count")
                        .HasColumnType("integer")
                        .HasColumnName("input_2_count");

                    b.Property<int>("Input3Count")
                        .HasColumnType("integer")
                        .HasColumnName("input_3_count");

                    b.Property<int>("Input4Count")
                        .HasColumnType("integer")
                        .HasColumnName("input_4_count");

                    b.Property<int>("OutputCount")
                        .HasColumnType("integer")
                        .HasColumnName("output_count");

                    b.Property<int>("ProductionChainId")
                        .HasColumnType("integer")
                        .HasColumnName("production_chain_id");

                    b.Property<int>("ReceiptId")
                        .HasColumnType("integer")
                        .HasColumnName("receipt_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("ProductionChainId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("machines");
                });

            modelBuilder.Entity("SmallFactory.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("parts");
                });

            modelBuilder.Entity("SmallFactory.Models.ProductionChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FactoryId")
                        .HasColumnType("integer")
                        .HasColumnName("factory_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("production_chains");
                });

            modelBuilder.Entity("SmallFactory.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ManufacturedPartId")
                        .HasColumnType("integer")
                        .HasColumnName("manufactured_part_id");

                    b.Property<int>("Material1PartId")
                        .HasColumnType("integer")
                        .HasColumnName("material_1_part_id");

                    b.Property<int>("Material2PartId")
                        .HasColumnType("integer")
                        .HasColumnName("material_2_part_id");

                    b.Property<int>("Material3PartId")
                        .HasColumnType("integer")
                        .HasColumnName("material_3_part_id");

                    b.Property<int>("Material4PartId")
                        .HasColumnType("integer")
                        .HasColumnName("material_4_part_id");

                    b.Property<double>("ProductionRate")
                        .HasColumnType("double precision")
                        .HasColumnName("production_rate")
                        .HasComment("Per minute");

                    b.Property<int>("ProductionType")
                        .HasColumnType("integer")
                        .HasColumnName("production_type");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturedPartId");

                    b.HasIndex("Material1PartId");

                    b.HasIndex("Material2PartId");

                    b.HasIndex("Material3PartId");

                    b.HasIndex("Material4PartId");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("SmallFactory.Models.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoolDown")
                        .HasColumnType("integer")
                        .HasColumnName("cooldown");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<int>("PartId")
                        .HasColumnType("integer")
                        .HasColumnName("part_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("PartId")
                        .IsUnique();

                    b.ToTable("shop");
                });

            modelBuilder.Entity("SmallFactory.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<int>("FactoryId")
                        .HasColumnType("integer")
                        .HasColumnName("factory_id");

                    b.Property<int>("Max")
                        .HasColumnType("integer")
                        .HasColumnName("max");

                    b.Property<int>("PartId")
                        .HasColumnType("integer")
                        .HasColumnName("part_id");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.HasIndex("PartId");

                    b.ToTable("storages");
                });

            modelBuilder.Entity("SmallFactory.Models.Machine", b =>
                {
                    b.HasOne("SmallFactory.Models.ProductionChain", "ProductionChain")
                        .WithMany("Machines")
                        .HasForeignKey("ProductionChainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Receipt", "Receipt")
                        .WithMany()
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionChain");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("SmallFactory.Models.ProductionChain", b =>
                {
                    b.HasOne("SmallFactory.Models.Factory", "Factory")
                        .WithMany("ProductionChains")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("SmallFactory.Models.Receipt", b =>
                {
                    b.HasOne("SmallFactory.Models.Part", "ManufacturedPart")
                        .WithMany()
                        .HasForeignKey("ManufacturedPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Part", "Material1Part")
                        .WithMany()
                        .HasForeignKey("Material1PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Part", "Material2Part")
                        .WithMany()
                        .HasForeignKey("Material2PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Part", "Material3Part")
                        .WithMany()
                        .HasForeignKey("Material3PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Part", "Material4Part")
                        .WithMany()
                        .HasForeignKey("Material4PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManufacturedPart");

                    b.Navigation("Material1Part");

                    b.Navigation("Material2Part");

                    b.Navigation("Material3Part");

                    b.Navigation("Material4Part");
                });

            modelBuilder.Entity("SmallFactory.Models.ShopItem", b =>
                {
                    b.HasOne("SmallFactory.Models.Part", "Part")
                        .WithOne("ShopItem")
                        .HasForeignKey("SmallFactory.Models.ShopItem", "PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("SmallFactory.Models.Storage", b =>
                {
                    b.HasOne("SmallFactory.Models.Factory", "Factory")
                        .WithMany("Storages")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallFactory.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("SmallFactory.Models.Factory", b =>
                {
                    b.Navigation("ProductionChains");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("SmallFactory.Models.Part", b =>
                {
                    b.Navigation("ShopItem")
                        .IsRequired();
                });

            modelBuilder.Entity("SmallFactory.Models.ProductionChain", b =>
                {
                    b.Navigation("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}
