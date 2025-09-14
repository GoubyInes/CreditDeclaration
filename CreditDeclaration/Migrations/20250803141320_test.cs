using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDeclaration.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Activite",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activite", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Banque",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banque", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristique_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristique_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Classe_Retard_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe_Retard_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Commune",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    descriptif = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commune", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Duree_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duree_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Entite_Publique",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entite_Publique", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Etat_Civil",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etat_Civil", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Fonction_Dirigeant",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonction_Dirigeant", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Forme_Juridique",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forme_Juridique", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Monnaie",
                schema: "dbo",
                columns: table => new
                {
                    code_monnaie = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    devise = table.Column<string>(type: "varchar(50)", nullable: true),
                    entite = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monnaie", x => x.code_monnaie);
                });

            migrationBuilder.CreateTable(
                name: "Niveau_Responsabilite",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau_Responsabilite", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Personne_Morale",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<int>(type: "int", nullable: true),
                    client_radicale = table.Column<int>(type: "int", nullable: true),
                    date_creation = table.Column<DateTime>(type: "date", nullable: true),
                    sigle = table.Column<string>(type: "varchar(20)", nullable: true),
                    adresse_activite = table.Column<string>(type: "varchar(100)", nullable: true),
                    wilaya_activite = table.Column<int>(type: "int", nullable: true),
                    commune_activite = table.Column<int>(type: "int", nullable: true),
                    adresse_siege = table.Column<string>(type: "varchar(100)", nullable: true),
                    wilaya_siege = table.Column<int>(type: "int", nullable: true),
                    commune_siege = table.Column<int>(type: "int", nullable: true),
                    forme_juridique = table.Column<int>(type: "int", nullable: true),
                    code_activite_principale = table.Column<int>(type: "int", nullable: true),
                    entite_publique = table.Column<int>(type: "int", nullable: true),
                    effectif = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    valeur_ajoute = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    chiffre_affaire = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    resultat_net = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    total_bilan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    total_actif = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    capital_emis = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    reserve = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    raport_nouveau = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    capitaux = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    emprunt = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    excedent_brut = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    resultat_financier = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    date_bilan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    type_doc = table.Column<int>(type: "int", nullable: true),
                    num_doc = table.Column<string>(type: "varchar(20)", nullable: true),
                    pays_emission = table.Column<int>(type: "int", nullable: true),
                    enite_emettrice = table.Column<string>(type: "varchar(20)", nullable: true),
                    date_expiration = table.Column<DateTime>(type: "date", nullable: true),
                    nif = table.Column<string>(type: "varchar(20)", nullable: true),
                    cle_intermediaire = table.Column<string>(type: "varchar(26)", nullable: true),
                    cle_onomastique = table.Column<string>(type: "varchar(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne_Morale", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    descriptif = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Situation_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situation_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Source_Information_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source_Information_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Type_Credit",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Credit", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Type_document",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_document", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Type_Garantie",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Garantie", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Type_Personne",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Personne", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Wilaya",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    domaine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    descriptif = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilaya", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Entrepreneur_Individuel",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    client_radical = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "date", nullable: true),
                    presume = table.Column<bool>(type: "bit", nullable: true),
                    num_acte_naissance = table.Column<decimal>(type: "decimal(5,0)", nullable: true),
                    acte_naissance = table.Column<string>(type: "char(1)", nullable: true),
                    sexe = table.Column<string>(type: "char(1)", nullable: true),
                    nationalite = table.Column<bool>(type: "bit", nullable: true),
                    pays_naissance = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    PaysNaissanceDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    wilaya_naissance = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    WilayaNaissanceDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    commune_naissance = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    prenom_pere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    prenom_mere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom_mere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom_conjoint = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    etat_civil = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    EtatCivilDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    profession = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    ProfessionDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    revenu = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    adresse_wilaya = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    AdresseWilayaDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    adresse_commune = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    type_doc = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    TypeDocDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    num_doc = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    pays_emission = table.Column<string>(type: "char(3)", nullable: true),
                    PaysEmissionDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    entite_emettrice = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    date_expiration = table.Column<DateTime>(type: "date", nullable: true),
                    nif = table.Column<string>(type: "varchar(20)", nullable: true),
                    cle_intermediaire = table.Column<string>(type: "varchar(26)", nullable: true),
                    cle_onomastique = table.Column<string>(type: "varchar(26)", nullable: true),
                    fond_propre = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    recette = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    total_bilan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    effictif = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    code_activite = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    CodeActiviteDataCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    adresse_activite = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    adresse_activite_wilaya = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    AdresseActiviteWilayaDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    adresse_activite_commune = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepreneur_Individuel", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Activite_CodeActiviteDataCode",
                        column: x => x.CodeActiviteDataCode,
                        principalSchema: "dbo",
                        principalTable: "Activite",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Etat_Civil_EtatCivilDataCode",
                        column: x => x.EtatCivilDataCode,
                        principalSchema: "dbo",
                        principalTable: "Etat_Civil",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Pays_PaysEmissionDataCode",
                        column: x => x.PaysEmissionDataCode,
                        principalSchema: "dbo",
                        principalTable: "Pays",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Pays_PaysNaissanceDataCode",
                        column: x => x.PaysNaissanceDataCode,
                        principalSchema: "dbo",
                        principalTable: "Pays",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Profession_ProfessionDataCode",
                        column: x => x.ProfessionDataCode,
                        principalSchema: "dbo",
                        principalTable: "Profession",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Type_document_TypeDocDataCode",
                        column: x => x.TypeDocDataCode,
                        principalSchema: "dbo",
                        principalTable: "Type_document",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Wilaya_AdresseActiviteWilayaDataCode",
                        column: x => x.AdresseActiviteWilayaDataCode,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Wilaya_AdresseWilayaDataCode",
                        column: x => x.AdresseWilayaDataCode,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Entrepreneur_Individuel_Wilaya_WilayaNaissanceDataCode",
                        column: x => x.WilayaNaissanceDataCode,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "Personne_Physique",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_agence = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    client_radical = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "date", nullable: true),
                    presume = table.Column<bool>(type: "bit", nullable: true),
                    num_acte_naissance = table.Column<decimal>(type: "decimal(5,0)", nullable: true),
                    acte_naissance = table.Column<string>(type: "char(1)", nullable: true),
                    sexe = table.Column<string>(type: "char(1)", nullable: true),
                    nationalite = table.Column<bool>(type: "bit", nullable: true),
                    pays_naissance = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    PaysNaissanceDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    wilaya_naissance = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    WilayaNaissanceDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    commune_naissance = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    prenom_pere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    prenom_mere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom_mere = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    nom_conjoint = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    etat_civil = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    EtatCivilDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    profession = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    ProfessionDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    revenu = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    adresse_wilaya = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    AdresseWilayaDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    adresse_commune = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    type_doc = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    TypeDocDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    num_doc = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    pays_emission = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    PaysEmissionDataCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    entite_emettrice = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    date_expiration = table.Column<DateTime>(type: "date", nullable: true),
                    nif = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    cle_intermediaire = table.Column<string>(type: "nvarchar(26)", nullable: true),
                    cle_onomastique = table.Column<string>(type: "nvarchar(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne_Physique", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Etat_Civil_EtatCivilDataCode",
                        column: x => x.EtatCivilDataCode,
                        principalSchema: "dbo",
                        principalTable: "Etat_Civil",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Pays_PaysEmissionDataCode",
                        column: x => x.PaysEmissionDataCode,
                        principalSchema: "dbo",
                        principalTable: "Pays",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Pays_PaysNaissanceDataCode",
                        column: x => x.PaysNaissanceDataCode,
                        principalSchema: "dbo",
                        principalTable: "Pays",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Profession_ProfessionDataCode",
                        column: x => x.ProfessionDataCode,
                        principalSchema: "dbo",
                        principalTable: "Profession",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Type_document_TypeDocDataCode",
                        column: x => x.TypeDocDataCode,
                        principalSchema: "dbo",
                        principalTable: "Type_document",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Wilaya_AdresseWilayaDataCode",
                        column: x => x.AdresseWilayaDataCode,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Personne_Physique_Wilaya_WilayaNaissanceDataCode",
                        column: x => x.WilayaNaissanceDataCode,
                        principalSchema: "dbo",
                        principalTable: "Wilaya",
                        principalColumn: "code");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banque",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Caracteristique_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Classe_Retard_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Commune",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Duree_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entite_Publique",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entrepreneur_Individuel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Fonction_Dirigeant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Forme_Juridique",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Monnaie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Niveau_Responsabilite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Personne_Morale",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Personne_Physique",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Situation_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Source_Information_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type_Credit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type_Garantie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type_Personne",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Activite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Etat_Civil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profession",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Type_document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wilaya",
                schema: "dbo");
        }
    }
}
