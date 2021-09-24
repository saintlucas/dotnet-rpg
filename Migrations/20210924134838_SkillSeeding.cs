using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_rpg.Migrations
{
    public partial class SkillSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkill_Skills_SkillsID",
                table: "CharacterSkill");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SkillsID",
                table: "CharacterSkill",
                newName: "SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSkill_SkillsID",
                table: "CharacterSkill",
                newName: "IX_CharacterSkill_SkillsId");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 20, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 50, "Blizzard" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkill_Skills_SkillsId",
                table: "CharacterSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkill_Skills_SkillsId",
                table: "CharacterSkill");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "CharacterSkill",
                newName: "SkillsID");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSkill_SkillsId",
                table: "CharacterSkill",
                newName: "IX_CharacterSkill_SkillsID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkill_Skills_SkillsID",
                table: "CharacterSkill",
                column: "SkillsID",
                principalTable: "Skills",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
