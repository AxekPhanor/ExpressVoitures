using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoitures.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicationde3FNv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Annee_AnneeId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Finition_FinitionId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Marque_MarqueId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Modele_ModeleId",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modele",
                table: "Modele");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marque",
                table: "Marque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finition",
                table: "Finition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Annee",
                table: "Annee");

            migrationBuilder.RenameTable(
                name: "Modele",
                newName: "Modeles");

            migrationBuilder.RenameTable(
                name: "Marque",
                newName: "Marques");

            migrationBuilder.RenameTable(
                name: "Finition",
                newName: "Finitions");

            migrationBuilder.RenameTable(
                name: "Annee",
                newName: "Annees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modeles",
                table: "Modeles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marques",
                table: "Marques",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Annees",
                table: "Annees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Annees_AnneeId",
                table: "Voitures",
                column: "AnneeId",
                principalTable: "Annees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Finitions_FinitionId",
                table: "Voitures",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Marques_MarqueId",
                table: "Voitures",
                column: "MarqueId",
                principalTable: "Marques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Modeles_ModeleId",
                table: "Voitures",
                column: "ModeleId",
                principalTable: "Modeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Annees_AnneeId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Finitions_FinitionId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Marques_MarqueId",
                table: "Voitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Modeles_ModeleId",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modeles",
                table: "Modeles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marques",
                table: "Marques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Annees",
                table: "Annees");

            migrationBuilder.RenameTable(
                name: "Modeles",
                newName: "Modele");

            migrationBuilder.RenameTable(
                name: "Marques",
                newName: "Marque");

            migrationBuilder.RenameTable(
                name: "Finitions",
                newName: "Finition");

            migrationBuilder.RenameTable(
                name: "Annees",
                newName: "Annee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modele",
                table: "Modele",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marque",
                table: "Marque",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finition",
                table: "Finition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Annee",
                table: "Annee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Annee_AnneeId",
                table: "Voitures",
                column: "AnneeId",
                principalTable: "Annee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Finition_FinitionId",
                table: "Voitures",
                column: "FinitionId",
                principalTable: "Finition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Marque_MarqueId",
                table: "Voitures",
                column: "MarqueId",
                principalTable: "Marque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Modele_ModeleId",
                table: "Voitures",
                column: "ModeleId",
                principalTable: "Modele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
