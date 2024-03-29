﻿// <auto-generated />
using Friends;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Friends.Migrations
{
    [DbContext(typeof(FriendsContext))]
    [Migration("20200831124551_migration6")]
    partial class migration6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Friends.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnName("deleted");

                    b.Property<string>("Question")
                        .HasColumnName("question");

                    b.Property<string>("QuestionType")
                        .HasColumnName("question_type");

                    b.Property<string>("Subject")
                        .HasColumnName("subject");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Friends.Models.Replys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answering")
                        .HasColumnName("answering");

                    b.Property<int>("QuestionId")
                        .HasColumnName("question_id");

                    b.Property<string>("Reply")
                        .HasColumnName("reply");

                    b.Property<string>("ReplyDate")
                        .HasColumnName("reply_date");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("Replys");
                });

            modelBuilder.Entity("Friends.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("NameSurename")
                        .HasColumnName("name_surename");

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
