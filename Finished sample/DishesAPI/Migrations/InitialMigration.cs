using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DishesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredient",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredient", x => new { x.DishesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_DishIngredient_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), "Fish Masala" },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), "Ragu alla bolognaise" },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), "Flemish Beef stew with chicory" },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), "Rendang" },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), "Mussels with french fries" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("047ab5cc-d041-486e-9d22-a0860fb13237"), "Chili pepper" },
                    { new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"), "Brown piece of bread" },
                    { new Guid("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7"), "Ginger" },
                    { new Guid("40563e5b-e538-4084-9587-3df74fae21d4"), "Tomato" },
                    { new Guid("7a2fbc72-bb33-49de-bd23-c78fceb367fc"), "Chicory" },
                    { new Guid("8d5a1b40-6677-4545-b6e8-5ba93efda0a1"), "French fries" },
                    { new Guid("937b1ba1-7969-4324-9ab5-afb0e4d875e6"), "Mustard" },
                    { new Guid("a07cde83-3127-45da-bbd5-04a7c8d13aa4"), "Ginger garlic paste" },
                    { new Guid("aab31c70-57ce-4b6d-a66c-9c1b094e915d"), "Mussels" },
                    { new Guid("b5f336e2-c226-4389-aac3-2499325a3de9"), "Mayo" },
                    { new Guid("b617df23-3d91-40e1-99aa-b07d264aa937"), "Carrot" },
                    { new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56"), "Garlic" },
                    { new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40"), "Dark beer" },
                    { new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe"), "Various spices" },
                    { new Guid("c2c75b40-2453-416e-a7ed-3505b121d671"), "Coconut milk" },
                    { new Guid("c9b46f9c-d6ce-42c3-8736-2cddbbadee10"), "Firm fish" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Beef" },
                    { new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d"), "Bay leave" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Onion" },
                    { new Guid("e0017fe1-773f-4a59-9730-9489833c6e8e"), "Tamarind paste" },
                    { new Guid("ebe94d5d-2ad8-4886-b246-05a1fad83d1c"), "Garam masala" },
                    { new Guid("ecd396c3-4403-4fbf-83ca-94a8e9d859b3"), "Red wine" },
                    { new Guid("f350e1a0-38de-42fe-ada5-ae436378ee5b"), "Tomato paste" },
                    { new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f"), "Celery" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredient",
                columns: new[] { "DishesId", "IngredientsId" },
                values: new object[,]
                {
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("047ab5cc-d041-486e-9d22-a0860fb13237") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("40563e5b-e538-4084-9587-3df74fae21d4") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("a07cde83-3127-45da-bbd5-04a7c8d13aa4") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("c2c75b40-2453-416e-a7ed-3505b121d671") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("c9b46f9c-d6ce-42c3-8736-2cddbbadee10") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"), new Guid("ebe94d5d-2ad8-4886-b246-05a1fad83d1c") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("40563e5b-e538-4084-9587-3df74fae21d4") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("b617df23-3d91-40e1-99aa-b07d264aa937") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("ecd396c3-4403-4fbf-83ca-94a8e9d859b3") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("f350e1a0-38de-42fe-ada5-ae436378ee5b") },
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("7a2fbc72-bb33-49de-bd23-c78fceb367fc") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("937b1ba1-7969-4324-9ab5-afb0e4d875e6") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("b5f336e2-c226-4389-aac3-2499325a3de9") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("047ab5cc-d041-486e-9d22-a0860fb13237") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("c2c75b40-2453-416e-a7ed-3505b121d671") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"), new Guid("e0017fe1-773f-4a59-9730-9489833c6e8e") },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), new Guid("8d5a1b40-6677-4545-b6e8-5ba93efda0a1") },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), new Guid("aab31c70-57ce-4b6d-a66c-9c1b094e915d") },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_IngredientsId",
                table: "DishIngredient",
                column: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredient");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
