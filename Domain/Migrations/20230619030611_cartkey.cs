using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class cartkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.EnsureSchema(
                name: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payments",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contacts",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Carts",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order",
                newSchema: "trojantrading");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "user",
                newSchema: "trojantrading");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                schema: "trojantrading",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                schema: "trojantrading",
                table: "order",
                newName: "IX_order_UserId");

            migrationBuilder.AddColumn<double>(
                name: "AgentPrice",
                schema: "trojantrading",
                table: "product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OriginalPrice",
                schema: "trojantrading",
                table: "product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WholesalerPrice",
                schema: "trojantrading",
                table: "product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "AdminMessage",
                schema: "trojantrading",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                schema: "trojantrading",
                table: "order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ClientMessage",
                schema: "trojantrading",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                schema: "trojantrading",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                schema: "trojantrading",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                schema: "trojantrading",
                table: "order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressLine",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCustomerName",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingPostCode",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingState",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingStreetNumber",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingSuburb",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BussinessName",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddressLine",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingCustomerName",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingPostCode",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingState",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingStreetNumber",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingSuburb",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "trojantrading",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                schema: "trojantrading",
                table: "product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                schema: "trojantrading",
                table: "order",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                schema: "trojantrading",
                table: "user",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                schema: "trojantrading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packagingList",
                schema: "trojantrading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packagingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packagingList_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "trojantrading",
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingCart",
                schema: "trojantrading",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_shoppingCart_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "trojantrading",
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageTags",
                schema: "trojantrading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalleryImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageTags_GalleryImages_GalleryImageId",
                        column: x => x.GalleryImageId,
                        principalSchema: "trojantrading",
                        principalTable: "GalleryImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "shoppingItem",
                schema: "trojantrading",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Packaging = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingItem", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_shoppingItem_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "trojantrading",
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingItem_shoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "trojantrading",
                        principalTable: "shoppingCart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_ShoppingCartId",
                schema: "trojantrading",
                table: "order",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageTags_GalleryImageId",
                schema: "trojantrading",
                table: "ImageTags",
                column: "GalleryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_packagingList_ProductId",
                schema: "trojantrading",
                table: "packagingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCart_UserId",
                schema: "trojantrading",
                table: "shoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingItem_ProductId",
                schema: "trojantrading",
                table: "shoppingItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingItem_ShoppingCartId",
                schema: "trojantrading",
                table: "shoppingItem",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_product_ProductId",
                schema: "trojantrading",
                table: "Carts",
                column: "ProductId",
                principalSchema: "trojantrading",
                principalTable: "product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_user_UserId1",
                schema: "trojantrading",
                table: "Carts",
                column: "UserId1",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_shoppingCart_ShoppingCartId",
                schema: "trojantrading",
                table: "order",
                column: "ShoppingCartId",
                principalSchema: "trojantrading",
                principalTable: "shoppingCart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_user_UserId",
                schema: "trojantrading",
                table: "order",
                column: "UserId",
                principalSchema: "trojantrading",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Categories_CategoryId",
                schema: "trojantrading",
                table: "product",
                column: "CategoryId",
                principalSchema: "trojantrading",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_user_UserId",
                schema: "trojantrading",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_product_ProductId",
                schema: "trojantrading",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_user_UserId1",
                schema: "trojantrading",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_order_shoppingCart_ShoppingCartId",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_user_UserId",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Categories_CategoryId",
                schema: "trojantrading",
                table: "product");

            migrationBuilder.DropTable(
                name: "ImageTags",
                schema: "trojantrading");

            migrationBuilder.DropTable(
                name: "packagingList",
                schema: "trojantrading");

            migrationBuilder.DropTable(
                name: "shoppingItem",
                schema: "trojantrading");

            migrationBuilder.DropTable(
                name: "GalleryImages",
                schema: "trojantrading");

            migrationBuilder.DropTable(
                name: "shoppingCart",
                schema: "trojantrading");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                schema: "trojantrading",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_ShoppingCartId",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "Account",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingAddressLine",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingCustomerName",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingPostCode",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingState",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingStreetNumber",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BillingSuburb",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BussinessName",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingAddressLine",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingCustomerName",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingPostCode",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingState",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingStreetNumber",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShippingSuburb",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "trojantrading",
                table: "user");

            migrationBuilder.DropColumn(
                name: "AgentPrice",
                schema: "trojantrading",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                schema: "trojantrading",
                table: "product");

            migrationBuilder.DropColumn(
                name: "WholesalerPrice",
                schema: "trojantrading",
                table: "product");

            migrationBuilder.DropColumn(
                name: "AdminMessage",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "Balance",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "ClientMessage",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "trojantrading",
                table: "order");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "trojantrading",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "trojantrading",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "trojantrading",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "trojantrading",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "trojantrading",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "trojantrading",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "trojantrading",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "trojantrading",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "trojantrading",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "trojantrading",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "trojantrading",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "product",
                schema: "trojantrading",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "order",
                schema: "trojantrading",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
