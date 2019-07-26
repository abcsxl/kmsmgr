using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kmsmgr.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Manager = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<Guid>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastLoginIP = table.Column<string>(nullable: true),
                    LoginCount = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "ContactNumber", "CreateTime", "CreateUserId", "IsEnable", "Manager", "Name", "ParentId", "Remarks" },
                values: new object[] { new Guid("534eec64-c8e3-4748-8353-1abe6ed5ad2b"), "root", null, new DateTime(2019, 7, 26, 13, 47, 32, 214, DateTimeKind.Local).AddTicks(4718), null, true, null, "全国密钥管理中心", new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Icon", "IsEnable", "Name", "ParentId", "Remarks", "Sort", "Url" },
                values: new object[] { new Guid("91ebc230-277f-4666-ad1f-daf4bdaad9b4"), "Department", "fa fa-link", true, "机构管理", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Icon", "IsEnable", "Name", "ParentId", "Remarks", "Sort", "Url" },
                values: new object[] { new Guid("5a52c006-6f34-4787-9598-0409282cfeee"), "Role", "fa fa-link", true, "角色管理", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Icon", "IsEnable", "Name", "ParentId", "Remarks", "Sort", "Url" },
                values: new object[] { new Guid("e7f397a2-d387-4325-ae20-ef616f4929d5"), "User", "fa fa-link", true, "用户管理", new Guid("00000000-0000-0000-0000-000000000000"), null, 3, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Icon", "IsEnable", "Name", "ParentId", "Remarks", "Sort", "Url" },
                values: new object[] { new Guid("8fcdec2b-d6b9-43e5-9523-8f62779e42fd"), "Permission", "fa fa-link", true, "功能管理", new Guid("00000000-0000-0000-0000-000000000000"), null, 4, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "DepartmentId", "EMail", "IsEnable", "LastLoginIP", "LoginCount", "MobileNumber", "Name", "Password", "Remarks", "UserName" },
                values: new object[] { new Guid("c6d4f6ce-67af-47fa-a96c-85b842eb5349"), new DateTime(2019, 7, 26, 13, 47, 32, 217, DateTimeKind.Local).AddTicks(3560), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("534eec64-c8e3-4748-8353-1abe6ed5ad2b"), "admin@admin.com", true, null, 0, "11011112222", "超级管理员", "123456", null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
