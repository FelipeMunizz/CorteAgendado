using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbearia",
                columns: table => new
                {
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearia", x => x.BarbeariaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    TipoDoc = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    IdBarbearia = table.Column<int>(type: "int", nullable: false),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configuracao",
                columns: table => new
                {
                    ConfiguracaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HoraFim = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracao", x => x.ConfiguracaoId);
                    table.ForeignKey(
                        name: "FK_Configuracao_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatoBarbearia",
                columns: table => new
                {
                    ContatoBarbeariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsWhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoBarbearia", x => x.ContatoBarbeariaId);
                    table.ForeignKey(
                        name: "FK_ContatoBarbearia_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoBarbearia",
                columns: table => new
                {
                    EnderecoBarbeariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UF = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoBarbearia", x => x.EnderecoBarbeariaId);
                    table.ForeignKey(
                        name: "FK_EnderecoBarbearia_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    TipoDoc = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servico = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TempoExecucao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BarbeariaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicosId);
                    table.ForeignKey(
                        name: "FK_Servicos_Barbearia_BarbeariaId",
                        column: x => x.BarbeariaId,
                        principalTable: "Barbearia",
                        principalColumn: "BarbeariaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatoCliente",
                columns: table => new
                {
                    ContatoClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsWhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoCliente", x => x.ContatoClienteId);
                    table.ForeignKey(
                        name: "FK_ContatoCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCliente",
                columns: table => new
                {
                    EnderecoClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UF = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCliente", x => x.EnderecoClienteId);
                    table.ForeignKey(
                        name: "FK_EnderecoCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatoFuncionario",
                columns: table => new
                {
                    ContatoFuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsWhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoFuncionario", x => x.ContatoFuncionarioId);
                    table.ForeignKey(
                        name: "FK_ContatoFuncionario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoFuncionario",
                columns: table => new
                {
                    EnderecoFuncioanrioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UF = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoFuncionario", x => x.EnderecoFuncioanrioId);
                    table.ForeignKey(
                        name: "FK_EnderecoFuncionario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicosAgendados",
                columns: table => new
                {
                    ServicosAgendadosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendamentoId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    ServicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosAgendados", x => x.ServicosAgendadosId);
                    table.ForeignKey(
                        name: "FK_ServicosAgendados_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosAgendados_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "ServicosId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteId",
                table: "Agendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_BarbeariaId",
                table: "Cliente",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuracao_BarbeariaId",
                table: "Configuracao",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoBarbearia_BarbeariaId",
                table: "ContatoBarbearia",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoCliente_ClienteId",
                table: "ContatoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoFuncionario_FuncionarioId",
                table: "ContatoFuncionario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoBarbearia_BarbeariaId",
                table: "EnderecoBarbearia",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCliente_ClienteId",
                table: "EnderecoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoFuncionario_FuncionarioId",
                table: "EnderecoFuncionario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_BarbeariaId",
                table: "Funcionario",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BarbeariaId",
                table: "Servicos",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosAgendados_AgendamentoId",
                table: "ServicosAgendados",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosAgendados_ServicosId",
                table: "ServicosAgendados",
                column: "ServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracao");

            migrationBuilder.DropTable(
                name: "ContatoBarbearia");

            migrationBuilder.DropTable(
                name: "ContatoCliente");

            migrationBuilder.DropTable(
                name: "ContatoFuncionario");

            migrationBuilder.DropTable(
                name: "EnderecoBarbearia");

            migrationBuilder.DropTable(
                name: "EnderecoCliente");

            migrationBuilder.DropTable(
                name: "EnderecoFuncionario");

            migrationBuilder.DropTable(
                name: "ServicosAgendados");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Barbearia");
        }
    }
}
