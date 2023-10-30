using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__3214EC275D270E57", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Correspondants",
                columns: table => new
                {
                    idCorrespondant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Correspo__C3096999DD9A37CD", x => x.idCorrespondant);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    idExpert = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Expert__EC4036BA8A5685A0", x => x.idExpert);
                });

            migrationBuilder.CreateTable(
                name: "Formules",
                columns: table => new
                {
                    codeFormule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Formule__7994DFCB99597E75", x => x.codeFormule);
                });

            migrationBuilder.CreateTable(
                name: "Garanties",
                columns: table => new
                {
                    codeGarantie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Garantie__543EEB909D06398C", x => x.codeGarantie);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSouscription = table.Column<DateTime>(type: "date", nullable: false),
                    dateEcheance = table.Column<DateTime>(type: "date", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: true),
                    numFor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contrat__DF908D65FD4144F5", x => x.num);
                    table.ForeignKey(
                        name: "fk_Contrat",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_contrat2",
                        column: x => x.numFor,
                        principalTable: "Formules",
                        principalColumn: "codeFormule");
                });

            migrationBuilder.CreateTable(
                name: "Previsions",
                columns: table => new
                {
                    codeProvision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeFor = table.Column<int>(type: "int", nullable: false),
                    codeGar = table.Column<int>(type: "int", nullable: false),
                    plafondFranchie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prevoir__307E50CC2E16A2CC", x => x.codeProvision);
                    table.ForeignKey(
                        name: "fk_Prevoir",
                        column: x => x.codeFor,
                        principalTable: "Formules",
                        principalColumn: "codeFormule");
                    table.ForeignKey(
                        name: "fk_Prevoir2",
                        column: x => x.codeGar,
                        principalTable: "Garanties",
                        principalColumn: "codeGarantie");
                });

            migrationBuilder.CreateTable(
                name: "DossiersSinistres",
                columns: table => new
                {
                    codeDossier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOuverture = table.Column<DateTime>(type: "date", nullable: false),
                    dateCloture = table.Column<DateTime>(type: "date", nullable: false),
                    indemnite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numContrat = table.Column<int>(type: "int", nullable: true),
                    idcorrespondant = table.Column<int>(type: "int", nullable: true),
                    idExpert = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DossierS__EE64F91AA6BD35FE", x => x.codeDossier);
                    table.ForeignKey(
                        name: "fk_correspondant",
                        column: x => x.idcorrespondant,
                        principalTable: "Correspondants",
                        principalColumn: "idCorrespondant");
                    table.ForeignKey(
                        name: "fk_dossinistre",
                        column: x => x.numContrat,
                        principalTable: "Contrats",
                        principalColumn: "num");
                    table.ForeignKey(
                        name: "fk_expert",
                        column: x => x.idExpert,
                        principalTable: "Experts",
                        principalColumn: "idExpert");
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    codeIntervention = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeDos = table.Column<int>(type: "int", nullable: false),
                    dateIntervention = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interven__502D49DC1FF1B39A", x => x.codeIntervention);
                    table.ForeignKey(
                        name: "fk_Intervention",
                        column: x => x.codeDos,
                        principalTable: "DossiersSinistres",
                        principalColumn: "codeDossier");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_IdClient",
                table: "Contrats",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_numFor",
                table: "Contrats",
                column: "numFor");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersSinistres_idcorrespondant",
                table: "DossiersSinistres",
                column: "idcorrespondant");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersSinistres_idExpert",
                table: "DossiersSinistres",
                column: "idExpert");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersSinistres_numContrat",
                table: "DossiersSinistres",
                column: "numContrat");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_codeDos",
                table: "Interventions",
                column: "codeDos");

            migrationBuilder.CreateIndex(
                name: "IX_Previsions_codeFor",
                table: "Previsions",
                column: "codeFor");

            migrationBuilder.CreateIndex(
                name: "IX_Previsions_codeGar",
                table: "Previsions",
                column: "codeGar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Previsions");

            migrationBuilder.DropTable(
                name: "DossiersSinistres");

            migrationBuilder.DropTable(
                name: "Garanties");

            migrationBuilder.DropTable(
                name: "Correspondants");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Formules");
        }
    }
}
