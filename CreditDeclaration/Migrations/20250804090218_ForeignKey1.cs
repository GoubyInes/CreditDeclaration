using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDeclaration.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Activite_CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Etat_Civil_EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Profession_ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Type_document_TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropColumn(
                name: "WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.AlterColumn<string>(
                name: "pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "commune_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "adresse_commune",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "adresse_activite_commune",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "adresse_activite_commune", "adresse_activite_wilaya" });

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "adresse_activite_wilaya");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "adresse_commune", "adresse_wilaya" });

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "adresse_wilaya");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_code_activite",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "code_activite");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "commune_naissance", "wilaya_naissance" });

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_etat_civil",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "etat_civil");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "pays_emission");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "pays_naissance");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_profession",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "profession");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_type_doc",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "type_doc");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "wilaya_naissance");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Activite_code_activite",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "code_activite",
                principalSchema: "dbo",
                principalTable: "Activite",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "adresse_activite_commune", "adresse_activite_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "adresse_commune", "adresse_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                columns: new[] { "commune_naissance", "wilaya_naissance" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "etat_civil",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "pays_emission",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "pays_naissance",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Profession_profession",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "profession",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Type_document_type_doc",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "type_doc",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "adresse_activite_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "adresse_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "wilaya_naissance",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Activite_code_activite",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Profession_profession",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Type_document_type_doc",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_code_activite",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_etat_civil",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_profession",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_type_doc",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.DropIndex(
                name: "IX_Entrepreneur_Individuel_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.AlterColumn<string>(
                name: "pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "commune_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adresse_commune",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adresse_activite_commune",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "AdresseActiviteWilayaDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "AdresseWilayaDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "CodeActiviteDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "EtatCivilDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "PaysEmissionDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "PaysNaissanceDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "ProfessionDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "TypeDocDataCode");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneur_Individuel_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "WilayaNaissanceDataCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Activite_CodeActiviteDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "CodeActiviteDataCode",
                principalSchema: "dbo",
                principalTable: "Activite",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Etat_Civil_EtatCivilDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "EtatCivilDataCode",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_PaysEmissionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "PaysEmissionDataCode",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Pays_PaysNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "PaysNaissanceDataCode",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Profession_ProfessionDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "ProfessionDataCode",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Type_document_TypeDocDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "TypeDocDataCode",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_AdresseActiviteWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "AdresseActiviteWilayaDataCode",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_AdresseWilayaDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "AdresseWilayaDataCode",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Individuel_Wilaya_WilayaNaissanceDataCode",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "WilayaNaissanceDataCode",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");
        }
    }
}
