using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricing = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricing = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricing = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "MenuStore",
                columns: table => new
                {
                    MenusEntityId = table.Column<long>(type: "bigint", nullable: false),
                    StoresEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuStore", x => new { x.MenusEntityId, x.StoresEntityId });
                    table.ForeignKey(
                        name: "FK_MenuStore_MenuItems_MenusEntityId",
                        column: x => x.MenusEntityId,
                        principalTable: "MenuItems",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuStore_Stores_StoresEntityId",
                        column: x => x.StoresEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedStoreEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Users_Stores_SelectedStoreEntityId",
                        column: x => x.SelectedStoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToppingLists",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topping1EntityId = table.Column<long>(type: "bigint", nullable: true),
                    Topping2EntityId = table.Column<long>(type: "bigint", nullable: true),
                    Topping3EntityId = table.Column<long>(type: "bigint", nullable: true),
                    Topping4EntityId = table.Column<long>(type: "bigint", nullable: true),
                    Topping5EntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingLists", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ToppingLists_Toppings_Topping1EntityId",
                        column: x => x.Topping1EntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToppingLists_Toppings_Topping2EntityId",
                        column: x => x.Topping2EntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToppingLists_Toppings_Topping3EntityId",
                        column: x => x.Topping3EntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToppingLists_Toppings_Topping4EntityId",
                        column: x => x.Topping4EntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToppingLists_Toppings_Topping5EntityId",
                        column: x => x.Topping5EntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    UserEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Order_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    AToppingListEntityId = table.Column<long>(type: "bigint", nullable: true),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crusts",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Order_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Order",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityId",
                        column: x => x.SizeEntityId,
                        principalTable: "Sizes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_ToppingLists_AToppingListEntityId",
                        column: x => x.AToppingListEntityId,
                        principalTable: "ToppingLists",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityId", "Name", "Pricing" },
                values: new object[,]
                {
                    { 1L, "Thin", 1.00m },
                    { 2L, "Regular", 1.50m },
                    { 3L, "Thick", 2.00m }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "EntityId", "Item" },
                values: new object[,]
                {
                    { 1L, "MeatEaters Pizza" },
                    { 2L, "Vegan Pizza" },
                    { 3L, "Supreme Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "Name", "Pricing" },
                values: new object[,]
                {
                    { 2L, "Medium", 3.50m },
                    { 3L, "Large", 4.00m },
                    { 1L, "Small", 3.00m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "PizzaHut" },
                    { 2L, "Dominos" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name", "Pricing" },
                values: new object[,]
                {
                    { 6L, "Black Olives", 1.50m },
                    { 1L, "Pepperoni", 2.00m },
                    { 2L, "Italian Sausage", 2.00m },
                    { 3L, "Meatball", 2.00m },
                    { 4L, "Mushroom", 1.50m },
                    { 5L, "Red Onions", 1.50m },
                    { 7L, "Green Bell Peppers", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "MenuStore",
                columns: new[] { "MenusEntityId", "StoresEntityId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "MenuStore",
                columns: new[] { "MenusEntityId", "StoresEntityId" },
                values: new object[] { 2L, 1L });

            migrationBuilder.InsertData(
                table: "MenuStore",
                columns: new[] { "MenusEntityId", "StoresEntityId" },
                values: new object[] { 3L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_MenuStore_StoresEntityId",
                table: "MenuStore",
                column: "StoresEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityId",
                table: "Order",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserEntityId",
                table: "Order",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_AToppingListEntityId",
                table: "Pizzas",
                column: "AToppingListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingLists_Topping1EntityId",
                table: "ToppingLists",
                column: "Topping1EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingLists_Topping2EntityId",
                table: "ToppingLists",
                column: "Topping2EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingLists_Topping3EntityId",
                table: "ToppingLists",
                column: "Topping3EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingLists_Topping4EntityId",
                table: "ToppingLists",
                column: "Topping4EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingLists_Topping5EntityId",
                table: "ToppingLists",
                column: "Topping5EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityId",
                table: "Users",
                column: "SelectedStoreEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuStore");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "ToppingLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
