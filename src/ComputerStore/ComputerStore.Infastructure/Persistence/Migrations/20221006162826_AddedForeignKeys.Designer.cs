﻿// <auto-generated />
using ComputerStore.Infastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComputerStore.Infastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221006162826_AddedForeignKeys")]
    partial class AddedForeignKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ComputerStore.Domain.Entities.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CPUManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CPUManufacturerId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.CPUManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("CPUManufacturers");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComputerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerTypeId");

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.ComputerBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("ComputerBrands");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.ComputerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ComputerTypes");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CpuId")
                        .HasColumnType("int");

                    b.Property<int>("DriveId")
                        .HasColumnType("int");

                    b.Property<int>("GpuId")
                        .HasColumnType("int");

                    b.Property<int>("RamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CpuId");

                    b.HasIndex("DriveId");

                    b.HasIndex("GpuId");

                    b.HasIndex("RamId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Drive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DriveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MemoryValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriveTypeId");

                    b.ToTable("Drives");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.DriveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("DriveTypes");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GPUManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Vram")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GPUManufacturerId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.GPUManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("GPUManufacturers");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComputerBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerBrandId");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RAMs");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.CPU", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.CPUManufacturer", "CPUManufacturer")
                        .WithMany("CPUs")
                        .HasForeignKey("CPUManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CPUManufacturer");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Computer", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.ComputerType", "ComputerType")
                        .WithMany("Computers")
                        .HasForeignKey("ComputerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerStore.Domain.Entities.Model", "Model")
                        .WithOne("Computer")
                        .HasForeignKey("ComputerStore.Domain.Entities.Computer", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComputerType");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Configuration", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.CPU", "CPU")
                        .WithMany("Configurations")
                        .HasForeignKey("CpuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerStore.Domain.Entities.Drive", "Drive")
                        .WithMany("Configurations")
                        .HasForeignKey("DriveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerStore.Domain.Entities.GPU", "GPU")
                        .WithMany("Configurations")
                        .HasForeignKey("GpuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerStore.Domain.Entities.RAM", "RAM")
                        .WithMany("Configurations")
                        .HasForeignKey("RamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CPU");

                    b.Navigation("Drive");

                    b.Navigation("GPU");

                    b.Navigation("RAM");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Drive", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.DriveType", "DriveType")
                        .WithMany("Drives")
                        .HasForeignKey("DriveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DriveType");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.GPU", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.GPUManufacturer", "GPUManufacturer")
                        .WithMany("GPUs")
                        .HasForeignKey("GPUManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GPUManufacturer");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Model", b =>
                {
                    b.HasOne("ComputerStore.Domain.Entities.ComputerBrand", "ComputerBrand")
                        .WithMany("Models")
                        .HasForeignKey("ComputerBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerStore.Domain.Entities.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComputerBrand");

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.CPU", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.CPUManufacturer", b =>
                {
                    b.Navigation("CPUs");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.ComputerBrand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.ComputerType", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Drive", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.DriveType", b =>
                {
                    b.Navigation("Drives");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.GPU", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.GPUManufacturer", b =>
                {
                    b.Navigation("GPUs");
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.Model", b =>
                {
                    b.Navigation("Computer")
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerStore.Domain.Entities.RAM", b =>
                {
                    b.Navigation("Configurations");
                });
#pragma warning restore 612, 618
        }
    }
}
