using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDeclaration.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Etat_Civil_EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Pays_PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Pays_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Profession_ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Type_document_TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Wilaya_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Wilaya_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commune",
                schema: "dbo",
                table: "Commune");

            migrationBuilder.DropColumn(
                name: "AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropColumn(
                name: "WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.AlterColumn<string>(
                name: "commune_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "adresse_commune",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commune",
                schema: "dbo",
                table: "Commune",
                columns: new[] { "code", "domaine" });

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                columns: new[] { "adresse_commune", "adresse_wilaya" });

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                column: "adresse_wilaya");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                columns: new[] { "commune_naissance", "wilaya_naissance" });

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_etat_civil",
                schema: "dbo",
                table: "Personne_Physique",
                column: "etat_civil");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_pays_emission",
                schema: "dbo",
                table: "Personne_Physique",
                column: "pays_emission");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_pays_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                column: "pays_naissance");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_profession",
                schema: "dbo",
                table: "Personne_Physique",
                column: "profession");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_type_doc",
                schema: "dbo",
                table: "Personne_Physique",
                column: "type_doc");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                column: "wilaya_naissance");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                columns: new[] { "adresse_commune", "adresse_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                columns: new[] { "commune_naissance", "wilaya_naissance" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Personne_Physique",
                column: "etat_civil",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Pays_pays_emission",
                schema: "dbo",
                table: "Personne_Physique",
                column: "pays_emission",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Pays_pays_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                column: "pays_naissance",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Profession_profession",
                schema: "dbo",
                table: "Personne_Physique",
                column: "profession",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Type_document_type_doc",
                schema: "dbo",
                table: "Personne_Physique",
                column: "type_doc",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                column: "adresse_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                column: "wilaya_naissance",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Pays_pays_emission",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Pays_pays_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Profession_profession",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Type_document_type_doc",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Physique_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_etat_civil",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_pays_emission",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_pays_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_profession",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_type_doc",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropIndex(
                name: "IX_Personne_Physique_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commune",
                schema: "dbo",
                table: "Commune");

            migrationBuilder.AlterColumn<string>(
                name: "commune_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adresse_commune",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commune",
                schema: "dbo",
                table: "Commune",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "AdresseWilayaDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "EtatCivilDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "PaysEmissionDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "PaysNaissanceDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "ProfessionDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "TypeDocDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_Physique_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "WilayaNaissanceDataCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Etat_Civil_EtatCivilDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "EtatCivilDataCode",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Pays_PaysEmissionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "PaysEmissionDataCode",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Pays_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "PaysNaissanceDataCode",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Profession_ProfessionDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "ProfessionDataCode",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Type_document_TypeDocDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "TypeDocDataCode",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Wilaya_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "AdresseWilayaDataCode",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Physique_Wilaya_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Personne_Physique",
                column: "WilayaNaissanceDataCode",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");
        }
    }
}
