using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDeclaration.Migrations
{
    /// <inheritdoc />
    public partial class AddCredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personne_Physique",
                schema: "dbo",
                table: "Personne_Physique");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personne_Morale",
                schema: "dbo",
                table: "Personne_Morale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrepreneur_Individuel",
                schema: "dbo",
                table: "Entrepreneur_Individuel");

            migrationBuilder.RenameTable(
                name: "Personne_Physique",
                schema: "dbo",
                newName: "Particulier",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Personne_Morale",
                schema: "dbo",
                newName: "Entreprise",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Entrepreneur_Individuel",
                schema: "dbo",
                newName: "Entrepreneur",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_wilaya_naissance",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_type_doc",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_type_doc");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_profession",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_profession");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_pays_naissance",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_pays_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_pays_emission",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_pays_emission");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_etat_civil",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_etat_civil");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_commune_naissance_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_adresse_wilaya",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_Physique_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Particulier",
                newName: "IX_Particulier_adresse_commune_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_type_doc",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_type_doc");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_profession",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_profession");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_pays_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_pays_emission",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_pays_emission");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_etat_civil",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_etat_civil");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_commune_naissance_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_code_activite",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_code_activite");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_adresse_commune_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_adresse_activite_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_Individuel_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                newName: "IX_Entrepreneur_adresse_activite_commune_adresse_activite_wilaya");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "dbo",
                table: "Duree_Credit",
                type: "nvarchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_loading",
                schema: "dbo",
                table: "Particulier",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_loading",
                schema: "dbo",
                table: "Entreprise",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_loading",
                schema: "dbo",
                table: "Entrepreneur",
                type: "date",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Particulier",
                schema: "dbo",
                table: "Particulier",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entreprise",
                schema: "dbo",
                table: "Entreprise",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrepreneur",
                schema: "dbo",
                table: "Entrepreneur",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Credit",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_declaration = table.Column<DateTime>(type: "date", nullable: true),
                    niveau_responsabilite = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    identifiant_plafond = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    numero_contrat = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    monnaie = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    num_identite_bancaire = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    pays_agence = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    code_agence = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    wilaya_agence = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    activite = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    type_credit = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    situation = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    classe_retard = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    duree_initiale = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    duree_restante = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    accorde = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    encours = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    cout_total = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    montant_mensualite = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    taux_interet = table.Column<decimal>(type: "decimal(8,5)", nullable: true),
                    date_impaye = table.Column<DateTime>(type: "date", nullable: true),
                    nb_echeance_impayee = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    interet_courus = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    montant_capital_nrecouvre = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    montant_interet_nrecouvre = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    date_rejet = table.Column<DateTime>(type: "date", nullable: true),
                    date_octroi = table.Column<DateTime>(type: "date", nullable: true),
                    date_expiration = table.Column<DateTime>(type: "date", nullable: true),
                    code_notation = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    organisme_notation = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    date_notation = table.Column<DateTime>(type: "date", nullable: true),
                    operation = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    descriptif_operation = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    type_garantie = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    montant_garantie = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    date_loading = table.Column<DateTime>(type: "date", nullable: true),
                    particulier_id = table.Column<int>(type: "int", nullable: true),
                    entrepreneur_id = table.Column<int>(type: "int", nullable: true),
                    entreprise_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.id);
                    table.ForeignKey(
                        name: "FK_Credit_Activite_activite",
                        column: x => x.activite,
                        principalSchema: "dbo",
                        principalTable: "Activite",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Classe_Retard_Credit_classe_retard",
                        column: x => x.classe_retard,
                        principalSchema: "dbo",
                        principalTable: "Classe_Retard_Credit",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Duree_Credit_duree_initiale",
                        column: x => x.duree_initiale,
                        principalSchema: "dbo",
                        principalTable: "Duree_Credit",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Duree_Credit_duree_restante",
                        column: x => x.duree_restante,
                        principalSchema: "dbo",
                        principalTable: "Duree_Credit",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Entrepreneur_entrepreneur_id",
                        column: x => x.entrepreneur_id,
                        principalSchema: "dbo",
                        principalTable: "Entrepreneur",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Credit_Entreprise_entreprise_id",
                        column: x => x.entreprise_id,
                        principalSchema: "dbo",
                        principalTable: "Entreprise",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Credit_Monnaie_monnaie",
                        column: x => x.monnaie,
                        principalSchema: "dbo",
                        principalTable: "Monnaie",
                        principalColumn: "code_monnaie");
                    table.ForeignKey(
                        name: "FK_Credit_Niveau_Responsabilite_niveau_responsabilite",
                        column: x => x.niveau_responsabilite,
                        principalSchema: "dbo",
                        principalTable: "Niveau_Responsabilite",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Particulier_particulier_id",
                        column: x => x.particulier_id,
                        principalSchema: "dbo",
                        principalTable: "Particulier",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Credit_Pays_pays_agence",
                        column: x => x.pays_agence,
                        principalSchema: "dbo",
                        principalTable: "Pays",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Situation_Credit_situation",
                        column: x => x.situation,
                        principalSchema: "dbo",
                        principalTable: "Situation_Credit",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Type_Credit_type_credit",
                        column: x => x.type_credit,
                        principalSchema: "dbo",
                        principalTable: "Type_Credit",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Type_Garantie_type_garantie",
                        column: x => x.type_garantie,
                        principalSchema: "dbo",
                        principalTable: "Type_Garantie",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Credit_Wilaya_wilaya_agence",
                        column: x => x.wilaya_agence,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "Entreprise_Associe",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<int>(type: "int", nullable: true),
                    client_radicale = table.Column<int>(type: "int", nullable: true),
                    num_sequentiel = table.Column<int>(type: "int", nullable: true),
                    type_personne = table.Column<int>(type: "int", nullable: true),
                    indicateur_etat = table.Column<string>(type: "char(1)", nullable: true),
                    designation_sociale = table.Column<string>(type: "varchar(100)", nullable: true),
                    sigle = table.Column<string>(type: "varchar(50)", nullable: true),
                    date_creation = table.Column<DateTime>(type: "date", nullable: true),
                    pays_residence = table.Column<int>(type: "int", nullable: true),
                    identification = table.Column<string>(type: "varchar(25)", nullable: true),
                    pourcentage_participation = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    date_pourcentage = table.Column<DateTime>(type: "date", nullable: true),
                    fonction = table.Column<int>(type: "int", nullable: true),
                    entreprise_id = table.Column<int>(type: "int", nullable: true),
                    date_loading = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise_Associe", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entreprise_Associe_Entreprise_entreprise_id",
                        column: x => x.entreprise_id,
                        principalSchema: "dbo",
                        principalTable: "Entreprise",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Entreprise_Dirigeant",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<int>(type: "int", nullable: true),
                    client_radicale = table.Column<int>(type: "int", nullable: true),
                    num_sequentiel = table.Column<int>(type: "int", nullable: true),
                    identification = table.Column<string>(type: "varchar(36)", nullable: true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: true),
                    prenom = table.Column<string>(type: "varchar(50)", nullable: true),
                    fonction = table.Column<int>(type: "int", nullable: true),
                    pays_residence = table.Column<int>(type: "int", nullable: true),
                    Nationalite = table.Column<int>(type: "int", nullable: true),
                    entreprise_id = table.Column<int>(type: "int", nullable: true),
                    date_loading = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise_Dirigeant", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entreprise_Dirigeant_Entreprise_entreprise_id",
                        column: x => x.entreprise_id,
                        principalSchema: "dbo",
                        principalTable: "Entreprise",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Entreprise_Societe",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<int>(type: "int", nullable: true),
                    client_radicale = table.Column<int>(type: "int", nullable: true),
                    num_sequentiel = table.Column<int>(type: "int", nullable: true),
                    nif = table.Column<string>(type: "varchar(20)", nullable: true),
                    pourcentage_participation = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    date_pourcentage = table.Column<DateTime>(type: "date", nullable: true),
                    designation_social = table.Column<string>(type: "varchar(100)", nullable: true),
                    code_activite = table.Column<int>(type: "int", nullable: true),
                    forme_juridique = table.Column<int>(type: "int", nullable: true),
                    entreprise_id = table.Column<int>(type: "int", nullable: true),
                    date_loading = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise_Societe", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entreprise_Societe_Entreprise_entreprise_id",
                        column: x => x.entreprise_id,
                        principalSchema: "dbo",
                        principalTable: "Entreprise",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credit_activite",
                schema: "dbo",
                table: "Credit",
                column: "activite");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_classe_retard",
                schema: "dbo",
                table: "Credit",
                column: "classe_retard");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_duree_initiale",
                schema: "dbo",
                table: "Credit",
                column: "duree_initiale");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_duree_restante",
                schema: "dbo",
                table: "Credit",
                column: "duree_restante");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_entrepreneur_id",
                schema: "dbo",
                table: "Credit",
                column: "entrepreneur_id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_entreprise_id",
                schema: "dbo",
                table: "Credit",
                column: "entreprise_id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_monnaie",
                schema: "dbo",
                table: "Credit",
                column: "monnaie");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_niveau_responsabilite",
                schema: "dbo",
                table: "Credit",
                column: "niveau_responsabilite");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_particulier_id",
                schema: "dbo",
                table: "Credit",
                column: "particulier_id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_pays_agence",
                schema: "dbo",
                table: "Credit",
                column: "pays_agence");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_situation",
                schema: "dbo",
                table: "Credit",
                column: "situation");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_type_credit",
                schema: "dbo",
                table: "Credit",
                column: "type_credit");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_type_garantie",
                schema: "dbo",
                table: "Credit",
                column: "type_garantie");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_wilaya_agence",
                schema: "dbo",
                table: "Credit",
                column: "wilaya_agence");

            migrationBuilder.CreateIndex(
                name: "IX_Entreprise_Associe_entreprise_id",
                schema: "dbo",
                table: "Entreprise_Associe",
                column: "entreprise_id");

            migrationBuilder.CreateIndex(
                name: "IX_Entreprise_Dirigeant_entreprise_id",
                schema: "dbo",
                table: "Entreprise_Dirigeant",
                column: "entreprise_id");

            migrationBuilder.CreateIndex(
                name: "IX_Entreprise_Societe_entreprise_id",
                schema: "dbo",
                table: "Entreprise_Societe",
                column: "entreprise_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Activite_code_activite",
                schema: "dbo",
                table: "Entrepreneur",
                column: "code_activite",
                principalSchema: "dbo",
                principalTable: "Activite",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Commune_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                columns: new[] { "adresse_activite_commune", "adresse_activite_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                columns: new[] { "adresse_commune", "adresse_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                columns: new[] { "commune_naissance", "wilaya_naissance" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Entrepreneur",
                column: "etat_civil",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Pays_pays_emission",
                schema: "dbo",
                table: "Entrepreneur",
                column: "pays_emission",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Pays_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                column: "pays_naissance",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Profession_profession",
                schema: "dbo",
                table: "Entrepreneur",
                column: "profession",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Type_document_type_doc",
                schema: "dbo",
                table: "Entrepreneur",
                column: "type_doc",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Wilaya_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                column: "adresse_activite_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur",
                column: "adresse_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepreneur_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur",
                column: "wilaya_naissance",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Particulier",
                columns: new[] { "adresse_commune", "adresse_wilaya" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Particulier",
                columns: new[] { "commune_naissance", "wilaya_naissance" },
                principalSchema: "dbo",
                principalTable: "Commune",
                principalColumns: new[] { "code", "domaine" });

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Particulier",
                column: "etat_civil",
                principalSchema: "dbo",
                principalTable: "Etat_Civil",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Pays_pays_emission",
                schema: "dbo",
                table: "Particulier",
                column: "pays_emission",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Pays_pays_naissance",
                schema: "dbo",
                table: "Particulier",
                column: "pays_naissance",
                principalSchema: "dbo",
                principalTable: "Pays",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Profession_profession",
                schema: "dbo",
                table: "Particulier",
                column: "profession",
                principalSchema: "dbo",
                principalTable: "Profession",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Type_document_type_doc",
                schema: "dbo",
                table: "Particulier",
                column: "type_doc",
                principalSchema: "dbo",
                principalTable: "Type_document",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Particulier",
                column: "adresse_wilaya",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulier_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Particulier",
                column: "wilaya_naissance",
                principalSchema: "dbo",
                principalTable: "Wilaya",
                principalColumn: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Activite_code_activite",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Commune_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Pays_pays_emission",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Pays_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Profession_profession",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Type_document_type_doc",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Wilaya_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrepreneur_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Commune_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Commune_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Etat_Civil_etat_civil",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Pays_pays_emission",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Pays_pays_naissance",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Profession_profession",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Type_document_type_doc",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Wilaya_adresse_wilaya",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropForeignKey(
                name: "FK_Particulier_Wilaya_wilaya_naissance",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropTable(
                name: "Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entreprise_Associe",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entreprise_Dirigeant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entreprise_Societe",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Particulier",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entreprise",
                schema: "dbo",
                table: "Entreprise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrepreneur",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.DropColumn(
                name: "date_loading",
                schema: "dbo",
                table: "Particulier");

            migrationBuilder.DropColumn(
                name: "date_loading",
                schema: "dbo",
                table: "Entreprise");

            migrationBuilder.DropColumn(
                name: "date_loading",
                schema: "dbo",
                table: "Entrepreneur");

            migrationBuilder.RenameTable(
                name: "Particulier",
                schema: "dbo",
                newName: "Personne_Physique",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Entreprise",
                schema: "dbo",
                newName: "Personne_Morale",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Entrepreneur",
                schema: "dbo",
                newName: "Entrepreneur_Individuel",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_type_doc",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_type_doc");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_profession",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_profession");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_pays_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_pays_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_pays_emission",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_pays_emission");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_etat_civil",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_etat_civil");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_commune_naissance_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Particulier_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Personne_Physique",
                newName: "IX_Personne_Physique_adresse_commune_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_type_doc",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_type_doc");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_profession",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_profession");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_pays_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_pays_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_pays_emission",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_pays_emission");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_etat_civil",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_etat_civil");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_commune_naissance_wilaya_naissance",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_commune_naissance_wilaya_naissance");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_code_activite",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_code_activite");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_adresse_commune_adresse_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_adresse_commune_adresse_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_adresse_activite_wilaya");

            migrationBuilder.RenameIndex(
                name: "IX_Entrepreneur_adresse_activite_commune_adresse_activite_wilaya",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                newName: "IX_Entrepreneur_Individuel_adresse_activite_commune_adresse_activite_wilaya");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "dbo",
                table: "Duree_Credit",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personne_Physique",
                schema: "dbo",
                table: "Personne_Physique",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personne_Morale",
                schema: "dbo",
                table: "Personne_Morale",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrepreneur_Individuel",
                schema: "dbo",
                table: "Entrepreneur_Individuel",
                column: "id");

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
    }
}
