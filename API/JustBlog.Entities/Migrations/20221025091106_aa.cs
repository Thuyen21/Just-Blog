using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustBlog.Entities.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                 name: "FK_Posts_Categories_CategoryId",
                 table: "Posts");

            migrationBuilder.AlterColumn<Guid>(
                 name: "CategoryId",
                 table: "Posts",
                 type: "uniqueidentifier",
                 nullable: false,
                 defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                 oldClrType: typeof(Guid),
                 oldType: "uniqueidentifier",
                 oldNullable: true);

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("1c917bbc-383b-4b7e-9fce-bfd76f2f4aed"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "e2eec025-1a7c-4132-b559-a68fa837b8c9", "AQAAAAIAAYagAAAAEJzbpl1+1ZmBme8XNKtg8+0v/UOFHuZfdM2rwWGDwcbnTgP+KoKvNoa5xe84IlVDnA==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("55c97cf2-48a1-455c-80e0-307cca32e4fa"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "e044b0c6-e712-4b93-9dde-487ac2b73cdd", "AQAAAAIAAYagAAAAEGujQ9myfiyUVPNhDvOGmQIW+hOLMZ1sCpWBvqLBQnwOLDnLzGAHfpAJCCC/MSxECw==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("56de49b5-22c6-4e3e-8e8c-6adb86a24cc9"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "c912588f-0df3-4535-bab4-fcc4aa783310", "AQAAAAIAAYagAAAAEGyzcQdFShuYGMzYP58rTO95yvBkjdVzCtrRXFiglczBlfLLKMd0TCrOkyY55X0eQg==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("70369848-8782-4928-b8e3-106db74c5f3f"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "c035abb0-a428-4e41-bbe1-8c944cb8e89b", "AQAAAAIAAYagAAAAEK39Qi1SNwn9SV4UrVqQXu/600HwTpext2XZdZYkoG3XLhy1WWI/zNEXTYAUs5Ti1Q==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("8b5ed246-11b1-4df6-b36a-9be399f60891"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "d7b3fc56-2845-4ab3-9f19-18a3aad6fc89", "AQAAAAIAAYagAAAAEJ+G7NDzKt8pg3VZ8iyVq29eq73gvSi+DtffyUHLQhQV5GdSWecHAsAjO6RQAH6QUQ==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("ac924737-2076-4cab-983a-f184ef7f2f1b"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "47f661f2-5607-4f8e-86b3-7b380ce9d79d", "AQAAAAIAAYagAAAAEFtWlzmOhMydvHNNLHnQROm0+stAAtd0IeEnbk1cObBbcXNOKuxPByS/W59ogdJ1sw==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("aeae5ff8-43cd-4f90-8d9e-234b9c2d14b9"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "077a07c4-9f7f-4774-97a2-55836594ccbe", "AQAAAAIAAYagAAAAEB33Ik4/A0F+DzTl1rxY4BrZV33KhgLslk0Jb0rFkzq/a9TwepPCMXHQ/9d0XV0B/g==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("c92627c0-9156-494d-bc90-ad381f136852"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "b013f34f-b691-43b0-b7e8-2697bdfffcdf", "AQAAAAIAAYagAAAAECp0Lp8Iqo6THRIUTArCIf3LrIi8zqGf8B+cj6bYVY7lAkNVUHEGfA58TEv3FbGJZg==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("da1d155d-2eb4-46ad-81ed-ddd99ea58b4e"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "5968516f-1ae9-457e-bf58-51a7def4c86a", "AQAAAAIAAYagAAAAEA/iL5WaTA0/4mPKHBjToF1TX5u9VwVc1BJeCdrLsxOIy8CC8ipNGRTVbjBoKlaYgw==" });

            migrationBuilder.AddForeignKey(
                 name: "FK_Posts_Categories_CategoryId",
                 table: "Posts",
                 column: "CategoryId",
                 principalTable: "Categories",
                 principalColumn: "Id",
                 onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                 name: "FK_Posts_Categories_CategoryId",
                 table: "Posts");

            migrationBuilder.AlterColumn<Guid>(
                 name: "CategoryId",
                 table: "Posts",
                 type: "uniqueidentifier",
                 nullable: true,
                 oldClrType: typeof(Guid),
                 oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("1c917bbc-383b-4b7e-9fce-bfd76f2f4aed"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "faadf2b5-c099-4662-af87-f14e151198e0", "AQAAAAIAAYagAAAAELuGfAmY3wFvkPZZMjOu9uwjs35F4x00ZRulmXlYQZ8OhNVy0OgIbZihqr7fKZCmdA==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("55c97cf2-48a1-455c-80e0-307cca32e4fa"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "2345349e-f2b1-4815-bf16-0227908b2c35", "AQAAAAIAAYagAAAAEJ10JlqeELq9ned2cHBLdUrA4tl9fcEs5rXdAXCiEP1bsx8sJ4bdC1AjTn8wTyDx/Q==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("56de49b5-22c6-4e3e-8e8c-6adb86a24cc9"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "badab627-c23a-4911-aaa9-95fd6c7f0a80", "AQAAAAIAAYagAAAAEDOwJdVwA9cJqXmuWtxz6y/yBputdeW8X6puy07TKxg0WcDiRtQeWtfg42ITZLNLIw==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("70369848-8782-4928-b8e3-106db74c5f3f"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "229bde5f-57a5-4af0-b9ab-3d2591b118e3", "AQAAAAIAAYagAAAAEHVyWDi+0ANbPfX2QfIkXTs0lFn+3vYwzok+O3ikbibKMRCYS3FZ2KEMsLBEiKBTdA==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("8b5ed246-11b1-4df6-b36a-9be399f60891"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "f607a1a2-9d02-48e8-95d1-5b50e7beeb71", "AQAAAAIAAYagAAAAEK0lfwqzSGd4FFoIold1nb5Fzts7ukkfJxclg2ztJzhOuF98hJ94zxz3LkJ3n9inYA==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("ac924737-2076-4cab-983a-f184ef7f2f1b"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "fa49ac03-b1f3-4ece-8be4-c965447460bc", "AQAAAAIAAYagAAAAEJbwTLES17Ar5P3TVXYeKxq0qUBaRchXN9358RCfgHK+yT06fQ9neTnvFE0i1Wo+qw==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("aeae5ff8-43cd-4f90-8d9e-234b9c2d14b9"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "98e5a9a0-0441-40ee-892c-6d5c0b17a836", "AQAAAAIAAYagAAAAENw2PpQwjuzB8FSa5Fb0NnfGIvC2ASQTKzYre+0dU8JISRgFEbwo+wMAwpCU3riLrA==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("c92627c0-9156-494d-bc90-ad381f136852"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "45765803-b155-4cb1-b965-2789b0148407", "AQAAAAIAAYagAAAAENdqiXQDjteKHGjKrystCp1tb8RPoh4aevE/pTRNXdAsBtkCTSJwJixzX3mhXMV2bw==" });

            migrationBuilder.UpdateData(
                 table: "AspNetUsers",
                 keyColumn: "Id",
                 keyValue: new Guid("da1d155d-2eb4-46ad-81ed-ddd99ea58b4e"),
                 columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                 values: new object[] { "0caf524c-4fef-441c-840e-96ab2f9f3e50", "AQAAAAIAAYagAAAAEMNXTATUkvvwATLwt9PgE06sTbJ1qEczHgS36WIkvqqCQFZYsnk64FNt8TdiKNNB+Q==" });

            migrationBuilder.AddForeignKey(
                 name: "FK_Posts_Categories_CategoryId",
                 table: "Posts",
                 column: "CategoryId",
                 principalTable: "Categories",
                 principalColumn: "Id");
        }
    }
}
